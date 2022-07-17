using LearnWords.ViewModel;
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

namespace LearnWords.View
{
    /// <summary>
    /// Логика взаимодействия для DefaultView.xaml
    /// </summary>
    public partial class DefaultView : ReactiveUserControl<DefaultViewModel>, IComponentConnector
    {
        public DefaultView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.CountWords, x => x.CountWordLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageWordsEn, x => x.AverageWordEnLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageWordsUa, x => x.AverageWordUaLabel.Content)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartWordEN_UA, x => x.WordEnButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartWordUA_EN, x => x.WordUaButton)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, x => x.CountSentence, x => x.CountSentenceLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageSentenceEn, x => x.AverageSentenceEnLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageSentenceUa, x => x.AverageSentenceUaLabel.Content)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartSentenceEN_UA, x => x.SentenceEnButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartSentenceUA_EN, x => x.SentenceUaButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
