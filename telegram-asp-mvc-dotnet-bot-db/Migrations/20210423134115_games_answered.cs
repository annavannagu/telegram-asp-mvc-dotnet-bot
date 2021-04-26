using Microsoft.EntityFrameworkCore.Migrations;

namespace telegram_asp_mvc_dotnet_bot_db.Migrations
{
    public partial class games_answered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAnswewred",
                table: "Games",
                newName: "IsAnswered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAnswered",
                table: "Games",
                newName: "IsAnswewred");
        }
    }
}
