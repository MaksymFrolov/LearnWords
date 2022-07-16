using LearnWords.ViewModel.EN_UAViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.EN_UAView
{
    /// <summary>
    /// Логика взаимодействия для EnUaFutureView.xaml
    /// </summary>
    public partial class EnUaFutureView : ReactiveUserControl<EnUaFutureViewModel>, IComponentConnector
    {
        public EnUaFutureView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENFutureSimple, x => x.ENFutureSimpleLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFutureContinuous, x => x.ENFutureContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfect, x => x.ENFuturePerfectLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfectContinuous, x => x.ENFuturePerfectContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAFuture, x => x.UAFutureLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAFutureEnabled, x => x.UAFutureLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFutureContinuousEnabled, x => x.ENFutureContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfectEnabled, x => x.ENFuturePerfectLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENFuturePerfectContinuousEnabled, x => x.ENFuturePerfectContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserUaFuture, x => x.UAFutureTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.UAFutureTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
