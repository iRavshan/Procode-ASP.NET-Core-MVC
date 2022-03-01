using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class EditContentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Contents",
                newName: "AuthorSurname");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Contents",
                newName: "AuthorName");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPhotoFilePath",
                table: "Contents",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPhotoFilePath",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "AuthorSurname",
                table: "Contents",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Contents",
                newName: "Author");
        }
    }
}
