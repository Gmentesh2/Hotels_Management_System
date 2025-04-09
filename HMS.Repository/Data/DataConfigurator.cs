using HMS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repository.Data
{
    public static class DataConfigurator
    {
        public static void ConfigureHotels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity
                .Property(h => h.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

                entity
                .Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(h => h.Rating)
                .IsRequired();

                entity
                .Property(h => h.Country)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50);

                entity
                .Property(h => h.City)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50);

                entity
                .Property(h => h.Adress)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50);

                entity
                .HasOne(h => h.Manager)
                .WithOne(m => m.Hotel)
                .HasForeignKey<Manager>(m => m.HotelId);
            });
        }

        public static void ConfigureRooms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                modelBuilder.Entity<Room>(entity =>
                {
                    entity.HasKey(r => r.Id);
                    entity.Property(r => r.Id)
                          .ValueGeneratedOnAdd()
                          .IsRequired();

                    entity.Property(r => r.Name)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(r => r.IsFree)
                          .IsRequired();

                    entity.Property(r => r.Price)
                          .IsRequired()
                          .HasColumnType("decimal(18,2)");

                    entity.HasOne(r => r.Hotel)
                          .WithMany(h => h.Rooms)
                          .HasForeignKey(r => r.HotelId)
                          .IsRequired();
                });
            });
        }

        public static void ConfigureManagers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id)
                      .ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(m => m.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(m => m.Surname)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(m => m.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(m => m.IdentityNumber)
                      .IsRequired()
                      .HasMaxLength(11);

                entity.Property(m => m.MobileNumber)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.HasOne<Hotel>()
                      .WithOne(h => h.Manager)
                      .HasForeignKey<Manager>(m => m.HotelId)
                      .IsRequired();
            });
        }
        
        public static void ConfigureGuests(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                modelBuilder.Entity<Guest>(entity =>
                {
                    entity.HasKey(g => g.Id);
                    entity.Property(g => g.Id)
                          .ValueGeneratedOnAdd()
                          .IsRequired();

                    entity.Property(g => g.Name)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(g => g.Surname)
                          .IsRequired()
                          .HasMaxLength(50);

                    entity.Property(g => g.IdentityNumber)
                          .IsRequired();

                    entity.Property(g => g.MobileNumber)
                          .IsRequired()
                          .HasMaxLength(15);
                });
            });
        }
        
        public static void ConfigureReservations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id)
                      .ValueGeneratedOnAdd()
                      .IsRequired();

                entity.Property(r => r.CheckInDate)
                      .IsRequired();

                entity.Property(r => r.CheckOutDate)
                      .IsRequired();

                entity.HasOne(r => r.Guest)
                      .WithMany(g => g.Reservations)
                      .HasForeignKey(r => r.GuestId)
                      .IsRequired();

                entity.HasOne(r => r.Room)
                      .WithMany()
                      .HasForeignKey(r => r.RoomId)
                      .IsRequired();
            });
        }
    }
}
