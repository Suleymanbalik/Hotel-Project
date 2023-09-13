using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomPrice = table.Column<int>(type: "int", nullable: false),
                    RoomTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomBedCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomBathCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomWifi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffSocialMedia1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffSocialMedia2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffSocialMedia3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    SubscribeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscribeMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.SubscribeID);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    TestimonialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestimonialFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestimonialTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestimonialDescripton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestimonialImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.TestimonialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Testimonials");
        }
    }
}
