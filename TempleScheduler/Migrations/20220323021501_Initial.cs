using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleScheduler.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(nullable: false),
                    GroupSize = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Email", "GroupName", "GroupSize", "Phone" },
                values: new object[] { 1, "group4-1@gmail.com", "4-1", "4", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Email", "GroupName", "GroupSize", "Phone" },
                values: new object[] { 2, "group4-2@gmail.com", "4-2", "5", "111-222-3333" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Email", "GroupName", "GroupSize", "Phone" },
                values: new object[] { 3, "group4-3@gmail.com", "4-3", "6", "555-555-5555" });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Date", "GroupId", "Time" },
                values: new object[] { 1, "2022-01-01", null, 12 });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Date", "GroupId", "Time" },
                values: new object[] { 3, "2022-01-03", null, 11 });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Date", "GroupId", "Time" },
                values: new object[] { 4, "2022-01-03", null, 13 });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "Date", "GroupId", "Time" },
                values: new object[] { 2, "2022-01-02", 2, 15 });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_GroupId",
                table: "TimeSlots",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
