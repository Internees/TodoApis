using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApis.Migrations
{
    /// <inheritdoc />
    public partial class AddedList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoListListId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_TodoListListId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TodoListListId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TodoListListId",
                table: "Tasks");
        }
    }
}
