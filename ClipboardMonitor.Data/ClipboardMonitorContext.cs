namespace ClipboardMonitor.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class ClipboardMonitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=D:\\Escritorio\\PruebaDB.db");
        }

        //public ClipboardMonitorContext()
        //    : base("name=ClipboardMonitorContext")
        //{
        //    Database.SetInitializer<ClipboardMonitorContext>(new CreateDatabaseIfNotExists<ClipboardMonitorContext>);
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<ClipboardEntry> ClipboardEntries { get; set; }
        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Database does not pluralize table names
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

    }
}