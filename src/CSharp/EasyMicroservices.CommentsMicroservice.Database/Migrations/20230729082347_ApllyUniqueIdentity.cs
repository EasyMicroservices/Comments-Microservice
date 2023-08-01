using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.CommentsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class ApllyUniqueIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueIdentity",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueIdentity",
                table: "Comments");
        }
    }
}
