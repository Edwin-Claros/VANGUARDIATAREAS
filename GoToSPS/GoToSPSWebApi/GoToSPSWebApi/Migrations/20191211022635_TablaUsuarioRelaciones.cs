using Microsoft.EntityFrameworkCore.Migrations;

namespace GoToSPSWebApi.Migrations
{
    public partial class TablaUsuarioRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actividad_usuario_usuarioId",
                schema: "dbo",
                table: "actividad");

            migrationBuilder.DropIndex(
                name: "IX_actividad_usuarioId",
                schema: "dbo",
                table: "actividad");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                schema: "dbo",
                table: "actividad");

            migrationBuilder.AddColumn<int>(
                name: "usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioEncabezado_usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                column: "usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_itinerarioEncabezado_usuario_usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                column: "usuario_Id",
                principalSchema: "dbo",
                principalTable: "usuario",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itinerarioEncabezado_usuario_usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");

            migrationBuilder.DropIndex(
                name: "IX_itinerarioEncabezado_usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");

            migrationBuilder.DropColumn(
                name: "usuario_Id",
                schema: "dbo",
                table: "itinerarioEncabezado");

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                schema: "dbo",
                table: "actividad",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_actividad_usuarioId",
                schema: "dbo",
                table: "actividad",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_actividad_usuario_usuarioId",
                schema: "dbo",
                table: "actividad",
                column: "usuarioId",
                principalSchema: "dbo",
                principalTable: "usuario",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
