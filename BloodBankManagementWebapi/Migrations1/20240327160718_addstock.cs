using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class addstock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBankBloodStock");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "BloodStock",
                type: "varchar(95)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodStock_AccountId",
                table: "BloodStock",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodStock_Account_AccountId",
                table: "BloodStock",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodStock_Account_AccountId",
                table: "BloodStock");

            migrationBuilder.DropIndex(
                name: "IX_BloodStock_AccountId",
                table: "BloodStock");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "BloodStock");

            migrationBuilder.CreateTable(
                name: "BloodBankBloodStock",
                columns: table => new
                {
                    BloodBankBloodStockId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BloodStockId = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBankBloodStock", x => x.BloodBankBloodStockId);
                    table.ForeignKey(
                        name: "FK_BloodBankBloodStock_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodBankBloodStock_BloodStock_BloodStockId",
                        column: x => x.BloodStockId,
                        principalTable: "BloodStock",
                        principalColumn: "BloodStockId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBankBloodStock_AccountId",
                table: "BloodBankBloodStock",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBankBloodStock_BloodStockId",
                table: "BloodBankBloodStock",
                column: "BloodStockId");
        }
    }
}
