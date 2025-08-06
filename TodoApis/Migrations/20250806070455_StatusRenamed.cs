using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApis.Migrations
{
    /// <inheritdoc />
    public partial class StatusRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tasks",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "TaskStatus");
        }
    }
}
