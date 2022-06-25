using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENPresentSimple", IsUnique = true, Name = "PresentSentence_Index")]
    internal class PresentSentence : Promotion
    {
        public int Id { get; set; }

        public string? ENPresentSimple { get; set; }

        public string? ENPresentContinuous { get; set; }

        public string? ENPresentPerfect { get; set; }

        public string? ENPresentPerfectContinuous { get; set; }

        public string? UAPresentSimple { get; set; }

        public string? UAPresentContinuous { get; set; }

        public string? UAPresentPerfect { get; set; }

        public string? UAPresentPerfectContinuous { get; set; }
    }
}
