﻿using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.ViewModel.RedactionViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace LearnWords.ViewModel.ResultViewModel
{
    public class ResultWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ResultWord";

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        readonly List<Word> listResult;

        public List<Word> ListResult
        {
            get => listResult;
        }

        public IScreen HostScreen { get; }

        public ResultWordViewModel(RoutingState Router, GenericDataService<Word> dataService, List<(Word, bool)> completedList, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            listResult = completedList.Select(t=>t.Item1).ToList();

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new DefaultViewModel(Router, dataService)));

            GoMain.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
