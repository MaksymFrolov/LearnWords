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
    public class UaEnSentenceViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "UaEnSentence";

        public ReactiveCommand<Unit, Unit> Start { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

        string enSentence, uaSentence, userENSentence;
        bool styleCompleted, textEnabled = true, sentenceEnabled = false;

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
        public string UserENSentence
        {
            get => userENSentence;
            set => this.RaiseAndSetIfChanged(ref userENSentence, value);
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
        public bool SentenceEnabled
        {
            get => sentenceEnabled;
            set => this.RaiseAndSetIfChanged(ref sentenceEnabled, value);
        }

        public IScreen HostScreen { get; }

        public UaEnSentenceViewModel(RoutingState Router, GenericDataService<Sentence> dataService, Queue<Sentence> queue, List<(Sentence, bool)> comletedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Sentence sentence = queue.Dequeue();

            ENSentence = sentence.ENSentence;
            UASentence = sentence.UASentence;

            IObservable<bool> canExecute = this
                .WhenAnyValue(x => x.UserENSentence,
                    (userENSentence) => !string.IsNullOrEmpty(userENSentence));
            IObservable<bool> canNext = this.WhenAnyValue(x => x.SentenceEnabled);

            Start = ReactiveCommand.CreateFromTask(async () =>
            {
                StyleCompleted = UserENSentence == ENSentence;
                SentenceEnabled = true;
                TextEnabled = false;

                if (StyleCompleted)
                    sentence.CompletedUAEN++;
                else
                    sentence.FailedUAEN++;

                await dataService.Update(sentence);

                comletedList.Add((sentence, StyleCompleted));

                Start.Dispose();
            }, canExecute);

            Start.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Next = ReactiveCommand.CreateFromObservable(() =>
            {
                if (comletedList.Count != 10)
                    return Router.Navigate.Execute(new UaEnSentenceViewModel(Router, dataService, queue, comletedList));
                return Router.Navigate.Execute(new ResultSentenceViewModel(Router, dataService, comletedList));
            }, canNext);

            Next.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
