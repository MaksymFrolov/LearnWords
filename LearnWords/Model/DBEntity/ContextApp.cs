using LearnWords.Model.DBEntity.Clases;
using Microsoft.EntityFrameworkCore;

namespace LearnWords.Model.DBEntity
{
    public class ContextApp : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<FutureSentence> FutureSentences { get; set; }

        public DbSet<PastSentence> PastSentences { get; set; }

        public DbSet<PresentSentence> PresentSentences { get; set; }

        public DbSet<Sentence> Sentences { get; set; }

        public ContextApp(DbContextOptions optionsBuilder) : base(optionsBuilder) { }
    }
}
