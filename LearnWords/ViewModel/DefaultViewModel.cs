using LearnWords.Model.DBEntity;
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

namespace LearnWords.ViewModel
{
    public class DefaultViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Default";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartWordEN_UA { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartWordUA_EN { get; }

        string countWords, averageWordsUa, averageWordsEn;

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

        public DefaultViewModel(RoutingState Router, 
            GenericDataService<Word> dataWordService = null, 
            GenericDataService<Sentence> dataSentenceService = null, 
            GenericDataService<FutureSentence> dataFutureService = null,
            GenericDataService<PastSentence> dataPastService = null,
            GenericDataService<PresentSentence> dataPresentService = null,
            IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            ReactiveCommand.CreateFromTask(async () =>
            {
                var list = await dataWordService.GetAll();
                CountWords = $"Amount: {list.Count()}";
                AverageWordsEn = $"Average: {Math.Round(list.Average(t => t.SuccesENUA),2)}";
                AverageWordsUa = $"Average: {Math.Round(list.Average(t => t.SuccesUAEN),2)}";
            }).Execute();

            StartWordEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });

            StartWordUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });
        }
    }
}
