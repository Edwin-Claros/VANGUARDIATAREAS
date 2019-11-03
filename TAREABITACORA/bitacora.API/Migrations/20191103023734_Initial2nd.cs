using Microsoft.EntityFrameworkCore.Migrations;

namespace bitacora.API.Migrations
{
    public partial class Initial2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacora_Category_category_Id",
                schema: "dbo",
                table: "Bitacora");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacora_Category_category_Id",
                schema: "dbo",
                table: "Bitacora",
                column: "category_Id",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacora_Category_category_Id",
                schema: "dbo",
                table: "Bitacora");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacora_Category_category_Id",
                schema: "dbo",
                table: "Bitacora",
                column: "category_Id",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
