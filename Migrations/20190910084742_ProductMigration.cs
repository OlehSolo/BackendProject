using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PicknPayAspNetCoreWebApi.Migrations
{
    public partial class ProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductBrand = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductCategory = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductPreviousPrice = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    ProductMass = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ProductBarcode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CartItemCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
