using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeDatabaseDomain.Migrations
{
    public partial class addedUserIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserIngredients",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIngredients", x => new { x.UserId, x.IngredientId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIngredients");
        }
    }
}
