using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_3.Migrations
{
    /// <inheritdoc />
    public partial class ModifyItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Menu_ItemName",
                table: "Item");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Menu_ItemName",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemName",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Menu",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Item",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Item",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Menu",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Item",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Menu_ItemName",
                table: "Menu",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemName",
                table: "Item",
                column: "ItemName");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Menu_ItemName",
                table: "Item",
                column: "ItemName",
                principalTable: "Menu",
                principalColumn: "ItemName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
