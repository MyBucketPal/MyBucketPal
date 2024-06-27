using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RenamePrivateToIsPrivate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Private",
                table: "PlanDetails",
                newName: "IsPrivate");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "PlanDetails",
                newName: "IsCompleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPrivate",
                table: "PlanDetails",
                newName: "Private");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "PlanDetails",
                newName: "Completed");
        }
    }
}
