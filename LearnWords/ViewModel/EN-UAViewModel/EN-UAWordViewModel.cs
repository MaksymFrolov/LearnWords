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

namespace LearnWords.ViewModel.EN_UAViewModel
{
    public class EN_UAWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EN-UA";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enWord, uaWord, userUAWord, secondForm = "", thirdForm = "";
        bool styleCompleted, textEnabled = true, uaWordEnabled = false, secondEnabled = true, thirdEnabled = true;

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
        public string UserUAWord
        {
            get => userUAWord;
            set => this.RaiseAndSetIfChanged(ref userUAWord, value);
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
        public bool UAWordEnabled
        {
            get => uaWordEnabled;
            set => this.RaiseAndSetIfChanged(ref uaWordEnabled, value);
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

        readonly ObservableAsPropertyHelper<bool> visibleSecond;
        public bool VisibleSecond => visibleSecond.Value;
        readonly ObservableAsPropertyHelper<bool> visibleThird;
        public bool VisibleThird => visibleThird.Value;

        public IScreen HostScreen { get; }

        public EN_UAWordViewModel(RoutingState Router, GenericDataService<Word> dataService, Queue<Word> queue, List<(Word, bool)> comletedList, IScreen screen = null)
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

            visibleSecond = this.WhenAnyValue(x => x.SecondForm,
                (secondForm) =>
                    !string.IsNullOrEmpty(secondForm)).ToProperty(this, x => x.VisibleSecond);
            visibleThird = this.WhenAnyValue(x => x.ThirdForm,
                (thirdForm) =>
                    !string.IsNullOrEmpty(thirdForm)).ToProperty(this, x => x.VisibleThird);

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserUAWord,
                (userUAWord) =>
                   !string.IsNullOrEmpty(userUAWord));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.UAWordEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserUAWord == UAWord;
                UAWordEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    word.CompletedENUA++;
                else
                    word.FailedENUA++;

                await dataService.Update(word);

                comletedList.Add((word, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                if (comletedList.Count != 10)
                    return await Router.Navigate.Execute(new EN_UAWordViewModel(Router, dataService, queue, comletedList));
                return await Router.Navigate.Execute(new ResultWordViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
