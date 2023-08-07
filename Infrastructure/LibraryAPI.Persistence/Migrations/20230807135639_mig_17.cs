using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadLists_ReadListItems_ReadListItemsId",
                table: "ReadLists");

            migrationBuilder.RenameColumn(
                name: "ReadListItemsId",
                table: "ReadLists",
                newName: "ReadListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ReadLists_ReadListItemsId",
                table: "ReadLists",
                newName: "IX_ReadLists_ReadListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadLists_ReadListItems_ReadListItemId",
                table: "ReadLists",
                column: "ReadListItemId",
                principalTable: "ReadListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadLists_ReadListItems_ReadListItemId",
                table: "ReadLists");

            migrationBuilder.RenameColumn(
                name: "ReadListItemId",
                table: "ReadLists",
                newName: "ReadListItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_ReadLists_ReadListItemId",
                table: "ReadLists",
                newName: "IX_ReadLists_ReadListItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadLists_ReadListItems_ReadListItemsId",
                table: "ReadLists",
                column: "ReadListItemsId",
                principalTable: "ReadListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
