using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.UA_ENView
{
    /// <summary>
    /// Логика взаимодействия для UaEnFutureView.xaml
    /// </summary>
    public partial class UaEnFutureView : ReactiveUserControl<UaEnFutureViewModel>, IComponentConnector
    {
        public UaEnFutureView()
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
                this.Bind(ViewModel, x => x.FutureEnabled, x => x.ENFutureSimpleTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.FutureContinuousEnabled, x => x.ENFutureContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.FuturePerfectEnabled, x => x.ENFuturePerfectTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.FuturePerfectContinuousEnabled, x => x.ENFuturePerfectContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserENFutureSimple, x => x.ENFutureSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserFutureContinuous, x => x.ENFutureContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserFuturePerfect, x => x.ENFuturePerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserFuturePerfectContinuous, x => x.ENFuturePerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENFutureSimpleTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENFutureContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENFuturePerfectTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENFuturePerfectContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
