using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class add_mig_booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingAdultCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingChildCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingRoomCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingSpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
