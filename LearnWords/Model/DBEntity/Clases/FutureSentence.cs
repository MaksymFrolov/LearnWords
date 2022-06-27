using Microsoft.EntityFrameworkCore;
using System;


namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENFutureSimple", IsUnique = true, Name = "FutureSentence_Index")]
    internal class FutureSentence : Promotion
    {
        public int Id { get; set; }

        public string ENFutureSimple { get; set; }

        public string? ENFutureContinuous { get; set; }

        public string? ENFuturePerfect { get; set; }

        public string? ENFuturePerfectContinuous { get; set; }

        public string UAFutureSimple { get; set; }

        public string? UAFutureContinuous { get; set; }

        public string? UAFuturePerfect { get; set; }

        public string? UAFuturePerfectContinuous { get; set; }
    }
}
