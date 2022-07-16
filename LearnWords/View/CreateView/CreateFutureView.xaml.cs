using LearnWords.ViewModel.CreateViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.CreateView
{
    /// <summary>
    /// Логика взаимодействия для CreateFutureView.xaml
    /// </summary>
    public partial class CreateFutureView : ReactiveUserControl<CreateFutureViewModel>, IComponentConnector
    {
        public CreateFutureView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENFutureSimple, x => x.ENFutureSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfect, x => x.ENFuturePerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFutureContinuous, x => x.ENFutureContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfectContinuous, x => x.ENFuturePerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAFuture, x => x.UAFutureTextBox.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.DoneButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
