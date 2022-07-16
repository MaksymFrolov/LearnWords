using LearnWords.ViewModel.ResultViewModel;
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

namespace LearnWords.View.ResultView
{
    /// <summary>
    /// Логика взаимодействия для ResultSentenceView.xaml
    /// </summary>
    public partial class ResultSentenceView : ReactiveUserControl<ResultSentenceViewModel>, IComponentConnector
    {
        public ResultSentenceView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, x => x.ListResult, x => x.List.ItemsSource)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.GoMain, x => x.GoMainButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
