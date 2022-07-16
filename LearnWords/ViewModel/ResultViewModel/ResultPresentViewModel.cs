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
    public class ResultPresentViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultPresent";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        readonly List<PresentSentence> listResult;

        public List<PresentSentence> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultPresentViewModel(RoutingState Router, GenericDataService<PresentSentence> dataService, List<(PresentSentence, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList.Select(t => t.Item1).ToList();

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataPresentService: dataService)));

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
