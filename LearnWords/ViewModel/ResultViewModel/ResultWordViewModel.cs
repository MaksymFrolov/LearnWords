using LearnWords.Model.DBEntity.Clases;
using LearnWords.ViewModel.CreateViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace LearnWords.ViewModel.ResultViewModel
{
    internal class ResultWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultWord";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        private readonly List<(Word, bool)> listResult;

        public List<(Word, bool)> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultWordViewModel(RoutingState Router, List<(Word, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList;

            GoMain = ReactiveCommand.CreateFromObservable(() =>
            {
                return Router.NavigateBack.Execute(Unit.Default);
            });

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
