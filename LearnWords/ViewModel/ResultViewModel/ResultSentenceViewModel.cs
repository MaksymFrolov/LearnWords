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
    public class ResultSentenceViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultSentence";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        readonly List<Sentence> listResult;

        public List<Sentence> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultSentenceViewModel(RoutingState Router, GenericDataService<Sentence> dataService, List<(Sentence, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList.Select(t => t.Item1).ToList();

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataSentenceService: dataService)));

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
