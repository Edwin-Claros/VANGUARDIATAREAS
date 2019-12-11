using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoToSPSWebApi.Migrations
{
    public partial class TablaCiudadRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ciudad_Id",
                schema: "dbo",
                table: "lugar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ciudad",
                schema: "dbo",
                columns: table => new
                {
                    ciudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ciudadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.ciudadId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lugar_ciudad_Id",
                schema: "dbo",
                table: "lugar",
                column: "ciudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioEncabezado_ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                column: "ciudad_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_itinerarioEncabezado_ciudad_ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                column: "ciudad_Id",
                principalSchema: "dbo",
                principalTable: "ciudad",
                principalColumn: "ciudadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_lugar_ciudad_ciudad_Id",
                schema: "dbo",
                table: "lugar",
                column: "ciudad_Id",
                principalSchema: "dbo",
                principalTable: "ciudad",
                principalColumn: "ciudadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itinerarioEncabezado_ciudad_ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");

            migrationBuilder.DropForeignKey(
                name: "FK_lugar_ciudad_ciudad_Id",
                schema: "dbo",
                table: "lugar");

            migrationBuilder.DropTable(
                name: "ciudad",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_lugar_ciudad_Id",
                schema: "dbo",
                table: "lugar");

            migrationBuilder.DropIndex(
                name: "IX_itinerarioEncabezado_ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");

            migrationBuilder.DropColumn(
                name: "ciudad_Id",
                schema: "dbo",
                table: "lugar");

            migrationBuilder.DropColumn(
                name: "ciudad_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");
        }
    }
}
