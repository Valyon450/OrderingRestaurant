using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalOrderAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "OrderItems",
                newName: "PriceListNoteId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                newName: "IX_OrderItems_PriceListNoteId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalOrderAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_PriceListNotes_PriceListNoteId",
                table: "OrderItems",
                column: "PriceListNoteId",
                principalTable: "PriceListNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_PriceListNotes_PriceListNoteId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TotalOrderAmount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PriceListNoteId",
                table: "OrderItems",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_PriceListNoteId",
                table: "OrderItems",
                newName: "IX_OrderItems_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
