using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.CommentsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiationDateTime",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentity",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreationDateTime",
                table: "Comments",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DeletedDateTime",
                table: "Comments",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ModificationDateTime",
                table: "Comments",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UniqueIdentity",
                table: "Comments",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_CreationDateTime",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DeletedDateTime",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ModificationDateTime",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UniqueIdentity",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModificationDateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentity",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiationDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
