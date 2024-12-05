using Microsoft.EntityFrameworkCore.Migrations;

namespace week4assignment.Data.Migrations
{
    public partial class FinishingUpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseholdPetsId",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdPetsId",
                table: "Cats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_HouseholdPetsId",
                table: "Dogs",
                column: "HouseholdPetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_HouseholdPetsId",
                table: "Cats",
                column: "HouseholdPetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Households_HouseholdPetsId",
                table: "Cats",
                column: "HouseholdPetsId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Households_HouseholdPetsId",
                table: "Dogs",
                column: "HouseholdPetsId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Households_HouseholdPetsId",
                table: "Cats");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Households_HouseholdPetsId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_HouseholdPetsId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Cats_HouseholdPetsId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "HouseholdPetsId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "HouseholdPetsId",
                table: "Cats");
        }
    }
}
