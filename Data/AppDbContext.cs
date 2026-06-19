using Microsoft.EntityFrameworkCore;
using ORM1.Models;

namespace ORM1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room_BCS240051> Rooms_BCS240051 { get; set; }

        public DbSet<RoomType_BCS240051> RoomTypes_BCS240051 { get; set; }

        public DbSet<RoomImage_BCS240051> RoomImages_BCS240051 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Quan hệ RoomType - Room
            modelBuilder.Entity<Room_BCS240051>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            // Quan hệ Room - RoomImage
            modelBuilder.Entity<RoomImage_BCS240051>()
                .HasOne(ri => ri.Room)
                .WithMany(r => r.RoomImages)
                .HasForeignKey(ri => ri.RoomId);

            // Dữ liệu mẫu RoomType
            modelBuilder.Entity<RoomType_BCS240051>().HasData(
                new RoomType_BCS240051
                {
                    Id = 1,
                    Name = "Phòng thường",
                    Description = "Phòng giá rẻ"
                },
                new RoomType_BCS240051
                {
                    Id = 2,
                    Name = "Phòng cao cấp",
                    Description = "Có điều hòa"
                },
                new RoomType_BCS240051
                {
                    Id = 3,
                    Name = "Phòng VIP",
                    Description = "Đầy đủ tiện nghi"
                }
            );

            // Dữ liệu mẫu Room
            modelBuilder.Entity<Room_BCS240051>().HasData(
                new Room_BCS240051
                {
                    Id = 1,
                    Name = "P101",
                    Price = 2000000,
                    Area = 20,
                    IsAvailable = true,
                    Description = "Tầng 1",
                    RoomTypeId = 1
                },

                new Room_BCS240051
                {
                    Id = 2,
                    Name = "P102",
                    Price = 2500000,
                    Area = 22,
                    IsAvailable = true,
                    Description = "Tầng 1",
                    RoomTypeId = 1
                },

                new Room_BCS240051
                {
                    Id = 3,
                    Name = "P201",
                    Price = 3500000,
                    Area = 30,
                    IsAvailable = true,
                    Description = "Tầng 2",
                    RoomTypeId = 2
                },

                new Room_BCS240051
                {
                    Id = 4,
                    Name = "P202",
                    Price = 4000000,
                    Area = 35,
                    IsAvailable = false,
                    Description = "Tầng 2",
                    RoomTypeId = 2
                },

                new Room_BCS240051
                {
                    Id = 5,
                    Name = "VIP01",
                    Price = 6000000,
                    Area = 50,
                    IsAvailable = true,
                    Description = "VIP",
                    RoomTypeId = 3
                }
            );

            // Dữ liệu mẫu RoomImage
            modelBuilder.Entity<RoomImage_BCS240051>().HasData(
                new RoomImage_BCS240051
                {
                    Id = 1,
                    ImageUrl = "room1.jpg",
                    IsThumbnail = true,
                    RoomId = 1
                },
                new RoomImage_BCS240051
                {
                    Id = 2,
                    ImageUrl = "room2.jpg",
                    IsThumbnail = true,
                    RoomId = 2
                },
                new RoomImage_BCS240051
                {
                    Id = 3,
                    ImageUrl = "room3.jpg",
                    IsThumbnail = true,
                    RoomId = 3
                }
            );
        }
    }
}