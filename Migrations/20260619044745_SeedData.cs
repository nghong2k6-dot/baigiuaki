using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ORM1.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes_BCS240051",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Phòng giá rẻ", "Phòng thường" },
                    { 2, "Có điều hòa", "Phòng cao cấp" },
                    { 3, "Đầy đủ tiện nghi", "Phòng VIP" }
                });

            migrationBuilder.InsertData(
                table: "Rooms_BCS240051",
                columns: new[] { "Id", "Area", "Description", "IsAvailable", "Name", "Price", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 20.0, "Tầng 1", true, "P101", 2000000m, 1 },
                    { 2, 22.0, "Tầng 1", true, "P102", 2500000m, 1 },
                    { 3, 30.0, "Tầng 2", true, "P201", 3500000m, 2 },
                    { 4, 35.0, "Tầng 2", false, "P202", 4000000m, 2 },
                    { 5, 50.0, "VIP", true, "VIP01", 6000000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomImages_BCS240051",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "RoomId" },
                values: new object[,]
                {
                    { 1, "room1.jpg", true, 1 },
                    { 2, "room2.jpg", true, 2 },
                    { 3, "room3.jpg", true, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomImages_BCS240051",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomImages_BCS240051",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomImages_BCS240051",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms_BCS240051",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms_BCS240051",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypes_BCS240051",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms_BCS240051",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms_BCS240051",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms_BCS240051",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes_BCS240051",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes_BCS240051",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
