using Microsoft.EntityFrameworkCore.Migrations;

namespace week4assignment.Data.Migrations
{
    public partial class initialCatcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "CatName", "CatPattern", "CatSize", "CatWeight", "HouseholdPetsId" },
                values: new object[] { 1, "james", "orange", "large", 13.2f, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
