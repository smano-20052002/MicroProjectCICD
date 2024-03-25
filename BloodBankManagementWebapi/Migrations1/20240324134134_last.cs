using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodRequestId",
                table: "BloodTransaction",
                type: "varchar(95)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTransaction_BloodRequestId",
                table: "BloodTransaction",
                column: "BloodRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodTransaction_BloodRequest_BloodRequestId",
                table: "BloodTransaction",
                column: "BloodRequestId",
                principalTable: "BloodRequest",
                principalColumn: "BloodRequestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodTransaction_BloodRequest_BloodRequestId",
                table: "BloodTransaction");

            migrationBuilder.DropIndex(
                name: "IX_BloodTransaction_BloodRequestId",
                table: "BloodTransaction");

            migrationBuilder.DropColumn(
                name: "BloodRequestId",
                table: "BloodTransaction");
        }
    }
}
