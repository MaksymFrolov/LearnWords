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

namespace LearnWords.ViewModel.EN_UAViewModel
{
    public class EnUaPresentViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EnUaPresent";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        bool styleCompleted, textEnabled = true, uaPresentEnabled = false, enPresentContinuousEnabled = true, enPresentPerfectEnabled = true, enPresentPerfectContinuousEnabled = true;

        string enPresentSimple, enPresentContinuous = "", enPresentPerfect = "", enPresentPerfectContinuous = "", uaPresent, userUaPresent;

        public string ENPresentSimple
        {
            get => enPresentSimple;
            set => this.RaiseAndSetIfChanged(ref enPresentSimple, value);
        }
        public string ENPresentContinuous
        {
            get => enPresentContinuous;
            set => this.RaiseAndSetIfChanged(ref enPresentContinuous, value);
        }
        public string ENPresentPerfect
        {
            get => enPresentPerfect;
            set => this.RaiseAndSetIfChanged(ref enPresentPerfect, value);
        }
        public string ENPresentPerfectContinuous
        {
            get => enPresentPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref enPresentPerfectContinuous, value);
        }
        public string UserUaPresent
        {
            get => userUaPresent;
            set => this.RaiseAndSetIfChanged(ref userUaPresent, value);
        }
        public string UAPresent
        {
            get => uaPresent;
            set => this.RaiseAndSetIfChanged(ref uaPresent, value);
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
        public bool UAPresentEnabled
        {
            get => uaPresentEnabled;
            set => this.RaiseAndSetIfChanged(ref uaPresentEnabled, value);
        }
        public bool ENPresentContinuousEnabled
        {
            get => enPresentContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enPresentContinuousEnabled, value);
        }
        public bool ENPresentPerfectEnabled
        {
            get => enPresentPerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref enPresentPerfectEnabled, value);
        }
        public bool ENPresentPerfectContinuousEnabled
        {
            get => enPresentPerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enPresentPerfectContinuousEnabled, value);
        }

        readonly ObservableAsPropertyHelper<bool> visiblePresentContinuous;
        public bool VisiblePresentContinuous => visiblePresentContinuous.Value;
        readonly ObservableAsPropertyHelper<bool> visiblePresentPerfect;
        public bool VisiblePresentPerfect => visiblePresentPerfect.Value;
        readonly ObservableAsPropertyHelper<bool> visiblePresentPerfectContinuous;
        public bool VisiblePresentPerfectContinuous => visiblePresentPerfectContinuous.Value;

        public IScreen HostScreen { get; }

        public EnUaPresentViewModel(RoutingState Router, GenericDataService<PresentSentence> dataService, Queue<PresentSentence> queue, List<(PresentSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PresentSentence present = queue.Dequeue();

            ENPresentSimple = present.ENPresentSimple;
            ENPresentContinuous = present.ENPresentContinuous;
            ENPresentPerfect = present.ENPresentPerfect;
            ENPresentPerfectContinuous = present.ENPresentPerfectContinuous;
            UAPresent = present.UAPresent;

            if (string.IsNullOrEmpty(ENPresentContinuous))
                ENPresentContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENPresentPerfect))
                ENPresentPerfectEnabled = false;
            if (string.IsNullOrEmpty(ENPresentPerfectContinuous))
                ENPresentPerfectContinuousEnabled = false;

            visiblePresentContinuous = this.WhenAnyValue(x => x.ENPresentContinuous,
                (enPresentContinuous) =>
                    !string.IsNullOrEmpty(enPresentContinuous)).ToProperty(this, x => x.VisiblePresentContinuous);
            visiblePresentPerfect = this.WhenAnyValue(x => x.ENPresentPerfect,
                (enPresentPerfect) =>
                    !string.IsNullOrEmpty(enPresentPerfect)).ToProperty(this, x => x.VisiblePresentPerfect);
            visiblePresentPerfectContinuous = this.WhenAnyValue(x => x.ENPresentPerfectContinuous,
                (enPresentPerfectContinuous) =>
                    !string.IsNullOrEmpty(enPresentPerfectContinuous)).ToProperty(this, x => x.VisiblePresentPerfectContinuous);

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserUaPresent,
                (userUaPresent) =>
                   !string.IsNullOrEmpty(userUaPresent));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.UAPresentEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserUaPresent == UAPresent;
                UAPresentEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    present.CompletedENUA++;
                else
                    present.FailedENUA++;

                await dataService.Update(present);

                comletedList.Add((present, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                if (comletedList.Count != 10)
                    return await Router.Navigate.Execute(new EnUaPresentViewModel(Router, dataService, queue, comletedList));
                return await Router.Navigate.Execute(new ResultPresentViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
