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
    public class CreateWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreateWord";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enWord = "", uaWord = "", secondForm = "", thirdForm="";

        public string ENWord
        {
            get => enWord;
            set => this.RaiseAndSetIfChanged(ref enWord, value);
        }
        public string UAWord
        {
            get => uaWord;
            set => this.RaiseAndSetIfChanged(ref uaWord, value);
        }
        public string SecondForm
        {
            get => secondForm;
            set => this.RaiseAndSetIfChanged(ref secondForm, value);
        }
        public string ThirdForm
        {
            get => thirdForm;
            set => this.RaiseAndSetIfChanged(ref thirdForm, value);
        }

        public IScreen HostScreen { get; }

        public CreateWordViewModel(RoutingState Router, GenericDataService<Word> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENWord, x => x.UAWord,
                (enWord, uaWord) =>
                   !string.IsNullOrEmpty(enWord) &&
                   !string.IsNullOrEmpty(uaWord));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                Word word = new()
                {
                    ENWord = enWord,
                    UAWord = uaWord,
                    SecondForm = secondForm,
                    ThirdForm = thirdForm
                };

                await dataService.Create(word);

                return await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }

        public CreateWordViewModel(RoutingState Router, GenericDataService<Word> dataService, Queue<Word> queue, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Word word = queue.Dequeue();

            ENWord = word.ENWord;
            UAWord = word.UAWord;
            SecondForm = word.SecondForm;
            ThirdForm = word.ThirdForm;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.ENWord, x => x.UAWord,
                (enWord, uaWord) =>
                   !string.IsNullOrEmpty(enWord) &&
                   !string.IsNullOrEmpty(uaWord));

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                word.ENWord = ENWord;
                word.UAWord = UAWord;
                word.SecondForm = SecondForm;
                word.ThirdForm = ThirdForm;

                await Task.Run(() => dataService.Update(word));

                if (queue.Count != 0)
                    return await Router.Navigate.Execute(new CreateWordViewModel(Router, dataService, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router, dataService));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
