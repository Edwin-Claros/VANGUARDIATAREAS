using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bitacora.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                schema: "dbo",
                columns: table => new
                {
                    bitacoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bitacoraFecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    bitacoraHoraInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    bitacoraHoraFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    category_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.bitacoraId);
                    table.ForeignKey(
                        name: "FK_Bitacora_Category_category_Id",
                        column: x => x.category_Id,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_category_Id",
                schema: "dbo",
                table: "Bitacora",
                column: "category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
