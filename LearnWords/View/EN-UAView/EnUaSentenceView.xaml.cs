using LearnWords.ViewModel.EN_UAViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.EN_UAView
{
    /// <summary>
    /// Логика взаимодействия для EnUaSentenceView.xaml
    /// </summary>
    public partial class EnUaSentenceView : ReactiveUserControl<EnUaSentenceViewModel>, IComponentConnector
    {
        public EnUaSentenceView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENSentence, x => x.ENCentenceLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UASentence, x => x.UASentenceLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UASentenceEnabled, x => x.UASentenceLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserUASentence, x => x.UASentenceTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.UASentenceTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
