using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoToSPSWebApi.Migrations
{
    public partial class NuevaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "categoria",
                schema: "dbo",
                columns: table => new
                {
                    categoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    categoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "jornada",
                schema: "dbo",
                columns: table => new
                {
                    jornadaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    jornadaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jornada", x => x.jornadaId);
                });

            migrationBuilder.CreateTable(
                name: "lugar",
                schema: "dbo",
                columns: table => new
                {
                    lugarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    lugarNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lugarFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lugarHoraEntrada = table.Column<DateTime>(type: "DateTime", nullable: false),
                    lugarHoraCierre = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lugar", x => x.lugarId);
                });

            migrationBuilder.CreateTable(
                name: "prioridad",
                schema: "dbo",
                columns: table => new
                {
                    prioridadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prioridadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prioridad", x => x.prioridadId);
                });

            migrationBuilder.CreateTable(
                name: "tipoUsuario",
                schema: "dbo",
                columns: table => new
                {
                    tipoUsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipoUsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoUsuario", x => x.tipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "itinerarioEncabezado",
                schema: "dbo",
                columns: table => new
                {
                    itinerarioEncabezadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itinerarioEncabezadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itinerarioEncabezadoFechaInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    itinerarioEncabezadoFechaFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    lugar_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itinerarioEncabezado", x => x.itinerarioEncabezadoId);
                    table.ForeignKey(
                        name: "FK_itinerarioEncabezado_lugar_lugar_Id",
                        column: x => x.lugar_Id,
                        principalSchema: "dbo",
                        principalTable: "lugar",
                        principalColumn: "lugarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "dbo",
                columns: table => new
                {
                    usuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioClave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioSexo = table.Column<string>(type: "char", nullable: false),
                    tipoUsuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_tipoUsuario_tipoUsuario_Id",
                        column: x => x.tipoUsuario_Id,
                        principalSchema: "dbo",
                        principalTable: "tipoUsuario",
                        principalColumn: "tipoUsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "actividad",
                schema: "dbo",
                columns: table => new
                {
                    actividadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actividadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actividadDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actividadHorario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actividadDuracion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    lugar_Id = table.Column<int>(nullable: false),
                    categoria_Id = table.Column<int>(nullable: false),
                    jornada_Id = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actividad", x => x.actividadId);
                    table.ForeignKey(
                        name: "FK_actividad_categoria_categoria_Id",
                        column: x => x.categoria_Id,
                        principalSchema: "dbo",
                        principalTable: "categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_actividad_jornada_jornada_Id",
                        column: x => x.jornada_Id,
                        principalSchema: "dbo",
                        principalTable: "jornada",
                        principalColumn: "jornadaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_actividad_lugar_lugar_Id",
                        column: x => x.lugar_Id,
                        principalSchema: "dbo",
                        principalTable: "lugar",
                        principalColumn: "lugarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_actividad_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalSchema: "dbo",
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "itinerarioDetalle",
                schema: "dbo",
                columns: table => new
                {
                    itinerarioDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actividad_Id = table.Column<int>(nullable: false),
                    prioridad_Id = table.Column<int>(nullable: false),
                    itinerarioEncabezado_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itinerarioDetalle", x => x.itinerarioDetalleId);
                    table.ForeignKey(
                        name: "FK_itinerarioDetalle_actividad_actividad_Id",
                        column: x => x.actividad_Id,
                        principalSchema: "dbo",
                        principalTable: "actividad",
                        principalColumn: "actividadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itinerarioDetalle_itinerarioEncabezado_itinerarioEncabezado_Id",
                        column: x => x.itinerarioEncabezado_Id,
                        principalSchema: "dbo",
                        principalTable: "itinerarioEncabezado",
                        principalColumn: "itinerarioEncabezadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itinerarioDetalle_prioridad_prioridad_Id",
                        column: x => x.prioridad_Id,
                        principalSchema: "dbo",
                        principalTable: "prioridad",
                        principalColumn: "prioridadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actividad_categoria_Id",
                schema: "dbo",
                table: "actividad",
                column: "categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_actividad_jornada_Id",
                schema: "dbo",
                table: "actividad",
                column: "jornada_Id");

            migrationBuilder.CreateIndex(
                name: "IX_actividad_lugar_Id",
                schema: "dbo",
                table: "actividad",
                column: "lugar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_actividad_usuarioId",
                schema: "dbo",
                table: "actividad",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioDetalle_actividad_Id",
                schema: "dbo",
                table: "itinerarioDetalle",
                column: "actividad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioDetalle_itinerarioEncabezado_Id",
                schema: "dbo",
                table: "itinerarioDetalle",
                column: "itinerarioEncabezado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioDetalle_prioridad_Id",
                schema: "dbo",
                table: "itinerarioDetalle",
                column: "prioridad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_itinerarioEncabezado_lugar_Id",
                schema: "dbo",
                table: "itinerarioEncabezado",
                column: "lugar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tipoUsuario_Id",
                schema: "dbo",
                table: "usuario",
                column: "tipoUsuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itinerarioDetalle",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "actividad",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "itinerarioEncabezado",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prioridad",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "categoria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "jornada",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lugar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tipoUsuario",
                schema: "dbo");
        }
    }
}
