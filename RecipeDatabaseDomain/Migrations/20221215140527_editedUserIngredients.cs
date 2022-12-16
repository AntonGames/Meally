using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeDatabaseDomain.Migrations
{
    public partial class editedUserIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "UserIngredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientId",
                table: "UserIngredients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIngredients",
                table: "UserIngredients",
                columns: new[] { "UserId", "IngredientId" });
        }
    }
}
