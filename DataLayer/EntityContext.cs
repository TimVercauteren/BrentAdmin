using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<Offerte> Offertes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klant>().ToTable("Klanten");
            modelBuilder.Entity<Factuur>().ToTable("Facturen");
            modelBuilder.Entity<Offerte>().ToTable("Offertes");

            modelBuilder.Entity<Adres>().ToTable("Adressen");
            modelBuilder.Entity<ContactInformatie>().ToTable("Contacten");
            modelBuilder.Entity<WerkLine>().ToTable("Werken");
            modelBuilder.Entity<WerkOmschrijving>().ToTable("Omschrijvingen");
        }
    }
}
