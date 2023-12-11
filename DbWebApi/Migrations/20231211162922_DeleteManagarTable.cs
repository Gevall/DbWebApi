using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbWebApi.Migrations
{
    public partial class DeleteManagarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "managers");

            migrationBuilder.AlterColumn<int>(
                name: "Employes_id",
                table: "trips",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_trips_Employes_id",
                table: "trips",
                column: "Employes_id");

            migrationBuilder.AddForeignKey(
                name: "trips_employes_id_fkey",
                table: "trips",
                column: "Employes_id",
                principalTable: "employes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "trips_employes_id_fkey",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_Employes_id",
                table: "trips");

            migrationBuilder.AlterColumn<int>(
                name: "Employes_id",
                table: "trips",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.Id);
                });
        }
    }
}
