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

        readonly GenericDataService<Word> dataService;

        string title = "Learn Words";
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        public MainViewModel()
        {
            Router = new RoutingState();
            dataService = new GenericDataService<Word>(new ContextAppFactory());

            Locator.CurrentMutable.Register(() => new CreateWordView(), typeof(IViewFor<CreateWordViewModel>));
            Locator.CurrentMutable.Register(() => new EN_UAWordView(), typeof(IViewFor<EN_UAWordViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionWordView(), typeof(IViewFor<RedactionWordViewModel>));
            Locator.CurrentMutable.Register(() => new ResultWordView(), typeof(IViewFor<ResultWordViewModel>));
            Locator.CurrentMutable.Register(() => new UA_ENWordView(), typeof(IViewFor<UA_ENWordViewModel>));
            Locator.CurrentMutable.Register(() => new DefaultView(), typeof(IViewFor<DefaultViewModel>));

            Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataService));

            OpenRedactionWord = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router, dataService)));

            ENUAWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, dataService, queue, new List<(Word, bool)>()));
            });

            UAENWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, dataService, queue, new List<(Word, bool)>()));
            });
        }
    }
}
