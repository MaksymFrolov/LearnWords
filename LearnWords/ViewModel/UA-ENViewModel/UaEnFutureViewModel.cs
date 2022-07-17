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
    public class UaEnFutureViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UaEnFuture";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enFutureSimple, uaFuture, userENFutureSimple, userFutureContinuous, userFuturePerfect, userFuturePerfectContinuous, futureContinuous, futurePerfect, futurePerfectContinuous;
        bool styleCompleted, textEnabled = true, futureEnabled = false, futureContinuousEnabled = true, futurePerfectEnabled = true, futurePerfectContinuousEnabled = true,
                                                                        futureContinuousCorrectEnabled = false, futurePerfectCorrectEnabled = false, futurePerfectContinuousCorrectEnabled = false;

        public string ENFutureSimple
        {
            get => enFutureSimple;
            set => this.RaiseAndSetIfChanged(ref enFutureSimple, value);
        }
        public string UAFuture
        {
            get => uaFuture;
            set => this.RaiseAndSetIfChanged(ref uaFuture, value);
        }
        public string UserENFutureSimple
        {
            get => userENFutureSimple;
            set => this.RaiseAndSetIfChanged(ref userENFutureSimple, value);
        }
        public string UserFutureContinuous
        {
            get => userFutureContinuous;
            set => this.RaiseAndSetIfChanged(ref userFutureContinuous, value);
        }
        public string UserFuturePerfect
        {
            get => userFuturePerfect;
            set => this.RaiseAndSetIfChanged(ref userFuturePerfect, value);
        }
        public string UserFuturePerfectContinuous
        {
            get => userFuturePerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref userFuturePerfectContinuous, value);
        }
        public string ENFutureContinuous
        {
            get => futureContinuous;
            set => this.RaiseAndSetIfChanged(ref futureContinuous, value);
        }
        public string ENFuturePerfect
        {
            get => futurePerfect;
            set => this.RaiseAndSetIfChanged(ref futurePerfect, value);
        }
        public string ENFuturePerfectContinuous
        {
            get => futurePerfectContinuous;
            set => this.RaiseAndSetIfChanged(ref futurePerfectContinuous, value);
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
        public bool FutureEnabled
        {
            get => futureEnabled;
            set => this.RaiseAndSetIfChanged(ref futureEnabled, value);
        }
        public bool FutureContinuousEnabled
        {
            get => futureContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref futureContinuousEnabled, value);
        }
        public bool FuturePerfectEnabled
        {
            get => futurePerfectEnabled;
            set => this.RaiseAndSetIfChanged(ref futurePerfectEnabled, value);
        }
        public bool FuturePerfectContinuousEnabled
        {
            get => futurePerfectContinuousEnabled;
            set => this.RaiseAndSetIfChanged(ref futurePerfectContinuousEnabled, value);
        }
        public bool FutureContinuousCorrectEnabled
        {
            get => futureContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref futureContinuousCorrectEnabled, value);
        }
        public bool FuturePerfectCorrectEnabled
        {
            get => futurePerfectCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref futurePerfectCorrectEnabled, value);
        }
        public bool FuturePerfectContinuousCorrectEnabled
        {
            get => futurePerfectContinuousCorrectEnabled;
            set => this.RaiseAndSetIfChanged(ref futurePerfectContinuousCorrectEnabled, value);
        }

        public IScreen HostScreen { get; }

        public UaEnFutureViewModel(RoutingState Router, GenericDataService<FutureSentence> dataService, Queue<FutureSentence> queue, List<(FutureSentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            FutureSentence future = queue.Dequeue();

            UAFuture = future.UAFuture;
            ENFutureSimple = future.ENFutureSimple;
            ENFutureContinuous = future.ENFutureContinuous;
            ENFuturePerfect = future.ENFuturePerfect;
            ENFuturePerfectContinuous = future.ENFuturePerfectContinuous;

            if (string.IsNullOrEmpty(ENFutureContinuous))
                FutureContinuousEnabled = false;
            if (string.IsNullOrEmpty(ENFuturePerfect))
                FuturePerfectEnabled = false;
            if (string.IsNullOrEmpty(ENFuturePerfectContinuous))
                FuturePerfectContinuousEnabled = false;

            IObservable<bool> canExecute = this
                .WhenAnyValue(x => x.UserENFutureSimple,
                    (userENFutureSimple) => !string.IsNullOrEmpty(userENFutureSimple));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.FutureEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserENFutureSimple == ENFutureSimple && 
                    UserFutureContinuous == ENFutureContinuous && 
                    UserFuturePerfect == ENFuturePerfect &&
                    UserFuturePerfectContinuous==ENFuturePerfectContinuous;
                FutureEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    future.CompletedUAEN++;
                else
                    future.FailedUAEN++;

                await dataService.Update(future);

                comletedList.Add((future, StyleCompleted));

                if (!string.IsNullOrEmpty(ENFuturePerfectContinuous))
                    FuturePerfectContinuousCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENFuturePerfect))
                    FuturePerfectCorrectEnabled = true;
                if (!string.IsNullOrEmpty(ENFutureContinuous))
                    FutureContinuousCorrectEnabled = true;

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UaEnFutureViewModel(Router, dataService, queue, comletedList));
                return Router.Navigate.Execute(new ResultFutureViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
