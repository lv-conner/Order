using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderGrpcServiceHost.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    OrderId = table.Column<string>(maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntity");
        }
    }
}
