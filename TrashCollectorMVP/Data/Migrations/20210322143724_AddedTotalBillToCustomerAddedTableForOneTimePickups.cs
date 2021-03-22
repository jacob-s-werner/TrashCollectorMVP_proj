using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorMVP.Data.Migrations
{
    public partial class AddedTotalBillToCustomerAddedTableForOneTimePickups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2432651-d5c0-4f15-a906-a56676d41c3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a291f209-7f11-4af7-8c52-8429f8580312");

            migrationBuilder.AddColumn<double>(
                name: "TotalBill",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OneTimePickups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateForPickup = table.Column<DateTime>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimePickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimePickups_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OneTimePickups_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b953561e-ff29-4a5f-aa9a-53c023680f13", "41376ad9-5200-46fb-9b91-c959c77c00a2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57238b69-e427-4c16-a1b5-9622ffe269c8", "7ac58623-4d24-4301-ba6e-df7cb0e5b724", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_OneTimePickups_CustomerId",
                table: "OneTimePickups",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimePickups_IdentityUserId",
                table: "OneTimePickups",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneTimePickups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57238b69-e427-4c16-a1b5-9622ffe269c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b953561e-ff29-4a5f-aa9a-53c023680f13");

            migrationBuilder.DropColumn(
                name: "TotalBill",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a291f209-7f11-4af7-8c52-8429f8580312", "3e658ff9-d498-48cd-ac2f-49b4ef2cdaba", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2432651-d5c0-4f15-a906-a56676d41c3a", "90d644a0-8c5d-4da3-a83e-b817f7542e80", "Employee", "EMPLOYEE" });
        }
    }
}
