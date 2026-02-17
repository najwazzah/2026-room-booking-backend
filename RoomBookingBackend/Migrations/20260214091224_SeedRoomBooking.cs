using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoomBookingBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoomBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomBookings",
                columns: new[] { "Id", "BookedBy", "CreatedAt", "Date", "RoomName", "Status" },
                values: new object[,]
                {
                    { 1, "Najwa", new DateTime(2026, 2, 14, 16, 12, 22, 551, DateTimeKind.Local).AddTicks(4040), new DateTime(2026, 2, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "B201", "Confirmed" },
                    { 2, "Nando", new DateTime(2026, 2, 14, 16, 12, 22, 551, DateTimeKind.Local).AddTicks(4049), new DateTime(2026, 2, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "B202", "Pending" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomBookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomBookings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
