using Microsoft.EntityFrameworkCore.Migrations;

namespace week4assignment.Data.Migrations
{
    public partial class updatehouseholdtohaveaname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseHoldName",
                table: "Households",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseHoldName",
                table: "Households");
        }
    }
}
