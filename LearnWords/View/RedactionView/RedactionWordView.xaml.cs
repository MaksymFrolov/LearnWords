using LearnWords.ViewModel.RedactionViewModel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnWords.View.RedactionView
{
    /// <summary>
    /// Логика взаимодействия для RedactionWordView.xaml
    /// </summary>
    public partial class RedactionWordView : ReactiveUserControl<RedactionWordViewModel>, IComponentConnector
    {
        public RedactionWordView()
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
