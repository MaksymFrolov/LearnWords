using LearnWords.Model.DBEntity.Clases;
using LearnWords.Model.Service;
using LearnWords.View;
using LearnWords.View.CreateView;
using LearnWords.View.EN_UAView;
using LearnWords.View.RedactionView;
using LearnWords.View.ResultView;
using LearnWords.View.UA_ENView;
using LearnWords.ViewModel.CreateViewModel;
using LearnWords.ViewModel.EN_UAViewModel;
using LearnWords.ViewModel.RedactionViewModel;
using LearnWords.ViewModel.ResultViewModel;
using LearnWords.ViewModel.UA_ENViewModel;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace LearnWords.ViewModel
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoMain { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionWord { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ENUAWord { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> UAENWord { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionFuture { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ENUAFuture { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> UAENFuture { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionPresent { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ENUAPresent { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> UAENPresent { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionPast { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ENUAPast { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> UAENPast { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> OpenRedactionSentence { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> ENUASentence { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> UAENSentence { get; }

        readonly GenericDataService<Word> dataWordService;
        readonly GenericDataService<Sentence> dataSentenceService;
        readonly GenericDataService<FutureSentence> dataFutureService;
        readonly GenericDataService<PastSentence> dataPastService;
        readonly GenericDataService<PresentSentence> dataPresentService;

        string title = "Learn Words";
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }

        public MainViewModel()
        {
            Router = new();

            dataWordService = new(new());
            dataSentenceService = new(new());
            dataFutureService = new(new());
            dataPastService = new(new());
            dataPresentService = new(new());

            Locator.CurrentMutable.Register(() => new CreateWordView(), typeof(IViewFor<CreateWordViewModel>));
            Locator.CurrentMutable.Register(() => new EN_UAWordView(), typeof(IViewFor<EN_UAWordViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionWordView(), typeof(IViewFor<RedactionWordViewModel>));
            Locator.CurrentMutable.Register(() => new ResultWordView(), typeof(IViewFor<ResultWordViewModel>));
            Locator.CurrentMutable.Register(() => new UA_ENWordView(), typeof(IViewFor<UA_ENWordViewModel>));
            Locator.CurrentMutable.Register(() => new DefaultView(), typeof(IViewFor<DefaultViewModel>));

            Locator.CurrentMutable.Register(() => new CreateSentenceView(), typeof(IViewFor<CreateSentenceViewModel>));
            Locator.CurrentMutable.Register(() => new EnUaSentenceView(), typeof(IViewFor<EnUaSentenceViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionSentenceView(), typeof(IViewFor<RedactionSentenceViewModel>));
            Locator.CurrentMutable.Register(() => new ResultSentenceView(), typeof(IViewFor<ResultSentenceViewModel>));
            Locator.CurrentMutable.Register(() => new UaEnSentenceView(), typeof(IViewFor<UaEnSentenceViewModel>));

            Locator.CurrentMutable.Register(() => new CreatePastView(), typeof(IViewFor<CreatePastViewModel>));
            Locator.CurrentMutable.Register(() => new EnUaPastView(), typeof(IViewFor<EnUaPastViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionPastView(), typeof(IViewFor<RedactionPastViewModel>));
            Locator.CurrentMutable.Register(() => new ResultPastView(), typeof(IViewFor<ResultPastViewModel>));
            Locator.CurrentMutable.Register(() => new UaEnPastView(), typeof(IViewFor<UaEnPastViewModel>));

            Locator.CurrentMutable.Register(() => new CreatePresentView(), typeof(IViewFor<CreatePresentViewModel>));
            Locator.CurrentMutable.Register(() => new EnUaPresentView(), typeof(IViewFor<EnUaPresentViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionPresentView(), typeof(IViewFor<RedactionPresentViewModel>));
            Locator.CurrentMutable.Register(() => new ResultPresentView(), typeof(IViewFor<ResultPresentViewModel>));
            Locator.CurrentMutable.Register(() => new UaEnPresentView(), typeof(IViewFor<UaEnPresentViewModel>));

            Locator.CurrentMutable.Register(() => new CreateFutureView(), typeof(IViewFor<CreateFutureViewModel>));
            Locator.CurrentMutable.Register(() => new EnUaFutureView(), typeof(IViewFor<EnUaFutureViewModel>));
            Locator.CurrentMutable.Register(() => new RedactionFutureView(), typeof(IViewFor<RedactionFutureViewModel>));
            Locator.CurrentMutable.Register(() => new ResultFutureView(), typeof(IViewFor<ResultFutureViewModel>));
            Locator.CurrentMutable.Register(() => new UaEnFutureView(), typeof(IViewFor<UaEnFutureViewModel>));

            GoMain = ReactiveCommand.CreateFromTask(async () => await Router.Navigate.Execute(new DefaultViewModel(Router, dataWordService, dataSentenceService, dataFutureService, dataPastService, dataPresentService)));
            GoMain.Execute();

            OpenRedactionWord = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionWordViewModel(Router, dataWordService)));
            ENUAWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EN_UAWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });
            UAENWord = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Word> queue = new(await dataWordService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UA_ENWordViewModel(Router, dataWordService, queue, new List<(Word, bool)>()));
            });
            ENUAWord.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
            UAENWord.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            OpenRedactionFuture = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionFutureViewModel(Router, dataFutureService)));
            ENUAFuture = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<FutureSentence> queue = new(await dataFutureService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaFutureViewModel(Router, dataFutureService, queue, new List<(FutureSentence, bool)>()));
            });
            UAENFuture = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<FutureSentence> queue = new(await dataFutureService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnFutureViewModel(Router, dataFutureService, queue, new List<(FutureSentence, bool)>()));
            });
            ENUAFuture.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
            UAENFuture.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            OpenRedactionPresent = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionPresentViewModel(Router, dataPresentService)));
            ENUAPresent = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PresentSentence> queue = new(await dataPresentService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaPresentViewModel(Router, dataPresentService, queue, new List<(PresentSentence, bool)>()));
            });
            UAENPresent = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PresentSentence> queue = new(await dataPresentService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnPresentViewModel(Router, dataPresentService, queue, new List<(PresentSentence, bool)>()));
            });
            ENUAPresent.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
            UAENPresent.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            OpenRedactionPast = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionPastViewModel(Router, dataPastService)));
            ENUAPast = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PastSentence> queue = new(await dataPastService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaPastViewModel(Router, dataPastService, queue, new List<(PastSentence, bool)>()));
            });
            UAENPast = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<PastSentence> queue = new(await dataPastService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnPastViewModel(Router, dataPastService, queue, new List<(PastSentence, bool)>()));
            });
            ENUAPast.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
            UAENPast.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));

            OpenRedactionSentence = ReactiveCommand.CreateFromTask(async () => await Router.NavigateAndReset.Execute(new RedactionSentenceViewModel(Router, dataSentenceService)));
            ENUASentence = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Sentence> queue = new(await dataSentenceService.GetTen(true));

                return await Router.NavigateAndReset.Execute(new EnUaSentenceViewModel(Router, dataSentenceService, queue, new List<(Sentence, bool)>()));
            });
            UAENSentence = ReactiveCommand.CreateFromTask(async () =>
            {
                Queue<Sentence> queue = new(await dataSentenceService.GetTen(false));

                return await Router.NavigateAndReset.Execute(new UaEnSentenceViewModel(Router, dataSentenceService, queue, new List<(Sentence, bool)>()));
            });
            ENUASentence.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
            UAENSentence.ThrownExceptions.Subscribe(exception => MessageBox.Show($"Виникла помилка: {exception.Message}"));
        }
    }
}
