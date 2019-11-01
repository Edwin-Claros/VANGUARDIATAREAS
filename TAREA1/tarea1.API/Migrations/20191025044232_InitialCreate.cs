using Microsoft.EntityFrameworkCore.Migrations;

namespace tarea1.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userDNI = table.Column<string>(nullable: true),
                    userNombre = table.Column<string>(nullable: true),
                    userDomicilio = table.Column<string>(nullable: true),
                    userTelefono = table.Column<string>(nullable: true),
                    userFechaNacimiento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
