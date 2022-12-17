using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeDatabaseDomain.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRelations_Ingredients_IngredientId",
                table: "RecipeRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRelations_Recipes_RecipeId",
                table: "RecipeRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRelations",
                table: "RecipeRelations");

            migrationBuilder.RenameTable(
                name: "RecipeRelations",
                newName: "RecipeIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRelations_RecipeId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRelations_IngredientId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngredients",
                table: "RecipeIngredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngredients",
                table: "RecipeIngredients");

            migrationBuilder.RenameTable(
                name: "RecipeIngredients",
                newName: "RecipeRelations");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeRelations",
                newName: "IX_RecipeRelations_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeRelations",
                newName: "IX_RecipeRelations_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRelations",
                table: "RecipeRelations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRelations_Ingredients_IngredientId",
                table: "RecipeRelations",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRelations_Recipes_RecipeId",
                table: "RecipeRelations",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
