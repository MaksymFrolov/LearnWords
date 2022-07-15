using Microsoft.EntityFrameworkCore;
using System;


namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENFutureSimple", IsUnique = true, Name = "FutureSentence_Index")]
    public class FutureSentence : Promotion
    {
        public string ENFutureSimple { get; set; }

        public string? ENFutureContinuous { get; set; }

        public string? ENFuturePerfect { get; set; }

        public string? ENFuturePerfectContinuous { get; set; }

        public string UAFuture { get; set; }
    }
}
