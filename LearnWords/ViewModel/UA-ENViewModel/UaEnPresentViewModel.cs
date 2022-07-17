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
    public class UaEnPresentViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UaEnPresent";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enPresentSimple, uaPresent, userENPresentSimple, userPresentContinuous, userPresentPerfect, userPresentPerfectContinuous, presentContinuous, presentPerfect, presentPerfectContinuous;
        bool styleCompleted, textEnabled = true, presentEnabled = false, presentContinuousEnabled = true, presentPerfectEnabled = true, presentPerfectContinuousEnabled = true,
                                                                        presentContinuousCorrectEnabled = false, presentPerfectCorrectEnabled = false, presentPerfectContinuousCorrectEnabled = false;

        public string ENPresentSimple
        {
            get => enPresentSimple;
            set => this.RaiseAndSetIfChanged(ref enPresentSimple, value);
        }
        public string UAPresent
        {
            get => uaPresent;
            set => this.RaiseAndSetIfChanged(ref uaPresent, value);
        }
        public string UserENPresentSimple
        {
            get => userENPresentSimple;
            set => this.RaiseAndSetIfChanged(ref userENPresentSimple, value);
        }
        public string UserPresentContinuous
        {
            get => userPresentContinuous;
            set => this.RaiseAndSetIfChanged(ref userPresentContinuous, value);
        }
        public string UserPresentPerfect
        {
            get => userPresentPerfect;
            set => this.RaiseAndSetIfChanged(ref userPresentPerfect, value);
        }
        public string UserPresentPerfectContinuous
        {
            get => userPresentPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref userPresentPerfectContinuous, value);
        }
        public string ENPresentContinuous
        {
            get => presentContinuous;
            set => this.RaiseAndSetIfChanged(ref presentContinuous, value);
        }
        public string ENPresentPerfect
        {
            get => presentPerfect;
            set => this.RaiseAndSetIfChanged(ref presentPerfect, value);
        }
        public string ENPresentPerfectContinuous
        {
            get => presentPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref presentPerfectContinuous, value);
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
        public bool PresentEnabled
        {
            get => presentEnabled;
            set => this.RaiseAndSetIfChanged(ref presentEnabled, value);
        }
        public bool PresentContinuousEnabled
        {
            get => presentContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref presentContinuousEnabled, value);
        }
        public bool PresentPerfectEnabled
        {
            get => presentPerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref presentPerfectEnabled, value);
        }
        public bool PresentPerfectContinuousEnabled
        {
            get => presentPerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref presentPerfectContinuousEnabled, value);
        }
        public bool PresentContinuousCorrectEnabled
        {
            get => presentContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref presentContinuousCorrectEnabled, value);
        }
        public bool PresentPerfectCorrectEnabled
        {
            get => presentPerfectCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref presentPerfectCorrectEnabled, value);
        }
        public bool PresentPerfectContinuousCorrectEnabled
        {
            get => presentPerfectContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref presentPerfectContinuousCorrectEnabled, value);
        }

        public IScreen HostScreen { get; }

        public UaEnPresentViewModel(RoutingState Router, GenericDataService<PresentSentence> dataService, Queue<PresentSentence> queue, List<(PresentSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PresentSentence present = queue.Dequeue();

            UAPresent = present.UAPresent;
            ENPresentSimple = present.ENPresentSimple;
            ENPresentContinuous = present.ENPresentContinuous;
            ENPresentPerfect = present.ENPresentPerfect;
            ENPresentPerfectContinuous = present.ENPresentPerfectContinuous;

            if (string.IsNullOrEmpty(ENPresentContinuous))
                PresentContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENPresentPerfect))
                PresentPerfectEnabled = false;
            if (string.IsNullOrEmpty(ENPresentPerfectContinuous))
                PresentPerfectContinuousEnabled = false;

            IObservable<bool> canExecute = this
                .WhenAnyValue(x => x.UserENPresentSimple,
                    (userENPresentSimple) => !string.IsNullOrEmpty(userENPresentSimple));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.PresentEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserENPresentSimple == ENPresentSimple &&
                    UserPresentContinuous == ENPresentContinuous &&
                    UserPresentPerfect == ENPresentPerfect &&
                    UserPresentPerfectContinuous == ENPresentPerfectContinuous;
                PresentEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    present.CompletedUAEN++;
                else
                    present.FailedUAEN++;

                await dataService.Update(present);

                comletedList.Add((present, StyleCompleted));

                if (!string.IsNullOrEmpty(ENPresentPerfectContinuous))
                    PresentPerfectContinuousCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENPresentPerfect))
                    PresentPerfectCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENPresentContinuous))
                    PresentContinuousCorrectEnabled = true;

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UaEnPresentViewModel(Router, dataService, queue, comletedList));
                return Router.Navigate.Execute(new ResultPresentViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
