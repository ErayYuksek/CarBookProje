using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookProje.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_updateAuthorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Blogs");
        }
    }
}
