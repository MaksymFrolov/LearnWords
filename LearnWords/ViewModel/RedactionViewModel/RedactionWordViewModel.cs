using DynamicData;
using DynamicData.Binding;
using LearnWords.Model.CRUD;
using LearnWords.Model.DBEntity.Clases;
using LearnWords.ViewModel.CreateViewModel;
using LearnWords.ViewModel.UpdateViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearnWords.ViewModel.RedactionViewModel
{
    internal class RedactionWordViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "RedactionWord";

        public ReactiveCommand<Unit, IRoutableViewModel> Add { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> Update { get; }
        public ReactiveCommand<Unit, Unit> Clear { get; }

        bool CanClear;

        Word selectedRow = new();
        public Word SelectedRow
        {
            get => selectedRow;
            set => this.RaiseAndSetIfChanged(ref selectedRow, value);
        }

        readonly ReadOnlyObservableCollection<Word> listResult;
        public ReadOnlyObservableCollection<Word> ListResult => listResult;

        ObservableCollectionExtended<Word> Source { get; }

        public IScreen HostScreen { get; }

        public RedactionWordViewModel(RoutingState Router, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Source = new ObservableCollectionExtended<Word>(DataWord.ReadData());
            Source.ToObservableChangeSet()
                .Bind(out listResult)
                .Subscribe();

            IObservable<bool> canClear =
               this.WhenAnyValue(x => x.SelectedRow)
                   .Select(row => row is not null);
            canClear
                .Subscribe(x => CanClear = x);

            Add = ReactiveCommand.CreateFromObservable(() =>
            {
                return Router.Navigate.Execute(new CreateWordViewModel(Router));
            });

            Add.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Update = ReactiveCommand.CreateFromTask(async () =>
            {
                List<Word> list = new();

                await Task.Run(() =>
                {
                    while (CanClear)
                    {
                        list.Add(SelectedRow);
                        Source.Remove(SelectedRow);
                    }
                });

                return await Router.Navigate.Execute(new UpdateWordViewModel(Router, list));
            }, canClear);

            Update.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            Clear = ReactiveCommand.CreateFromTask(async () =>
            {
                await Task.Run(() =>
                {
                    while (CanClear)
                    {
                        DataWord.DeleteData(SelectedRow);
                        Source.Remove(SelectedRow);
                    }
                });
            }, canClear);

            Clear.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
