using LearnWords.ViewModel.CreateViewModel;
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

namespace LearnWords.View.CreateView
{
    /// <summary>
    /// Логика взаимодействия для CreateSentenceView.xaml
    /// </summary>
    public partial class CreateSentenceView : ReactiveUserControl<CreateSentenceViewModel>, IComponentConnector
    {
        public CreateSentenceView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.ENSentence, x => x.ENSentenceTextBox.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.UASentence, x => x.UASentenceTextBox.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.Start, x => x.DoneButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
