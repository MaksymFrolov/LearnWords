using LearnWords.Model.DBEntity;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.View;
using LearnWords.View.CreateView;
using LearnWords.View.EN_UAView;
using LearnWords.View.RedactionView;
using LearnWords.View.ResultView;
using LearnWords.View.UA_ENView;
using LearnWords.ViewModel.CreateViewModel;
using LearnWords.ViewModel.EN_UAViewModel;
using LearnWords.ViewModel.RedactionViewModel;
using LearnWords.ViewModel.ResultViewModel;
using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace LearnWords.ViewModel
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionWord { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> ENUAWord { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> UAENWord { get; }

        readonly GenericDataService<Word> dataWordService;
        readonly GenericDataService<Sentence> dataSentenceService;
        readonly GenericDataService<FutureSentence> dataFutureService;
        readonly GenericDataService<PastSentence> dataPastService;
        readonly GenericDataService<PresentSentence> dataPresentService;

        string title = "Learn Words";
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        public MainViewModel()
        {
            Router = new RoutingState();

            dataWordService = new GenericDataService<Word>(new ContextAppFactory());
            dataSentenceService = new GenericDataService<Sentence>(new ContextAppFactory());
            dataFutureService = new GenericDataService<FutureSentence>(new ContextAppFactory());
            dataPastService = new GenericDataService<PastSentence>(new ContextAppFactory());
            dataPresentService = new GenericDataService<PresentSentence>(new ContextAppFactory());

            Locator.CurrentMutable.Register(() => new CreateWordView(), typeof(IViewFor<CreateWordViewModel>));
            Locator.CurrentMutable.Register(() => new EN_UAWordView(), typeof(IViewFor<EN_UAWordViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionWordView(), typeof(IViewFor<RedactionWordViewModel>));
            Locator.CurrentMutable.Register(() => new ResultWordView(), typeof(IViewFor<ResultWordViewModel>));
            Locator.CurrentMutable.Register(() => new UA_ENWordView(), typeof(IViewFor<UA_ENWordViewModel>));
            Locator.CurrentMutable.Register(() => new DefaultView(), typeof(IViewFor<DefaultViewModel>));

            Router.Navigate.Execute(new DefaultViewModel(Router, dataWordService, dataSentenceService, dataFutureService, dataPastService, dataPresentService));

            OpenRedactionWord = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router, dataWordService)));

            ENUAWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });

            UAENWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });
        }
    }
}
