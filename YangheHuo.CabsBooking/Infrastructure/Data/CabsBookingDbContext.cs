
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CabsBookingDbContext: DbContext 
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {

        }
        public DbSet<Places> Places { get; set; }
        public DbSet<CabTypes> CabTypes { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistories> BookingsHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Places>(ConfigurePlaces);
            modelBuilder.Entity<CabTypes>(ConfigureCabTypes);
            modelBuilder.Entity<Bookings>(ConfigureBookings);
            modelBuilder.Entity<BookingsHistories>(ConfigureBookingsHistory);
        }

        private void ConfigurePlaces(EntityTypeBuilder<Places> builder)
        {
            builder.ToTable("Places");
            builder.HasKey(p => p.PlaceId);

            builder.Property(p => p.PlaceId).ValueGeneratedOnAdd();
            builder.Property(p => p.PlaceName).HasMaxLength(30);

        }
        private void ConfigureCabTypes(EntityTypeBuilder<CabTypes> builder)
        {
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.CabTypeId);

            builder.Property(c => c.CabTypeId).ValueGeneratedOnAdd();
            builder.Property(c => c.CabTypeName).HasMaxLength(30);
        }
        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Email).HasMaxLength(50);
            builder.Property(b => b.BookingDate).HasColumnType("date");
            builder.Property(b => b.BookingTime).HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasMaxLength(200);
            builder.Property(b => b.Landmark).HasMaxLength(30);
            builder.Property(b => b.PickupDate).HasColumnType("date");
            builder.Property(b => b.PickupTime).HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasMaxLength(25);
            builder.Property(b => b.Status).HasMaxLength(30);

            builder.HasOne(b => b.Places).WithMany(b => b.Bookings).HasForeignKey(b => b.ToPlace);
            builder.HasOne(b => b.CabTypes).WithMany(b => b.Bookings).HasForeignKey(b => b.CabTypeId);
        }

        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistories> builder)
        {
            builder.ToTable("BookingsHistories");
            builder.HasKey(bh => bh.Id);

            builder.Property(bh => bh.Id).ValueGeneratedOnAdd();
            builder.Property(bh => bh.Email).HasMaxLength(50);
            builder.Property(bh => bh.BookingDate).HasColumnType("date");
            builder.Property(bh => bh.BookingTime).HasMaxLength(5);
            builder.Property(bh => bh.PickupAddress).HasMaxLength(200);
            builder.Property(bh => bh.Landmark).HasMaxLength(30);
            builder.Property(bh => bh.PickupDate).HasColumnType("date");
            builder.Property(bh => bh.PickupTime).HasMaxLength(5);
            builder.Property(bh => bh.ContactNo).HasMaxLength(25);
            builder.Property(bh => bh.Status).HasMaxLength(30);
            builder.Property(bh => bh.Comp_Time).HasMaxLength(5);
            builder.Property(bh => bh.Charge).HasColumnType("decimal(5, 2)");
            builder.Property(bh => bh.Feedback).HasMaxLength(1000);

            builder.HasOne(bh => bh.Places).WithMany(bh => bh.BookingsHistories).HasForeignKey(b => b.ToPlace);
            builder.HasOne(bh => bh.CabTypes).WithMany(bh => bh.BookingsHistories).HasForeignKey(b => b.CabTypeId);

        }
    }
}
