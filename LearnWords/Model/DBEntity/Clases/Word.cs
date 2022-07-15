using Microsoft.EntityFrameworkCore;
using System;

namespace LearnWords.Model.DBEntity.Clases
{
    [Index("ENWord", IsUnique = true, Name = "Word_Index")]
    public class Word : Promotion
    {
        public string ENWord { get; set; }

        public string? SecondForm { get; set; }

        public string? ThirdForm { get; set; }

        public string UAWord { get; set; }
    }
}
