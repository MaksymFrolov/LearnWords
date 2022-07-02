using LearnWords.Model.DBEntity.Clases;
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
    internal class EN_UAWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EN-UA";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enWord, uaWord, userUAWord, secondForm = "", thirdForm = "";
        bool styleCompleted, completed = false, textEnabled=true, uaWordEnabled = false;

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

        readonly ObservableAsPropertyHelper<bool> visibleSecond;
        public bool VisibleSecond => visibleSecond.Value;
        readonly ObservableAsPropertyHelper<bool> visibleThird;
        public bool VisibleThird => visibleThird.Value;

        public IScreen HostScreen { get; }

        public EN_UAWordViewModel(RoutingState Router, Queue<Word> queue, List<(Word,bool)> comletedList,IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Word word = queue.Dequeue();

            ENWord = word.ENWord;
            UAWord = word.UAWord;
            SecondForm = word.SecondForm;
            ThirdForm = word.ThirdForm;

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
            IObservable<bool> canNext = this.WhenAnyValue(x => x.Completed);
            IObservable<bool> canStart = this.WhenAnyValue(x => !x.Completed);

            Start = ReactiveCommand.Create(() =>
            {
                StyleCompleted = UserUAWord == UAWord;
                UAWordEnabled = true;
                TextEnabled = false;
                Completed = true;
                comletedList.Add((word, StyleCompleted));
            }, Observable.Concat(canExecute, canStart));

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if(comletedList.Count != 10)
                    return Router.Navigate.Execute(new EN_UAWordViewModel(Router, queue, comletedList));
                return Router.Navigate.Execute(new ResultWordViewModel(Router, comletedList));
            }, canNext);
        }
    }
}
