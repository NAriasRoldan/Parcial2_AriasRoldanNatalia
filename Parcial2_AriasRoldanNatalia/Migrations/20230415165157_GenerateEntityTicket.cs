using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AriasRoldanNatalia.Migrations
{
    /// <inheritdoc />
    public partial class GenerateEntityTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: true),
                    UseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntranceGateid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Entrances_EntranceGateid",
                        column: x => x.EntranceGateid,
                        principalTable: "Entrances",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EntranceGateid",
                table: "Tickets",
                column: "EntranceGateid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
