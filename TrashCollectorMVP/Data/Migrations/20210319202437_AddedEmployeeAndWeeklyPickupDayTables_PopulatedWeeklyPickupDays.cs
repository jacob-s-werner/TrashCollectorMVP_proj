using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorMVP.Data.Migrations
{
    public partial class AddedEmployeeAndWeeklyPickupDayTables_PopulatedWeeklyPickupDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a3d9f1-2253-4e28-a7bd-93c7d5823efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7b55e57-4e65-4655-8307-776b887afc80");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPickupDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPickupDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    WeeklyPickUpDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_WeeklyPickupDays_WeeklyPickUpDayId",
                        column: x => x.WeeklyPickUpDayId,
                        principalTable: "WeeklyPickupDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7deac21-13c1-42b3-accc-f80234b9b104", "414745d9-0573-4c2e-b3d8-16a5222998ec", "Customer", "CUSTOMER" },
                    { "07ca560b-9c34-4d93-a777-1f7e646c4425", "a5192bfa-d5c2-4ede-a40e-55c19b294831", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "WeeklyPickupDays",
                columns: new[] { "Id", "Day" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_WeeklyPickUpDayId",
                table: "Customers",
                column: "WeeklyPickUpDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "WeeklyPickupDays");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ca560b-9c34-4d93-a777-1f7e646c4425");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7deac21-13c1-42b3-accc-f80234b9b104");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63a3d9f1-2253-4e28-a7bd-93c7d5823efe", "88864b63-9046-450f-9f34-69b8a892b272", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7b55e57-4e65-4655-8307-776b887afc80", "358c3832-36c4-4863-94b1-9a17fa8e09aa", "Employee", "EMPLOYEE" });
        }
    }
}
