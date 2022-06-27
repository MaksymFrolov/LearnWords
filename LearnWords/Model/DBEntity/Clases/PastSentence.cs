using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENPastSimple", IsUnique = true, Name = "PastSentence_Index")]
    internal class PastSentence : Promotion
    {
        public int Id { get; set; }

        public string ENPastSimple { get; set; }

        public string? ENPastContinuous { get; set; }

        public string? ENPastPerfect { get; set; }

        public string? ENPastPerfectContinuous { get; set; }

        public string UAPastSimple { get; set; }

        public string? UAPastContinuous { get; set; }

        public string? UAPastPerfect { get; set; }

        public string? UAPastPerfectContinuous { get; set; }
    }
}
