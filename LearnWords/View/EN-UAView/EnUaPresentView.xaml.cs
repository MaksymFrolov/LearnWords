using LearnWords.ViewModel.EN_UAViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.EN_UAView
{
    /// <summary>
    /// Логика взаимодействия для EnUaPresentView.xaml
    /// </summary>
    public partial class EnUaPresentView : ReactiveUserControl<EnUaPresentViewModel>, IComponentConnector
    {
        public EnUaPresentView()
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
                this.Bind(ViewModel, x => x.UAPresentEnabled, x => x.UAPresentLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentContinuousEnabled, x => x.ENPresentContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfectEnabled, x => x.ENPresentPerfectLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfectContinuousEnabled, x => x.ENPresentPerfectContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserUaPresent, x => x.UAPresentTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.UAPresentTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
