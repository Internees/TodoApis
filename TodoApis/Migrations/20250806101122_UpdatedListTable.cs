using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApis.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_TodoListListId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TodoListListId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TodoListListId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "Lists",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lists",
                newName: "ListId");

            migrationBuilder.AddColumn<int>(
                name: "TodoListListId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TodoListListId",
                table: "Tasks",
                column: "TodoListListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_TodoListListId",
                table: "Tasks",
                column: "TodoListListId",
                principalTable: "Lists",
                principalColumn: "ListId");
        }
    }
}
