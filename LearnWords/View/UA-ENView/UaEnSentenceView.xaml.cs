using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.UA_ENView
{
    /// <summary>
    /// Логика взаимодействия для UaEnSentenceView.xaml
    /// </summary>
    public partial class UaEnSentenceView : ReactiveUserControl<UaEnSentenceViewModel>, IComponentConnector
    {
        public UaEnSentenceView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENSentence, x => x.ENCentenceLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UASentence, x => x.UASentenceLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.SentenceEnabled, x => x.ENCentenceLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserENSentence, x => x.ENSentenceTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENSentenceTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
