using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.CreateViewModel
{
    internal class CreateFutureViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreateFuture";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enFutureSimple = "", enFutureContinuous = "", enFuturePerfect = "", enFuturePerfectContinuous = "", uaFuture = "";

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
        public string UAFuture
        {
            get => uaFuture;
            set => this.RaiseAndSetIfChanged(ref uaFuture, value);
        }

        public IScreen HostScreen { get; }

        public CreateFutureViewModel(RoutingState Router, GenericDataService<FutureSentence> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENFutureSimple, x => x.UAFuture,
                (enFutureSimple, uaFuture) =>
                   !string.IsNullOrEmpty(enFutureSimple) &&
                   !string.IsNullOrEmpty(uaFuture));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                FutureSentence future = new()
                {
                    ENFutureSimple = ENFutureSimple,
                    ENFutureContinuous = ENFutureContinuous,
                    ENFuturePerfect = ENFuturePerfect,
                    ENFuturePerfectContinuous = ENFuturePerfectContinuous,
                    UAFuture = UAFuture
                };

                await dataService.Create(future);

                return await Router.NavigateAndReset.Execute(new RedactionFutureViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }

        public CreateFutureViewModel(RoutingState Router, GenericDataService<FutureSentence> dataService, Queue<FutureSentence> queue, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            FutureSentence future = queue.Dequeue();

            ENFutureSimple = future.ENFutureSimple;
            ENFutureContinuous = future.ENFutureContinuous;
            ENFuturePerfect = future.ENFuturePerfect;
            ENFuturePerfectContinuous = future.ENFuturePerfectContinuous;
            UAFuture = future.UAFuture;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENFutureSimple, x => x.UAFuture,
                (enFutureSimple, uaFuture) =>
                   !string.IsNullOrEmpty(enFutureSimple) &&
                   !string.IsNullOrEmpty(uaFuture));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                future.ENFutureSimple = ENFutureSimple;
                future.ENFutureContinuous = ENFutureContinuous;
                future.ENFuturePerfect = ENFuturePerfect;
                future.ENFuturePerfectContinuous = ENFuturePerfectContinuous;
                future.UAFuture = UAFuture;

                await Task.Run(() => dataService.Update(future));

                if (queue.Count != 0)
                    return await Router.Navigate.Execute(new CreateFutureViewModel(Router, dataService, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionFutureViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
