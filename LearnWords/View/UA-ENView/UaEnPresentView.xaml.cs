using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.UA_ENView
{
    /// <summary>
    /// Логика взаимодействия для UaEnPresentView.xaml
    /// </summary>
    public partial class UaEnPresentView : ReactiveUserControl<UaEnPresentViewModel>, IComponentConnector
    {
        public UaEnPresentView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENPresentSimple, x => x.ENPresentSimpleLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentContinuous, x => x.ENPresentContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfect, x => x.ENPresentPerfectLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfectContinuous, x => x.ENPresentPerfectContinuousLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAPresent, x => x.UAPresentLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentEnabled, x => x.ENPresentSimpleLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentContinuousCorrectEnabled, x => x.ENPresentContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentPerfectContinuousCorrectEnabled, x => x.ENPresentPerfectContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentPerfectCorrectEnabled, x => x.ENPresentPerfectLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentContinuousEnabled, x => x.ENPresentContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentPerfectEnabled, x => x.ENPresentPerfectTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.PresentPerfectContinuousEnabled, x => x.ENPresentPerfectContinuousTextBox.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserENPresentSimple, x => x.ENPresentSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPresentContinuous, x => x.ENPresentContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPresentPerfect, x => x.ENPresentPerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserPresentPerfectContinuous, x => x.ENPresentPerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPresentSimpleTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPresentContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPresentPerfectTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.ENPresentPerfectContinuousTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
