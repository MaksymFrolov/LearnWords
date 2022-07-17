using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.UA_ENView
{
    /// <summary>
    /// Логика взаимодействия для UA_ENWordView.xaml
    /// </summary>
    public partial class UA_ENWordView : ReactiveUserControl<UA_ENWordViewModel>, IComponentConnector
    {
        public UA_ENWordView()
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
                this.Bind(ViewModel, x => x.WordEnabled, x => x.ENWordLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.SecondEnabled, x => x.SecondFormTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ThirdEnabled, x => x.ThirdFormTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserENWord, x => x.ENWordTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserSecondForm, x => x.SecondFormTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserThirdForm, x => x.ThirdFormTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENWordTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.SecondFormTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ThirdFormTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
