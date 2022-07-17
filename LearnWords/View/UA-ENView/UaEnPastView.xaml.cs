using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.UA_ENView
{
    /// <summary>
    /// Логика взаимодействия для UaEnPastView.xaml
    /// </summary>
    public partial class UaEnPastView : ReactiveUserControl<UaEnPastViewModel>, IComponentConnector
    {
        public UaEnPastView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENPastSimple, x => x.ENPastSimpleLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastContinuous, x => x.ENPastContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfect, x => x.ENPastPerfectLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfectContinuous, x => x.ENPastPerfectContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAPast, x => x.UAPastLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastEnabled, x => x.ENPastSimpleLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastContinuousCorrectEnabled, x => x.ENPastContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastPerfectContinuousCorrectEnabled, x => x.ENPastPerfectContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastPerfectCorrectEnabled, x => x.ENPastPerfectLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastContinuousEnabled, x => x.ENPastContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastPerfectEnabled, x => x.ENPastPerfectTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PastPerfectContinuousEnabled, x => x.ENPastPerfectContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserENPastSimple, x => x.ENPastSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPastContinuous, x => x.ENPastContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPastPerfect, x => x.ENPastPerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPastPerfectContinuous, x => x.ENPastPerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPastSimpleTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPastContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPastPerfectTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPastPerfectContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
