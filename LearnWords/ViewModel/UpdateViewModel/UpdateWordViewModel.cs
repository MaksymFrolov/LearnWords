using LearnWords.Model.CRUD;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.ViewModel.RedactionViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.UpdateViewModel
{
    internal class UpdateWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "CreateWord";

        public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

        string enWord, uaWord, secondForm, thirdForm;

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

        public UpdateWordViewModel(RoutingState Router, Queue<Word> queue, IScreen screen = null)
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
                word.ENWord = enWord;
                word.UAWord = uaWord;
                word.SecondForm = secondForm;
                word.ThirdForm = thirdForm;

                await Task.Run(() => DataWord.UpdateData(word));

                if (queue.Count is not 0)
                    return await Router.Navigate.Execute(new UpdateWordViewModel(Router, queue));
                else
                    return await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
