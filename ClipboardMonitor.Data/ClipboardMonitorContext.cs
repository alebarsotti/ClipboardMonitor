namespace ClipboardMonitor.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ClipboardMonitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ClipboardMonitor.db");
        }

        public virtual DbSet<ClipboardHistory> ClipboardHistory { get; set; }
        public virtual DbSet<Process> Process { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Process>()
                .HasMany(x => x.ClipboardHistory)
                .WithOne(x => x.Process);
        }
    }
}