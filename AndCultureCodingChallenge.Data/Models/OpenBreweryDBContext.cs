using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AndCultureCodingChallenge.Data.Models
{
    public partial class OpenBreweryDBContext : DbContext
    {
        public OpenBreweryDBContext()
        {
        }

        public OpenBreweryDBContext(DbContextOptions<OpenBreweryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brewery> Breweries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=JAMESPC;Initial Catalog=OpenBreweryDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.HasKey(e => e.ObdbId);

                entity.ToTable("breweries");

                entity.Property(e => e.ObdbId)
                    .HasMaxLength(200)
                    .HasColumnName("obdb_id");

                entity.Property(e => e.Address2)
                    .HasMaxLength(200)
                    .HasColumnName("address_2");

                entity.Property(e => e.Address3)
                    .HasMaxLength(200)
                    .HasColumnName("address_3");

                entity.Property(e => e.BreweryType)
                    .HasMaxLength(200)
                    .HasColumnName("brewery_type");

                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(200)
                    .HasColumnName("country");

                entity.Property(e => e.CountyProvince)
                    .HasMaxLength(200)
                    .HasColumnName("county_province");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(200)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(200)
                    .HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .HasMaxLength(200)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasMaxLength(200)
                    .HasColumnName("street");

                entity.Property(e => e.Tags)
                    .HasMaxLength(1)
                    .HasColumnName("tags");

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(200)
                    .HasColumnName("website_url");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
