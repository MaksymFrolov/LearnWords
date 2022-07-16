using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.ViewModel.RedactionViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.CreateViewModel
{
    public class CreatePastViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreatePast";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enPastSimple = "", enPastContinuous = "", enPastPerfect = "", enPastPerfectContinuous = "", uaPast = "";

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
        public string UAPast
        {
            get => uaPast;
            set => this.RaiseAndSetIfChanged(ref uaPast, value);
        }

        public IScreen HostScreen { get; }

        public CreatePastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENPastSimple, x => x.UAPast,
                (enPastSimple, uaPast) =>
                   !string.IsNullOrEmpty(enPastSimple) &&
                   !string.IsNullOrEmpty(uaPast));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                PastSentence past = new()
                {
                    ENPastSimple = ENPastSimple,
                    ENPastContinuous = ENPastContinuous,
                    ENPastPerfect = ENPastPerfect,
                    ENPastPerfectContinuous = ENPastPerfectContinuous,
                    UAPast = UAPast
                };

                await dataService.Create(past);

                return await Router.NavigateAndReset.Execute(new RedactionPastViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }

        public CreatePastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, Queue<PastSentence> queue, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PastSentence past = queue.Dequeue();

            ENPastSimple = past.ENPastSimple;
            ENPastContinuous = past.ENPastContinuous;
            ENPastPerfect = past.ENPastPerfect;
            ENPastPerfectContinuous = past.ENPastPerfectContinuous;
            UAPast = past.UAPast;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENPastSimple, x => x.UAPast,
                (enPastSimple, uaPast) =>
                   !string.IsNullOrEmpty(enPastSimple) &&
                   !string.IsNullOrEmpty(uaPast));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                past.ENPastSimple = ENPastSimple;
                past.ENPastContinuous = ENPastContinuous;
                past.ENPastPerfect = ENPastPerfect;
                past.ENPastPerfectContinuous = ENPastPerfectContinuous;
                past.UAPast = UAPast;

                await Task.Run(() => dataService.Update(past));

                if (queue.Count != 0)
                    return await Router.Navigate.Execute(new CreatePastViewModel(Router, dataService, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionPastViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
