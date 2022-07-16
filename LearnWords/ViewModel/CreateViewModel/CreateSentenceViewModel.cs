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
    public class CreateSentenceViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreateSentence";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enSentence = "", uaSentence = "";

        public string ENSentence
        {
            get => enSentence;
            set => this.RaiseAndSetIfChanged(ref enSentence, value);
        }
        public string UASentence
        {
            get => uaSentence;
            set => this.RaiseAndSetIfChanged(ref uaSentence, value);
        }

        public IScreen HostScreen { get; }

        public CreateSentenceViewModel(RoutingState Router, GenericDataService<Sentence> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENSentence, x => x.UASentence,
                (enSentence, uaSentence) =>
                   !string.IsNullOrEmpty(enSentence) &&
                   !string.IsNullOrEmpty(uaSentence));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                Sentence sentence = new()
                {
                    ENSentence = ENSentence,
                    UASentence = UASentence
                };

                await dataService.Create(sentence);

                return await Router.NavigateAndReset.Execute(new RedactionSentenceViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }

        public CreateSentenceViewModel(RoutingState Router, GenericDataService<Sentence> dataService, Queue<Sentence> queue, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Sentence sentence = queue.Dequeue();

            ENSentence = sentence.ENSentence;
            UASentence = sentence.UASentence;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENSentence, x => x.UASentence,
                (enSentence, uaSentence) =>
                   !string.IsNullOrEmpty(enSentence) &&
                   !string.IsNullOrEmpty(uaSentence));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                sentence.ENSentence = ENSentence;
                sentence.UASentence = UASentence;

                await Task.Run(() => dataService.Update(sentence));

                if (queue.Count != 0)
                    return await Router.Navigate.Execute(new CreateSentenceViewModel(Router, dataService, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionSentenceViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
