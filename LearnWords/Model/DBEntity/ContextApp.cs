using LearnWords.Model.DBEntity.Clases;
using Microsoft.EntityFrameworkCore;

namespace LearnWords.Model.DBEntity
{
    internal class ContextApp : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<FutureSentence> FutureSentences { get; set; }

        public DbSet<PastSentence> PastSentences { get; set; }

        public DbSet<PresentSentence> PresentSentences { get; set; }

        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=DESKTOP-SP1DHKR\\SQLFORMAX;Database=LearnWordsDataBase;Trusted_Connection=True;");
    }
}
