using DynamicData;
using DynamicData.Binding;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.ViewModel.CreateViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.RedactionViewModel
{
    public class RedactionPastViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "RedactionPast";

        public ReactiveCommand<Unit, IRoutableViewModel> Add { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Update { get; }
        public ReactiveCommand<Unit, Unit> Clear { get; }

        bool CanClear;

        PastSentence selectedRow = new();
        public PastSentence SelectedRow
        {
            get => selectedRow;
            set => this.RaiseAndSetIfChanged(ref selectedRow, value);
        }

        readonly ReadOnlyObservableCollection<PastSentence> listResult;
        public ReadOnlyObservableCollection<PastSentence> ListResult => listResult;

        ObservableCollectionExtended<PastSentence> Source { get; }

        public IScreen HostScreen { get; }

        public RedactionPastViewModel(RoutingState Router, GenericDataService<PastSentence> dataService, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Source = new();
            Source.ToObservableChangeSet()
                    .Bind(out listResult)
                    .Subscribe();

            ReactiveCommand.CreateFromTask(async () =>
            {
                foreach (var data in await dataService.GetAll())
                    Source.Add(data);
            }).Execute();

            IObservable<bool> canClear =
               this.WhenAnyValue(x => x.SelectedRow)
                   .Select(row => row is not null);
            canClear
                .Subscribe(x => CanClear = x);

            Add = ReactiveCommand.CreateFromTask(async () => await Router.Navigate.Execute(new CreatePastViewModel(Router, dataService)));

            Add.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Update = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PastSentence> queue = new();

                while (CanClear)
                {
                    queue.Enqueue(SelectedRow);
                    Source.Remove(SelectedRow);
                }

                return await Router.Navigate.Execute(new CreatePastViewModel(Router, dataService, queue));
            }, canClear);

            Update.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Clear = ReactiveCommand.CreateFromTask(async () =>
            {
                while (CanClear)
                {
                    await dataService.Delete(SelectedRow);
                    Source.Remove(SelectedRow);
                }
            }, canClear);

            Clear.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
