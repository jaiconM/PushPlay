using Microsoft.EntityFrameworkCore;

namespace PushPlay.Data.Contexto
{
    public class PushPlayContext : DbContext
    {
        public PushPlayContext(DbContextOptions<PushPlayContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PushPlayContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}