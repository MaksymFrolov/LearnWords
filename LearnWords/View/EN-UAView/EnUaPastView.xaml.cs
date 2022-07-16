using LearnWords.ViewModel.EN_UAViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.EN_UAView
{
    /// <summary>
    /// Логика взаимодействия для EnUaPastView.xaml
    /// </summary>
    public partial class EnUaPastView : ReactiveUserControl<EnUaPastViewModel>, IComponentConnector
    {
        public EnUaPastView()
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
                this.Bind(ViewModel, x => x.UAPastEnabled, x => x.UAPastLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastContinuousEnabled, x => x.ENPastContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfectEnabled, x => x.ENPastPerfectLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfectContinuousEnabled, x => x.ENPastPerfectContinuousLabel.Visibility)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UserUaPast, x => x.UAPastTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.TextEnabled, x => x.UAPastTextBox.IsEnabled)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.StartButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Next, x => x.NextButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
