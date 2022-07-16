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
    public class EnUaSentenceViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "EnUaSentence";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enSentence, uaSentence, userUASentence;
        bool styleCompleted, textEnabled = true, uaSentenceEnabled = false;

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
        public string UserUASentence
        {
            get => userUASentence;
            set => this.RaiseAndSetIfChanged(ref userUASentence, value);
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
        public bool UASentenceEnabled
        {
            get => uaSentenceEnabled;
            set => this.RaiseAndSetIfChanged(ref uaSentenceEnabled, value);
        }

        public IScreen HostScreen { get; }

        public EnUaSentenceViewModel(RoutingState Router, GenericDataService<Sentence> dataService, Queue<Sentence> queue, List<(Sentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Sentence sentence = queue.Dequeue();

            ENSentence = sentence.ENSentence;
            UASentence = sentence.UASentence;

            IObservable<bool> canExecute =
                this.WhenAnyValue(x => x.UserUASentence,
                (userUASentence) =>
                   !string.IsNullOrEmpty(userUASentence));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.UASentenceEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserUASentence == UASentence;
                UASentenceEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    sentence.CompletedENUA++;
                else
                    sentence.FailedENUA++;

                await dataService.Update(sentence);

                comletedList.Add((sentence, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                if (comletedList.Count != 10)
                    return await Router.Navigate.Execute(new EnUaSentenceViewModel(Router, dataService, queue, comletedList));
                return await Router.Navigate.Execute(new ResultSentenceViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
