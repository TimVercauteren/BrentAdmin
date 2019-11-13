using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Klant> Klanten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klant>().ToTable("Klanten");

            modelBuilder.Entity<Document>().ToTable("Documenten");
            modelBuilder.Entity<Adres>().ToTable("Adressen");
            modelBuilder.Entity<ContactInformatie>().ToTable("ContactInfos");
        }
    }
}
