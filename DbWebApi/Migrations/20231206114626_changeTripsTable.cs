using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbWebApi.Migrations
{
    public partial class changeTripsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialist",
                table: "trips");

            migrationBuilder.AddColumn<int>(
                name: "Employes_id",
                table: "trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employes_id",
                table: "trips");

            migrationBuilder.AddColumn<string>(
                name: "Specialist",
                table: "trips",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
