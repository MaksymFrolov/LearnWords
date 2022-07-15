using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENSentence", IsUnique = true, Name = "Sentence_Index")]
    public class Sentence : Promotion
    {
        public string ENSentence { get; set; }

        public string UASentence { get; set; }
    }
}
