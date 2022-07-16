using LearnWords.ViewModel.CreateViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.CreateView
{
    /// <summary>
    /// Логика взаимодействия для CreatePastView.xaml
    /// </summary>
    public partial class CreatePastView : ReactiveUserControl<CreatePastViewModel>, IComponentConnector
    {
        public CreatePastView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENPastSimple, x => x.ENPastSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfect, x => x.ENPastPerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastContinuous, x => x.ENPastContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPastPerfectContinuous, x => x.ENPastPerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAPast, x => x.UAPastTextBox.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.DoneButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
