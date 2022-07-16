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
    public class CreatePresentViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreatePresent";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enPresentSimple = "", enPresentContinuous = "", enPresentPerfect = "", enPresentPerfectContinuous = "", uaPresent = "";

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
        public string UAPresent
        {
            get => uaPresent;
            set => this.RaiseAndSetIfChanged(ref uaPresent, value);
        }

        public IScreen HostScreen { get; }

        public CreatePresentViewModel(RoutingState Router, GenericDataService<PresentSentence> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENPresentSimple, x => x.UAPresent,
                (enPresentSimple, uaPresent) =>
                   !string.IsNullOrEmpty(enPresentSimple) &&
                   !string.IsNullOrEmpty(uaPresent));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                PresentSentence present = new()
                {
                    ENPresentSimple = ENPresentSimple,
                    ENPresentContinuous = ENPresentContinuous,
                    ENPresentPerfect = ENPresentPerfect,
                    ENPresentPerfectContinuous = ENPresentPerfectContinuous,
                    UAPresent = UAPresent
                };

                await dataService.Create(present);

                return await Router.NavigateAndReset.Execute(new RedactionPresentViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }

        public CreatePresentViewModel(RoutingState Router, GenericDataService<PresentSentence> dataService, Queue<PresentSentence> queue, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            PresentSentence present = queue.Dequeue();

            ENPresentSimple = present.ENPresentSimple;
            ENPresentContinuous = present.ENPresentContinuous;
            ENPresentPerfect = present.ENPresentPerfect;
            ENPresentPerfectContinuous = present.ENPresentPerfectContinuous;
            UAPresent = present.UAPresent;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENPresentSimple, x => x.UAPresent,
                (enPresentSimple, uaPresent) =>
                   !string.IsNullOrEmpty(enPresentSimple) &&
                   !string.IsNullOrEmpty(uaPresent));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                present.ENPresentSimple = ENPresentSimple;
                present.ENPresentContinuous = ENPresentContinuous;
                present.ENPresentPerfect = ENPresentPerfect;
                present.ENPresentPerfectContinuous = ENPresentPerfectContinuous;
                present.UAPresent = UAPresent;

                await Task.Run(() => dataService.Update(present));

                if (queue.Count != 0)
                    return await Router.Navigate.Execute(new CreatePresentViewModel(Router, dataService, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionPresentViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
