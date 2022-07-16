using LearnWords.ViewModel.CreateViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;

namespace LearnWords.View.CreateView
{
    /// <summary>
    /// Логика взаимодействия для CreatePresentView.xaml
    /// </summary>
    public partial class CreatePresentView : ReactiveUserControl<CreatePresentViewModel>, IComponentConnector
    {
        public CreatePresentView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENPresentSimple, x => x.ENPresentSimpleTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfect, x => x.ENPresentPerfectTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentContinuous, x => x.ENPresentContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.ENPresentPerfectContinuous, x => x.ENPresentPerfectContinuousTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UAPresent, x => x.UAPresentTextBox.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.DoneButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
