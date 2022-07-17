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

namespace LearnWords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>, IComponentConnector
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel=new MainViewModel();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.OpenRedactionWord, x => x.menuWordRedaction)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ENUAWord, x => x.menuWordENUA)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.UAENWord , x => x.menuWordUAEN)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoMain, x => x.menuGoMain)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.OpenRedactionSentence, x => x.menuSentenceRedaction)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ENUASentence, x => x.menuSentenceENUA)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.UAENSentence, x => x.menuSentenceUAEN)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.OpenRedactionFuture, x => x.menuFutureRedaction)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ENUAFuture, x => x.menuFutureENUA)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.UAENFuture, x => x.menuFutureUAEN)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.OpenRedactionPresent, x => x.menuPresentRedaction)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ENUAPresent, x => x.menuPresentENUA)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.UAENPresent, x => x.menuPresentUAEN)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.OpenRedactionPast, x => x.menuPastRedaction)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ENUAPast, x => x.menuPastENUA)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.UAENPast, x => x.menuPastUAEN)
                    .DisposeWith(disposables);
            });
        }
    }
}
