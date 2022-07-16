using LearnWords.ViewModel.RedactionViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Markup;


namespace LearnWords.View.RedactionView
{
    /// <summary>
    /// Логика взаимодействия для RedactionSentenceView.xaml
    /// </summary>
    public partial class RedactionSentenceView : ReactiveUserControl<RedactionSentenceViewModel>, IComponentConnector
    {
        public RedactionSentenceView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, x => x.ListResult, x => x.List.ItemsSource)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.SelectedRow, x => x.List.SelectedItem)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Add, x => x.AddButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Update, x => x.UpdateButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Clear, x => x.ClearButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
