using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.ViewModel.EN_UAViewModel;
using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace LearnWords.ViewModel
{
    public class DefaultViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Default";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartWordEN_UA { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> StartWordUA_EN { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartFutureEN_UA { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> StartFutureUA_EN { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartPastEN_UA { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> StartPastUA_EN { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartPresentEN_UA { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> StartPresentUA_EN { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartSentenceEN_UA { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> StartSentenceUA_EN { get; }

        #region strings

        string countWords, averageWordsUa, averageWordsEn;

        string countFuture, averageFutureUa, averageFutureEn;

        string countPast, averagePastUa, averagePastEn;

        string countPresent, averagePresentUa, averagePresentEn;

        string countSentence, averageSentenceUa, averageSentenceEn;

        public string CountWords
        {
            get => countWords;
            set => this.RaiseAndSetIfChanged(ref countWords, value);
        }
        public string AverageWordsUa
        {
            get => averageWordsUa;
            set => this.RaiseAndSetIfChanged(ref averageWordsUa, value);
        }
        public string AverageWordsEn
        {
            get => averageWordsEn;
            set => this.RaiseAndSetIfChanged(ref averageWordsEn, value);
        }

        public string CountFuture
        {
            get => countFuture;
            set => this.RaiseAndSetIfChanged(ref countFuture, value);
        }
        public string AverageFutureUa
        {
            get => averageFutureUa;
            set => this.RaiseAndSetIfChanged(ref averageFutureUa, value);
        }
        public string AverageFutureEn
        {
            get => averageFutureEn;
            set => this.RaiseAndSetIfChanged(ref averageFutureEn, value);
        }

        public string CountPast
        {
            get => countPast;
            set => this.RaiseAndSetIfChanged(ref countPast, value);
        }
        public string AveragePastUa
        {
            get => averagePastUa;
            set => this.RaiseAndSetIfChanged(ref averagePastUa, value);
        }
        public string AveragePastEn
        {
            get => averagePastEn;
            set => this.RaiseAndSetIfChanged(ref averagePastEn, value);
        }

        public string CountPresent
        {
            get => countPresent;
            set => this.RaiseAndSetIfChanged(ref countPresent, value);
        }
        public string AveragePresentUa
        {
            get => averagePresentUa;
            set => this.RaiseAndSetIfChanged(ref averagePresentUa, value);
        }
        public string AveragePresentEn
        {
            get => averagePresentEn;
            set => this.RaiseAndSetIfChanged(ref averagePresentEn, value);
        }

        public string CountSentence
        {
            get => countSentence;
            set => this.RaiseAndSetIfChanged(ref countSentence, value);
        }
        public string AverageSentenceUa
        {
            get => averageSentenceUa;
            set => this.RaiseAndSetIfChanged(ref averageSentenceUa, value);
        }
        public string AverageSentenceEn
        {
            get => averageSentenceEn;
            set => this.RaiseAndSetIfChanged(ref averageSentenceEn, value);
        }

        #endregion

        public DefaultViewModel(RoutingState Router,
            GenericDataService<Word> dataWordService = null,
            GenericDataService<Sentence> dataSentenceService = null,
            GenericDataService<FutureSentence> dataFutureService = null,
            GenericDataService<PastSentence> dataPastService = null,
            GenericDataService<PresentSentence> dataPresentService = null,
            IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            GenericDataService<Word> wordService = dataWordService ?? new(new());
            GenericDataService<Sentence> sentenceService = dataSentenceService ?? new(new());
            GenericDataService<FutureSentence> futureService = dataFutureService ?? new(new());
            GenericDataService<PastSentence> pastService = dataPastService ?? new(new());
            GenericDataService<PresentSentence> presentService = dataPresentService ?? new(new());

            #region commands

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await wordService.GetAll();
                CountWords = $"Amount: {list.Count()}";
                AverageWordsEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA), 2)}";
                AverageWordsUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN), 2)}";
            }).Execute();

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await sentenceService.GetAll();
                CountSentence = $"Amount: {list.Count()}";
                AverageSentenceEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA), 2)}";
                AverageSentenceUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN), 2)}";
            }).Execute();

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await futureService.GetAll();
                CountFuture = $"Amount: {list.Count()}";
                AverageFutureEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA), 2)}";
                AverageFutureUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN), 2)}";
            }).Execute();

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await pastService.GetAll();
                CountPast = $"Amount: {list.Count()}";
                AveragePastEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA), 2)}";
                AveragePastUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN), 2)}";
            }).Execute();

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await presentService.GetAll();
                CountPresent = $"Amount: {list.Count()}";
                AveragePresentEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA), 2)}";
                AveragePresentUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN), 2)}";
            }).Execute();

            StartWordEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await wordService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, wordService, queue, new List<(Word, bool)>()));
            });

            StartWordEN_UA.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartWordUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await wordService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, wordService, queue, new List<(Word, bool)>()));
            });

            StartWordUA_EN.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartFutureEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<FutureSentence> queue = new(await futureService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaFutureViewModel(Router, futureService, queue, new List<(FutureSentence, bool)>()));
            });

            StartFutureEN_UA.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartFutureUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<FutureSentence> queue = new(await futureService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnFutureViewModel(Router, futureService, queue, new List<(FutureSentence, bool)>()));
            });

            StartFutureUA_EN.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartPastEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PastSentence> queue = new(await pastService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaPastViewModel(Router, pastService, queue, new List<(PastSentence, bool)>()));
            });

            StartPastEN_UA.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartPastUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PastSentence> queue = new(await pastService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnPastViewModel(Router, pastService, queue, new List<(PastSentence, bool)>()));
            });

            StartPastUA_EN.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartPresentEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PresentSentence> queue = new(await presentService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaPresentViewModel(Router, presentService, queue, new List<(PresentSentence, bool)>()));
            });

            StartPresentEN_UA.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartPresentUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PresentSentence> queue = new(await presentService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnPresentViewModel(Router, presentService, queue, new List<(PresentSentence, bool)>()));
            });

            StartPresentUA_EN.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartSentenceEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Sentence> queue = new(await sentenceService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaSentenceViewModel(Router, sentenceService, queue, new List<(Sentence, bool)>()));
            });

            StartSentenceEN_UA.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            StartSentenceUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Sentence> queue = new(await sentenceService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnSentenceViewModel(Router, sentenceService, queue, new List<(Sentence, bool)>()));
            });

            StartSentenceUA_EN.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            #endregion
        }
    }
}
