using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENPresentSimple", IsUnique = true, Name = "PresentSentence_Index")]
    public class PresentSentence : Promotion
    {
        public string ENPresentSimple { get; set; }

        public string? ENPresentContinuous { get; set; }

        public string? ENPresentPerfect { get; set; }

        public string? ENPresentPerfectContinuous { get; set; }

        public string UAPresent { get; set; }
    }
}
