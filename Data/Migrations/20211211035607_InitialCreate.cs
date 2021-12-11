using Microsoft.EntityFrameworkCore.Migrations;

namespace BAKERY_WEB_APPLICATION.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakedGoods",
                columns: table => new
                {
                    bakedGoodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bakedGoodName = table.Column<string>(nullable: true),
                    typeOfPastry = table.Column<string>(nullable: true),
                    pricePerUnit = table.Column<double>(nullable: false),
                    availableOrNot = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakedGoods", x => x.bakedGoodID);
                });

            migrationBuilder.CreateTable(
                name: "BakeryWorkers",
                columns: table => new
                {
                    workerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workerFirstName = table.Column<string>(nullable: true),
                    workerLastName = table.Column<string>(nullable: true),
                    workerRole = table.Column<string>(nullable: true),
                    workerHourlyWage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryWorkers", x => x.workerID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    customerPhoneNumber = table.Column<string>(nullable: true),
                    orderAmount = table.Column<double>(nullable: false),
                    completedOrNot = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.orderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakedGoods");

            migrationBuilder.DropTable(
                name: "BakeryWorkers");

            migrationBuilder.DropTable(
                name: "CustomerOrders");
        }
    }
}
