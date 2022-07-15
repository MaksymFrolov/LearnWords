using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearnWords.Model.DBEntity
{
    public class ContextAppFactory : IDesignTimeDbContextFactory<ContextApp>
    {
        public ContextApp CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer("Server=DESKTOP-SP1DHKR\\SQLFORMAX;Database=LearnWordsDataBase;Trusted_Connection=True;");

            return new ContextApp(options.Options);
        }
    }
}
