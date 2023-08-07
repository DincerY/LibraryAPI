using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "ReadListItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReadListItems_BookId",
                table: "ReadListItems",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadListItems_Books_BookId",
                table: "ReadListItems",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadListItems_Books_BookId",
                table: "ReadListItems");

            migrationBuilder.DropIndex(
                name: "IX_ReadListItems_BookId",
                table: "ReadListItems");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ReadListItems");
        }
    }
}
