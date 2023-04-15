using Microsoft.EntityFrameworkCore.Migrations;

namespace EmplyeeDetails.Web.Migrations
{
    public partial class removecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
          name: "FK_city_country_CountryId",
          table: "city");

            migrationBuilder.AddForeignKey(
                name: "FK_city_country_CountryId",
                table: "city",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_country_CountryId",
                table: "city");

            migrationBuilder.AddForeignKey(
                name: "FK_city_country_CountryId",
                table: "CITIES",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
