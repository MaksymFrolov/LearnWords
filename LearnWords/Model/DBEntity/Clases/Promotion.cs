namespace LearnWords.Model.DBEntity.Clases
{
    public class Promotion
    {
        public int Id { get; set; }

        public int CompletedENUA { get; set; } = 0;

        public int FailedENUA { get; set; } = 0;

        public int CompletedUAEN { get; set; } = 0;

        public int FailedUAEN { get; set; } = 0;

        public int SuccesENUA => CompletedENUA - FailedENUA;
        public int SuccesUAEN => CompletedUAEN - FailedUAEN;
    }
}
