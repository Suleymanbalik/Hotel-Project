using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_sendMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentMessages",
                columns: table => new
                {
                    SentMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentMessageReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageReceiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageSenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageSenderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentMessageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessages", x => x.SentMessageID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMessages");
        }
    }
}
