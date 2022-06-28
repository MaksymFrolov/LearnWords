using LearnWords.Model.CRUD;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.ViewModel.CreateViewModel;
using LearnWords.ViewModel.EN_UAViewModel;
using LearnWords.ViewModel.RedactionViewModel;
using LearnWords.ViewModel.ResultViewModel;
using LearnWords.ViewModel.UA_ENViewModel;
using LearnWords.ViewModel.UpdateViewModel;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace LearnWords.ViewModel
{
    internal class MainViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionWord { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> ENUAWord { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> UAENWord { get; }

        string title = "Learn Words";
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        public MainViewModel()
        {
            Router = new RoutingState();

            Locator.CurrentMutable.Register(() => new CreateWordView(), typeof(IViewFor<CreateWordViewModel>));
            Locator.CurrentMutable.Register(() => new EN_UAWordView(), typeof(IViewFor<EN_UAWordViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionWordView(), typeof(IViewFor<RedactionWordViewModel>));
            Locator.CurrentMutable.Register(() => new ResultWordView(), typeof(IViewFor<ResultWordViewModel>));
            Locator.CurrentMutable.Register(() => new UA_ENWordView(), typeof(IViewFor<UA_ENWordViewModel>));
            Locator.CurrentMutable.Register(() => new UpdateWordView(), typeof(IViewFor<UpdateWordViewModel>));

            OpenRedactionWord = ReactiveCommand.CreateFromObservable(() =>
            {
                return Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router));
            });

            ENUAWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue=new();

                await Task.Run(() =>
                {
                    queue = DataWord.ReadTenData(true);
                });

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, queue));
            });

            UAENWord = ReactiveCommand.CreateFromObservable(() =>
            {
                return Router.NavigateAndReset.Execute(new UA_ENWordViewModel());
            });
        }
    }
}
