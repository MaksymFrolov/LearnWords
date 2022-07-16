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
    public class ResultPastViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultPast";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        readonly List<PastSentence> listResult;

        public List<PastSentence> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultPastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, List<(PastSentence, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList.Select(t => t.Item1).ToList();

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataPastService: dataService)));

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
