using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoToSPSWebApi.Migrations
{
    public partial class TablasTipoAmbientePersonalidadyEstadoCivil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estadoCivil_Id",
                schema: "dbo",
                table: "usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "usuarioFechaNacimiento",
                schema: "dbo",
                table: "usuario",
                type: "DateTime",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "usuarioInteres",
                schema: "dbo",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usuarioMedioTransporte",
                schema: "dbo",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usuarioProfesion",
                schema: "dbo",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "estadoCivil",
                schema: "dbo",
                columns: table => new
                {
                    estadoCivilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    estadoCivilNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoCivil", x => x.estadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "tipoAmbiente",
                schema: "dbo",
                columns: table => new
                {
                    tipoAmbienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipoAmbienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoAmbiente", x => x.tipoAmbienteId);
                });

            migrationBuilder.CreateTable(
                name: "tipoPersonalidad",
                schema: "dbo",
                columns: table => new
                {
                    tipoPersonalidadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipoPersonalidadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersonalidad", x => x.tipoPersonalidadId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_estadoCivil_Id",
                schema: "dbo",
                table: "usuario",
                column: "estadoCivil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario",
                column: "tipoAmbiente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario",
                column: "tipoPersonalidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_lugar_tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar",
                column: "tipoAmbiente_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lugar_tipoAmbiente_tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar",
                column: "tipoAmbiente_Id",
                principalSchema: "dbo",
                principalTable: "tipoAmbiente",
                principalColumn: "tipoAmbienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_estadoCivil_estadoCivil_Id",
                schema: "dbo",
                table: "usuario",
                column: "estadoCivil_Id",
                principalSchema: "dbo",
                principalTable: "estadoCivil",
                principalColumn: "estadoCivilId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_tipoAmbiente_tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario",
                column: "tipoAmbiente_Id",
                principalSchema: "dbo",
                principalTable: "tipoAmbiente",
                principalColumn: "tipoAmbienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_tipoPersonalidad_tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario",
                column: "tipoPersonalidad_Id",
                principalSchema: "dbo",
                principalTable: "tipoPersonalidad",
                principalColumn: "tipoPersonalidadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lugar_tipoAmbiente_tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_estadoCivil_estadoCivil_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_tipoAmbiente_tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_tipoPersonalidad_tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "estadoCivil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tipoAmbiente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tipoPersonalidad",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_usuario_estadoCivil_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_lugar_tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar");

            migrationBuilder.DropColumn(
                name: "estadoCivil_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipoAmbiente_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipoPersonalidad_Id",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioFechaNacimiento",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioInteres",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioMedioTransporte",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioProfesion",
                schema: "dbo",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipoAmbiente_Id",
                schema: "dbo",
                table: "lugar");
        }
    }
}
