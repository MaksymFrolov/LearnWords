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
    public class EnUaFutureViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EnUaFuture";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        bool styleCompleted, textEnabled = true, uaFutureEnabled = false, enFutureContinuousEnabled = true, enFuturePerfectEnabled = true, enFuturePerfectContinuousEnabled = true;

        string enFutureSimple, enFutureContinuous = "", enFuturePerfect = "", enFuturePerfectContinuous = "", uaFuture, userUaFuture;

        public string ENFutureSimple
        {
            get => enFutureSimple;
            set => this.RaiseAndSetIfChanged(ref enFutureSimple, value);
        }
        public string ENFutureContinuous
        {
            get => enFutureContinuous;
            set => this.RaiseAndSetIfChanged(ref enFutureContinuous, value);
        }
        public string ENFuturePerfect
        {
            get => enFuturePerfect;
            set => this.RaiseAndSetIfChanged(ref enFuturePerfect, value);
        }
        public string ENFuturePerfectContinuous
        {
            get => enFuturePerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref enFuturePerfectContinuous, value);
        }
        public string UserUaFuture
        {
            get => userUaFuture;
            set => this.RaiseAndSetIfChanged(ref userUaFuture, value);
        }
        public string UAFuture
        {
            get => uaFuture;
            set => this.RaiseAndSetIfChanged(ref uaFuture, value);
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
        public bool UAFutureEnabled
        {
            get => uaFutureEnabled;
            set => this.RaiseAndSetIfChanged(ref uaFutureEnabled, value);
        }
        public bool ENFutureContinuousEnabled
        {
            get => enFutureContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enFutureContinuousEnabled, value);
        }
        public bool ENFuturePerfectEnabled
        {
            get => enFuturePerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref enFuturePerfectEnabled, value);
        }
        public bool ENFuturePerfectContinuousEnabled
        {
            get => enFuturePerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref enFuturePerfectContinuousEnabled, value);
        }

        readonly ObservableAsPropertyHelper<bool> visibleFutureContinuous;
        public bool VisibleFutureContinuous => visibleFutureContinuous.Value;
        readonly ObservableAsPropertyHelper<bool> visibleFuturePerfect;
        public bool VisibleFuturePerfect => visibleFuturePerfect.Value;
        readonly ObservableAsPropertyHelper<bool> visibleFuturePerfectContinuous;
        public bool VisibleFuturePerfectContinuous => visibleFuturePerfectContinuous.Value;

        public IScreen HostScreen { get; }

        public EnUaFutureViewModel(RoutingState Router, GenericDataService<FutureSentence> dataService, Queue<FutureSentence> queue, List<(FutureSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            FutureSentence future = queue.Dequeue();

            ENFutureSimple = future.ENFutureSimple;
            ENFutureContinuous = future.ENFutureContinuous;
            ENFuturePerfect = future.ENFuturePerfect;
            ENFuturePerfectContinuous = future.ENFuturePerfectContinuous;
            UAFuture = future.UAFuture;

            if (string.IsNullOrEmpty(ENFutureContinuous))
                ENFutureContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENFuturePerfect))
                ENFuturePerfectEnabled = false;
            if (string.IsNullOrEmpty(ENFuturePerfectContinuous))
                ENFuturePerfectContinuousEnabled = false;

            visibleFutureContinuous = this.WhenAnyValue(x => x.ENFutureContinuous,
                (enFutureContinuous) =>
                    !string.IsNullOrEmpty(enFutureContinuous)).ToProperty(this, x => x.VisibleFutureContinuous);
            visibleFuturePerfect = this.WhenAnyValue(x => x.ENFuturePerfect,
                (enFuturePerfect) =>
                    !string.IsNullOrEmpty(enFuturePerfect)).ToProperty(this, x => x.VisibleFuturePerfect);
            visibleFuturePerfectContinuous = this.WhenAnyValue(x => x.ENFuturePerfectContinuous,
                (enFuturePerfectContinuous) =>
                    !string.IsNullOrEmpty(enFuturePerfectContinuous)).ToProperty(this, x => x.VisibleFuturePerfectContinuous);

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserUaFuture,
                (userUaFuture) =>
                   !string.IsNullOrEmpty(userUaFuture));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.UAFutureEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserUaFuture == UAFuture;
                UAFutureEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    future.CompletedENUA++;
                else
                    future.FailedENUA++;

                await dataService.Update(future);

                comletedList.Add((future, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                if (comletedList.Count != 10)
                    return await Router.Navigate.Execute(new EnUaFutureViewModel(Router, dataService, queue, comletedList));
                return await Router.Navigate.Execute(new ResultFutureViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
