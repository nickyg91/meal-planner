using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealPlanner.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mealplanner");

            migrationBuilder.CreateTable(
                name: "meal",
                schema: "mealplanner",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "meal_plan",
                schema: "mealplanner",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    meal_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meal_plan", x => x.id);
                    table.ForeignKey(
                        name: "fk_meal_plan_meal",
                        column: x => x.MealId,
                        principalSchema: "mealplanner",
                        principalTable: "meal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meal_plan_MealId",
                schema: "mealplanner",
                table: "meal_plan",
                column: "MealId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meal_plan",
                schema: "mealplanner");

            migrationBuilder.DropTable(
                name: "meal",
                schema: "mealplanner");
        }
    }
}
