using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class finalizeaddrolestatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rolestatus",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rolestatus",
                table: "UserDetails");
        }
    }
}
