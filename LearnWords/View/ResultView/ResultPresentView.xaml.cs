﻿using LearnWords.ViewModel.ResultViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.ResultView
{
    /// <summary>
    /// Логика взаимодействия для ResultPresentView.xaml
    /// </summary>
    public partial class ResultPresentView : ReactiveUserControl<ResultPresentViewModel>, IComponentConnector
    {
        public ResultPresentView()
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
