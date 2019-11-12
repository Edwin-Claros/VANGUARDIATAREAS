using Microsoft.EntityFrameworkCore.Migrations;

namespace calculadora.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "dividir",
                schema: "dbo",
                columns: table => new
                {
                    dividirId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dividirHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dividir", x => x.dividirId);
                });

            migrationBuilder.CreateTable(
                name: "exponencial",
                schema: "dbo",
                columns: table => new
                {
                    exponencialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exponencialHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exponencial", x => x.exponencialId);
                });

            migrationBuilder.CreateTable(
                name: "multiplicar",
                schema: "dbo",
                columns: table => new
                {
                    multiplicarlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    multiplicarHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiplicar", x => x.multiplicarlId);
                });

            migrationBuilder.CreateTable(
                name: "raiz",
                schema: "dbo",
                columns: table => new
                {
                    raizlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raizHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raiz", x => x.raizlId);
                });

            migrationBuilder.CreateTable(
                name: "restar",
                schema: "dbo",
                columns: table => new
                {
                    restarlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restarlHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restar", x => x.restarlId);
                });

            migrationBuilder.CreateTable(
                name: "sumar",
                schema: "dbo",
                columns: table => new
                {
                    sumarlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sumarHistorico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sumar", x => x.sumarlId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dividir",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "exponencial",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "multiplicar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "raiz",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "restar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sumar",
                schema: "dbo");
        }
    }
}
