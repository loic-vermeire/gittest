using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 100, nullable: false),
                    TicketNumber = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DeviceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketNumber);
                });

            migrationBuilder.CreateTable(
                name: "TicketResponses",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsClientResponse = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    TicketFK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketResponses_Tickets_TicketFK",
                        column: x => x.TicketFK,
                        principalTable: "Tickets",
                        principalColumn: "TicketNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketResponses_TicketFK",
                table: "TicketResponses",
                column: "TicketFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_State",
                table: "Tickets",
                column: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketResponses");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
