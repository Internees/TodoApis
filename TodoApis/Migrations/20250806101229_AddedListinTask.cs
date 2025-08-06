using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApis.Migrations
{
    /// <inheritdoc />
    public partial class AddedListinTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "listId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_listId",
                table: "Tasks",
                column: "listId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_listId",
                table: "Tasks",
                column: "listId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_listId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_listId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "listId",
                table: "Tasks");
        }
    }
}
