using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarListing.Models
{
    public partial class CarsContext : DbContext
    {
        public virtual DbSet<Car> CarsInfo { get; set; }

        public CarsContext(DbContextOptions<CarsContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Carid)
                    .HasName("PK__cars_inf__68A13006523E74ED");

                entity.ToTable("cars_info");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModelYear)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
