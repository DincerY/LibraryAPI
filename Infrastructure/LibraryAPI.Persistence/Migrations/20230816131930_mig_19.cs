using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadListItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReadListItems_ReadLists_ReadListId",
                        column: x => x.ReadListId,
                        principalTable: "ReadLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_ReadListItems_BookId",
                table: "ReadListItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadLists_UserId",
                table: "ReadLists",
                column: "UserId",
                unique: true);
           

            migrationBuilder.CreateIndex(
                name: "IX_ReadListItems_ReadListId",
                table: "ReadListItems",
                column: "ReadListId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ReadListItems_ReadLists_ReadListId",
            //    table: "ReadListItems");

            //migrationBuilder.DropIndex(
            //    name: "IX_ReadListItems_ReadListId",
            //    table: "ReadListItems");

            //migrationBuilder.DropColumn(
            //    name: "ReadListId",
            //    table: "ReadListItems");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ReadLists_ReadListItemId",
            //    table: "ReadLists",
            //    column: "ReadListItemId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ReadLists_ReadListItems_ReadListItemId",
            //    table: "ReadLists",
            //    column: "ReadListItemId",
            //    principalTable: "ReadListItems",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
