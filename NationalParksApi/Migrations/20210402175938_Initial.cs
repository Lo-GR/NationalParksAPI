using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationalParksAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Region = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Established = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ImageURL = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_Parks_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name", "Region" },
                values: new object[] { 1, "Washington", "Pacific-NorthWest" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name", "Region" },
                values: new object[] { 2, "Oregon", "Pacific-NorthWest" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name", "Region" },
                values: new object[] { 3, "Colorado", "Mountain-West" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Distance", "Established", "ImageURL", "Name", "StateId" },
                values: new object[] { 1, 236381, "1899-03-02", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG/1280px-Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG", "Mount Rainier National Park", 1 });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Distance", "Established", "ImageURL", "Name", "StateId" },
                values: new object[] { 2, 183224, "1902-05-22", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Above_Crater_Lake_%28cropped%29.jpg/1920px-Above_Crater_Lake_%28cropped%29.jpg", "Crater Lake National Park", 2 });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Distance", "Established", "ImageURL", "Name", "StateId" },
                values: new object[] { 3, 265461, "1915-01-26", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/ViewFromSummitofHallett.jpg/1920px-ViewFromSummitofHallett.jpg", "Rocky Mountain State Park", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Parks_StateId",
                table: "Parks",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
