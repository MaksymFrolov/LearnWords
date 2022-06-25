using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENSentence", IsUnique = true, Name = "Sentence_Index")]
    internal class Sentence : Promotion
    {
        public int Id { get; set; }

        public string? ENSentence { get; set; }

        public string? UASentence { get; set; }
    }
}
