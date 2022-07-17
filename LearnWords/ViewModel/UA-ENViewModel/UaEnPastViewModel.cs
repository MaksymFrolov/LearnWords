using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.ViewModel.ResultViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;


namespace LearnWords.ViewModel.UA_ENViewModel
{
    public class UaEnPastViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UaEnPast";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enPastSimple, uaPast, userENPastSimple, userPastContinuous, userPastPerfect, userPastPerfectContinuous, pastContinuous, pastPerfect, pastPerfectContinuous;
        bool styleCompleted, textEnabled = true, pastEnabled = false, pastContinuousEnabled = true, pastPerfectEnabled = true, pastPerfectContinuousEnabled = true,
                                                                        pastContinuousCorrectEnabled = false, pastPerfectCorrectEnabled = false, pastPerfectContinuousCorrectEnabled = false;

        public string ENPastSimple
        {
            get => enPastSimple;
            set => this.RaiseAndSetIfChanged(ref enPastSimple, value);
        }
        public string UAPast
        {
            get => uaPast;
            set => this.RaiseAndSetIfChanged(ref uaPast, value);
        }
        public string UserENPastSimple
        {
            get => userENPastSimple;
            set => this.RaiseAndSetIfChanged(ref userENPastSimple, value);
        }
        public string UserPastContinuous
        {
            get => userPastContinuous;
            set => this.RaiseAndSetIfChanged(ref userPastContinuous, value);
        }
        public string UserPastPerfect
        {
            get => userPastPerfect;
            set => this.RaiseAndSetIfChanged(ref userPastPerfect, value);
        }
        public string UserPastPerfectContinuous
        {
            get => userPastPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref userPastPerfectContinuous, value);
        }
        public string ENPastContinuous
        {
            get => pastContinuous;
            set => this.RaiseAndSetIfChanged(ref pastContinuous, value);
        }
        public string ENPastPerfect
        {
            get => pastPerfect;
            set => this.RaiseAndSetIfChanged(ref pastPerfect, value);
        }
        public string ENPastPerfectContinuous
        {
            get => pastPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref pastPerfectContinuous, value);
        }
        public bool StyleCompleted
        {
            get => styleCompleted;
            set => this.RaiseAndSetIfChanged(ref styleCompleted, value);
        }
        public bool TextEnabled
        {
            get => textEnabled;
            set => this.RaiseAndSetIfChanged(ref textEnabled, value);
        }
        public bool PastEnabled
        {
            get => pastEnabled;
            set => this.RaiseAndSetIfChanged(ref pastEnabled, value);
        }
        public bool PastContinuousEnabled
        {
            get => pastContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref pastContinuousEnabled, value);
        }
        public bool PastPerfectEnabled
        {
            get => pastPerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref pastPerfectEnabled, value);
        }
        public bool PastPerfectContinuousEnabled
        {
            get => pastPerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref pastPerfectContinuousEnabled, value);
        }
        public bool PastContinuousCorrectEnabled
        {
            get => pastContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref pastContinuousCorrectEnabled, value);
        }
        public bool PastPerfectCorrectEnabled
        {
            get => pastPerfectCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref pastPerfectCorrectEnabled, value);
        }
        public bool PastPerfectContinuousCorrectEnabled
        {
            get => pastPerfectContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref pastPerfectContinuousCorrectEnabled, value);
        }

        public IScreen HostScreen { get; }

        public UaEnPastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, Queue<PastSentence> queue, List<(PastSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PastSentence past = queue.Dequeue();

            UAPast = past.UAPast;
            ENPastSimple = past.ENPastSimple;
            ENPastContinuous = past.ENPastContinuous;
            ENPastPerfect = past.ENPastPerfect;
            ENPastPerfectContinuous = past.ENPastPerfectContinuous;

            if (string.IsNullOrEmpty(ENPastContinuous))
                PastContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENPastPerfect))
                PastPerfectEnabled = false;
            if (string.IsNullOrEmpty(ENPastPerfectContinuous))
                PastPerfectContinuousEnabled = false;

            IObservable<bool> canExecute = this
                .WhenAnyValue(x => x.UserENPastSimple,
                    (userENPastSimple) => !string.IsNullOrEmpty(userENPastSimple));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.PastEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserENPastSimple == ENPastSimple &&
                    UserPastContinuous == ENPastContinuous &&
                    UserPastPerfect == ENPastPerfect &&
                    UserPastPerfectContinuous == ENPastPerfectContinuous;
                PastEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    past.CompletedUAEN++;
                else
                    past.FailedUAEN++;

                await dataService.Update(past);

                comletedList.Add((past, StyleCompleted));

                if (!string.IsNullOrEmpty(ENPastPerfectContinuous))
                    PastPerfectContinuousCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENPastPerfect))
                    PastPerfectCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENPastContinuous))
                    PastContinuousCorrectEnabled = true;

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UaEnPastViewModel(Router, dataService, queue, comletedList));
                return Router.Navigate.Execute(new ResultPastViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
