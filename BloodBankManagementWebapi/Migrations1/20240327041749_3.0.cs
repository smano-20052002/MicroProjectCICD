using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class _30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptStatus",
                table: "BloodRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Units",
                table: "BloodRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "bloodStockRequesters",
                columns: table => new
                {
                    BloodStockRequesterId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BloodRequestId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserDetailsId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodStockRequesters", x => x.BloodStockRequesterId);
                    table.ForeignKey(
                        name: "FK_bloodStockRequesters_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodStockRequesters_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodStockRequesters_BloodRequest_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequest",
                        principalColumn: "BloodRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodStockRequesters_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "UserDetailsId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_bloodStockRequesters_AccountId",
                table: "bloodStockRequesters",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_bloodStockRequesters_AddressId",
                table: "bloodStockRequesters",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_bloodStockRequesters_BloodRequestId",
                table: "bloodStockRequesters",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_bloodStockRequesters_UserDetailsId",
                table: "bloodStockRequesters",
                column: "UserDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bloodStockRequesters");

            migrationBuilder.DropColumn(
                name: "AcceptStatus",
                table: "BloodRequest");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "BloodRequest");
        }
    }
}
