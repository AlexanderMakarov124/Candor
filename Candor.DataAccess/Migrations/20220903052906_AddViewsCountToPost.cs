using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Candor.DataAccess.Migrations
{
    public partial class AddViewsCountToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "Posts");
        }
    }
}
