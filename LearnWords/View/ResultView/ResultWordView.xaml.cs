﻿using LearnWords.ViewModel.ResultViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.ResultView
{
    /// <summary>
    /// Логика взаимодействия для ResultWordView.xaml
    /// </summary>
    public partial class ResultWordView : ReactiveUserControl<ResultWordViewModel>, IComponentConnector
    {
        public ResultWordView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, x => x.ListResult, x => x.List.ItemsSource)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.GoMain, x => x.GoMainButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
