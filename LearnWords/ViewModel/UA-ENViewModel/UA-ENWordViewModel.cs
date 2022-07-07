using LearnWords.Model.CRUD;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.ViewModel.ResultViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.UA_ENViewModel
{
    internal class UA_ENWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UA-EN";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enWord, uaWord, userENWord, userThirdForm, userSecondForm, secondForm, thirdForm;
        bool styleCompleted, completed = false, textEnabled = true, uaWordEnabled = false;

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
        public string UserENWord
        {
            get => userENWord;
            set => this.RaiseAndSetIfChanged(ref userENWord, value);
        }
        public string UserSecondForm
        {
            get => userSecondForm;
            set => this.RaiseAndSetIfChanged(ref userSecondForm, value);
        }
        public string UserThirdForm
        {
            get => userThirdForm;
            set => this.RaiseAndSetIfChanged(ref userThirdForm, value);
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
        public bool StyleCompleted
        {
            get => styleCompleted;
            set => this.RaiseAndSetIfChanged(ref styleCompleted, value);
        }
        public bool Completed
        {
            get => completed;
            set => this.RaiseAndSetIfChanged(ref completed, value);
        }
        public bool TextEnabled
        {
            get => textEnabled;
            set => this.RaiseAndSetIfChanged(ref textEnabled, value);
        }
        public bool UAWordEnabled
        {
            get => uaWordEnabled;
            set => this.RaiseAndSetIfChanged(ref uaWordEnabled, value);
        }

        public IScreen HostScreen { get; }

        public UA_ENWordViewModel(RoutingState Router, Queue<Word> queue, List<(Word, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Word word = queue.Dequeue();

            ENWord = word.ENWord;
            UAWord = word.UAWord;
            SecondForm = word.SecondForm;
            ThirdForm = word.ThirdForm;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserENWord, x => x.UserSecondForm, x => x.UserThirdForm,
                (userENWord, userSecondForm, userThirdForm) =>
                   !string.IsNullOrEmpty(userENWord) &&
                   !string.IsNullOrEmpty(userSecondForm) &&
                   !string.IsNullOrEmpty(userThirdForm));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.Completed);
            IObservable<bool> canStart = this.WhenAnyValue(x => !x.Completed);

            Start = ReactiveCommand.Create(() =>
            {
                StyleCompleted = userENWord == ENWord && UserSecondForm == SecondForm && UserThirdForm == ThirdForm;
                UAWordEnabled = true;
                TextEnabled = false;
                Completed = true;

                if (StyleCompleted)
                    word.CompletedUAEN++;
                else
                    word.FailedUAEN++;

                Task.Run(() => DataWord.UpdateData(word));

                comletedList.Add((word, StyleCompleted));
            }, Observable.Concat(canExecute, canStart));

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UA_ENWordViewModel(Router, queue, comletedList));
                return Router.Navigate.Execute(new ResultWordViewModel(Router, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
