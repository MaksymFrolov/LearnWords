namespace LearnWords.Model.DBEntity.Clases
{
    internal abstract class Promotion
    {
        public int CompletedENUA { get; set; } = 0;

        public int FailedENUA { get; set; } = 0;

        public int CompletedUAEN { get; set; } = 0;

        public int FailedUAEN { get; set; } = 0;

        public int SuccesENUA() => CompletedENUA - FailedENUA;
        public int SuccesUAEN() => CompletedUAEN - FailedUAEN;
    }
}
