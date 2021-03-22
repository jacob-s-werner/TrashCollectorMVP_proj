using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorMVP.Data.Migrations
{
    public partial class AddedTempPickupSuspensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57238b69-e427-4c16-a1b5-9622ffe269c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b953561e-ff29-4a5f-aa9a-53c023680f13");

            migrationBuilder.CreateTable(
                name: "TemporaryPickupSuspensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryPickupSuspensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporaryPickupSuspensions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemporaryPickupSuspensions_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c28dbc4a-5dfc-4965-828a-38a48cea4a21", "fc30d60c-e871-4237-85f0-257a6b3a2c50", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c560967-deaa-4fcd-9414-fb024f7a171b", "6dd63183-d405-4886-8246-965e9cd1e7ac", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryPickupSuspensions_CustomerId",
                table: "TemporaryPickupSuspensions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryPickupSuspensions_IdentityUserId",
                table: "TemporaryPickupSuspensions",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporaryPickupSuspensions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c560967-deaa-4fcd-9414-fb024f7a171b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28dbc4a-5dfc-4965-828a-38a48cea4a21");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b953561e-ff29-4a5f-aa9a-53c023680f13", "41376ad9-5200-46fb-9b91-c959c77c00a2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57238b69-e427-4c16-a1b5-9622ffe269c8", "7ac58623-4d24-4301-ba6e-df7cb0e5b724", "Employee", "EMPLOYEE" });
        }
    }
}
