using Microsoft.EntityFrameworkCore.Migrations;

namespace telegram_asp_mvc_dotnet_bot_db.Migrations
{
    public partial class games : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswewred",
                table: "Games",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswewred",
                table: "Games");
        }
    }
}
