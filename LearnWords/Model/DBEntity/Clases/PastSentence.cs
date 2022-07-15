using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENPastSimple", IsUnique = true, Name = "PastSentence_Index")]
    public class PastSentence : Promotion
    {
        public string ENPastSimple { get; set; }

        public string? ENPastContinuous { get; set; }

        public string? ENPastPerfect { get; set; }

        public string? ENPastPerfectContinuous { get; set; }

        public string UAPast { get; set; }
    }
}
