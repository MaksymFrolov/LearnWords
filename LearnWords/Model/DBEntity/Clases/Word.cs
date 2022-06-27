using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENWord", IsUnique = true, Name = "Word_Index")]
    internal class Word : Promotion
    {
        public int Id { get; set; }

        public string ENWord { get; set; }

        public string? SecondForm { get; set; }

        public string? ThirdForm { get; set; }

        public string UAWord { get; set; }
    }
}
