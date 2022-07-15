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
using System.Text;
using System.Threading.Tasks;

namespace LearnWords.ViewModel
{
    public class DefaultViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Default";

        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartWordEN_UA { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> StartWordUA_EN { get; }

        public DefaultViewModel(RoutingState Router, GenericDataService<Word> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            StartWordEN_UA = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, dataService, queue, new List<(Word, bool)>()));
            });

            StartWordUA_EN = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, dataService, queue, new List<(Word, bool)>()));
            });
        }
    }
}
