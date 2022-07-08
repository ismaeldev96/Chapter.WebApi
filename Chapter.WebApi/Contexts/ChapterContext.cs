using Chapter.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.WebApi.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext>options) : base(options){}

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-7S1TGCM\\SQLEXPRESS1; initial catalog = Chapter; User Id=sa; password=1234");
            }
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
