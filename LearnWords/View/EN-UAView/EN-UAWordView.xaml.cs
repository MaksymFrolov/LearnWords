﻿using LearnWords.ViewModel.EN_UAViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.EN_UAView
{
    /// <summary>
    /// Логика взаимодействия для EN_UAWordView.xaml
    /// </summary>
    public partial class EN_UAWordView : ReactiveUserControl<EN_UAWordViewModel>, IComponentConnector
    {
        public EN_UAWordView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENWord, x => x.ENWordLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.SecondForm, x => x.SecondFormLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ThirdForm, x => x.ThirdFormLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAWord, x => x.UAWordLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAWordEnabled, x => x.UAWordLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.SecondEnabled, x => x.SecondFormLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ThirdEnabled, x => x.ThirdFormLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserUAWord, x => x.UAWordTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.UAWordTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
