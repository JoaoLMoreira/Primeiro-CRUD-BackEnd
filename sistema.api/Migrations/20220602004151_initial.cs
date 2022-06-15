using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistema.api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDoCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesDeExpiracao = table.Column<int>(type: "int", nullable: false),
                    AnoDeExpiracao = table.Column<int>(type: "int", nullable: false),
                    CVC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");
        }
    }
}
