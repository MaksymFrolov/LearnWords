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
    public class EnUaPastViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EnUaPast";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        bool styleCompleted, textEnabled = true, uaPastEnabled = false, enPastContinuousEnabled = true, enPastPerfectEnabled = true, enPastPerfectContinuousEnabled = true;

        string enPastSimple, enPastContinuous = "", enPastPerfect = "", enPastPerfectContinuous = "", uaPast, userUaPast;

        public string ENPastSimple
        {
            get => enPastSimple;
            set => this.RaiseAndSetIfChanged(ref enPastSimple, value);
        }
        public string ENPastContinuous
        {
            get => enPastContinuous;
            set => this.RaiseAndSetIfChanged(ref enPastContinuous, value);
        }
        public string ENPastPerfect
        {
            get => enPastPerfect;
            set => this.RaiseAndSetIfChanged(ref enPastPerfect, value);
        }
        public string ENPastPerfectContinuous
        {
            get => enPastPerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref enPastPerfectContinuous, value);
        }
        public string UserUaPast
        {
            get => userUaPast;
            set => this.RaiseAndSetIfChanged(ref userUaPast, value);
        }
        public string UAPast
        {
            get => uaPast;
            set => this.RaiseAndSetIfChanged(ref uaPast, value);
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
        public bool UAPastEnabled
        {
            get => uaPastEnabled;
            set => this.RaiseAndSetIfChanged(ref uaPastEnabled, value);
        }
        public bool ENPastContinuousEnabled
        {
            get => enPastContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enPastContinuousEnabled, value);
        }
        public bool ENPastPerfectEnabled
        {
            get => enPastPerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref enPastPerfectEnabled, value);
        }
        public bool ENPastPerfectContinuousEnabled
        {
            get => enPastPerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enPastPerfectContinuousEnabled, value);
        }

        readonly ObservableAsPropertyHelper<bool> visiblePastContinuous;
        public bool VisiblePastContinuous => visiblePastContinuous.Value;
        readonly ObservableAsPropertyHelper<bool> visiblePastPerfect;
        public bool VisiblePastPerfect => visiblePastPerfect.Value;
        readonly ObservableAsPropertyHelper<bool> visiblePastPerfectContinuous;
        public bool VisiblePastPerfectContinuous => visiblePastPerfectContinuous.Value;

        public IScreen HostScreen { get; }

        public EnUaPastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, Queue<PastSentence> queue, List<(PastSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PastSentence past = queue.Dequeue();

            ENPastSimple = past.ENPastSimple;
            ENPastContinuous = past.ENPastContinuous;
            ENPastPerfect = past.ENPastPerfect;
            ENPastPerfectContinuous = past.ENPastPerfectContinuous;
            UAPast = past.UAPast;

            if (string.IsNullOrEmpty(ENPastContinuous))
                ENPastContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENPastPerfect))
                ENPastPerfectEnabled = false;
            if (string.IsNullOrEmpty(ENPastPerfectContinuous))
                ENPastPerfectContinuousEnabled = false;

            visiblePastContinuous = this.WhenAnyValue(x => x.ENPastContinuous,
                (enPastContinuous) =>
                    !string.IsNullOrEmpty(enPastContinuous)).ToProperty(this, x => x.VisiblePastContinuous);
            visiblePastPerfect = this.WhenAnyValue(x => x.ENPastPerfect,
                (enPastPerfect) =>
                    !string.IsNullOrEmpty(enPastPerfect)).ToProperty(this, x => x.VisiblePastPerfect);
            visiblePastPerfectContinuous = this.WhenAnyValue(x => x.ENPastPerfectContinuous,
                (enPastPerfectContinuous) =>
                    !string.IsNullOrEmpty(enPastPerfectContinuous)).ToProperty(this, x => x.VisiblePastPerfectContinuous);

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserUaPast,
                (userUaPast) =>
                   !string.IsNullOrEmpty(userUaPast));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.UAPastEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserUaPast == UAPast;
                UAPastEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    past.CompletedENUA++;
                else
                    past.FailedENUA++;

                await dataService.Update(past);

                comletedList.Add((past, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                if (comletedList.Count != 10)
                    return await Router.Navigate.Execute(new EnUaPastViewModel(Router, dataService, queue, comletedList));
                return await Router.Navigate.Execute(new ResultPastViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
