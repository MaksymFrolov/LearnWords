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

                this.Bind(ViewModel, x => x.CountPast, x => x.CountPastLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AveragePastEn, x => x.AveragePastEnLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AveragePastUa, x => x.AveragePastUaLabel.Content)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartPastEN_UA, x => x.PastEnButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartPastUA_EN, x => x.PastUaButton)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, x => x.CountPresent, x => x.CountPresentLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AveragePresentEn, x => x.AveragePresentEnLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AveragePresentUa, x => x.AveragePresentUaLabel.Content)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartPresentEN_UA, x => x.PresentEnButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartPresentUA_EN, x => x.PresentUaButton)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, x => x.CountFuture, x => x.CountFutureLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageFutureEn, x => x.AverageFutureEnLabel.Content)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, x => x.AverageFutureUa, x => x.AverageFutureUaLabel.Content)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartFutureEN_UA, x => x.FutureEnButton)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.StartFutureUA_EN, x => x.FutureUaButton)
                    .DisposeWith(disposable);
            });
        }
    }
}
