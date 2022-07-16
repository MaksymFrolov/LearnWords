using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.ResultViewModel
{
    public class ResultFutureViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultFuture";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        readonly List<FutureSentence> listResult;

        public List<FutureSentence> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultFutureViewModel(RoutingState Router, GenericDataService<FutureSentence> dataService, List<(FutureSentence, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList.Select(t => t.Item1).ToList();

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataFutureService: dataService)));

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
