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
    public class UA_ENWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UA-EN";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enWord, uaWord, userENWord, userThirdForm, userSecondForm, secondForm, thirdForm;
        bool styleCompleted, textEnabled = true, wordEnabled = false, secondEnabled = true, thirdEnabled = true, secondEnabledLabel = false, thirdEnabledLabel = false;

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
        public bool TextEnabled
        {
            get => textEnabled;
            set => this.RaiseAndSetIfChanged(ref textEnabled, value);
        }
        public bool WordEnabled
        {
            get => wordEnabled;
            set => this.RaiseAndSetIfChanged(ref wordEnabled, value);
        }
        public bool SecondEnabled
        {
            get => secondEnabled;
            set => this.RaiseAndSetIfChanged(ref secondEnabled, value);
        }
        public bool ThirdEnabled
        {
            get => thirdEnabled;
            set => this.RaiseAndSetIfChanged(ref thirdEnabled, value);
        }
        public bool SecondEnabledLabel
        {
            get => secondEnabledLabel;
            set => this.RaiseAndSetIfChanged(ref secondEnabledLabel, value);
        }
        public bool ThirdEnabledLabel
        {
            get => thirdEnabledLabel;
            set => this.RaiseAndSetIfChanged(ref thirdEnabledLabel, value);
        }

        public IScreen HostScreen { get; }

        public UA_ENWordViewModel(RoutingState Router, GenericDataService<Word> dataService, Queue<Word> queue, List<(Word, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Word word = queue.Dequeue();

            ENWord = word.ENWord;
            UAWord = word.UAWord;
            SecondForm = word.SecondForm;
            ThirdForm = word.ThirdForm;

            if (string.IsNullOrEmpty(SecondForm))
                SecondEnabled = false;
            if (string.IsNullOrEmpty(ThirdForm))
                ThirdEnabled = false;

            IObservable<bool> canExecute = this
                .WhenAnyValue(x => x.UserENWord,
                    (userENWord) => !string.IsNullOrEmpty(userENWord));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.WordEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = userENWord == ENWord && UserSecondForm == SecondForm && UserThirdForm == ThirdForm;
                WordEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    word.CompletedUAEN++;
                else
                    word.FailedUAEN++;

                await dataService.Update(word);

                comletedList.Add((word, StyleCompleted));

                if (!string.IsNullOrEmpty(SecondForm))
                    SecondEnabledLabel = true;
                if (!string.IsNullOrEmpty(ThirdForm))
                    ThirdEnabledLabel = true;

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UA_ENWordViewModel(Router, dataService, queue, comletedList));
                return Router.Navigate.Execute(new ResultWordViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
