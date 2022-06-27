using LearnWords.Model.CRUD;
using LearnWords.Model.DBEntity.Clases;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.EN_UAViewModel
{
    internal class EN_UAWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EN-UA";

        public ReactiveCommand<Unit, Unit> Start { get; }

        string enWord, uaWord, secondForm = "", thirdForm = "";

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

        public EN_UAWordViewModel(RoutingState Router, List<Word> list, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Word word = list.First();

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
                Word word = new()
                {
                    ENWord = enWord,
                    UAWord = uaWord,
                    SecondForm = secondForm,
                    ThirdForm = thirdForm
                };

                await Task.Run(() => DataWord.CreateData(word));
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
