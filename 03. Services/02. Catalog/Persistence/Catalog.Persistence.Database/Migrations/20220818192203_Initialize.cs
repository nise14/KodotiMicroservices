using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 426m },
                    { 2, "Description for product 2", "Product 2", 569m },
                    { 3, "Description for product 3", "Product 3", 503m },
                    { 4, "Description for product 4", "Product 4", 422m },
                    { 5, "Description for product 5", "Product 5", 786m },
                    { 6, "Description for product 6", "Product 6", 396m },
                    { 7, "Description for product 7", "Product 7", 149m },
                    { 8, "Description for product 8", "Product 8", 395m },
                    { 9, "Description for product 9", "Product 9", 235m },
                    { 10, "Description for product 10", "Product 10", 393m },
                    { 11, "Description for product 11", "Product 11", 355m },
                    { 12, "Description for product 12", "Product 12", 719m },
                    { 13, "Description for product 13", "Product 13", 534m },
                    { 14, "Description for product 14", "Product 14", 468m },
                    { 15, "Description for product 15", "Product 15", 609m },
                    { 16, "Description for product 16", "Product 16", 827m },
                    { 17, "Description for product 17", "Product 17", 822m },
                    { 18, "Description for product 18", "Product 18", 191m },
                    { 19, "Description for product 19", "Product 19", 449m },
                    { 20, "Description for product 20", "Product 20", 628m },
                    { 21, "Description for product 21", "Product 21", 546m },
                    { 22, "Description for product 22", "Product 22", 814m },
                    { 23, "Description for product 23", "Product 23", 823m },
                    { 24, "Description for product 24", "Product 24", 363m },
                    { 25, "Description for product 25", "Product 25", 476m },
                    { 26, "Description for product 26", "Product 26", 185m },
                    { 27, "Description for product 27", "Product 27", 783m },
                    { 28, "Description for product 28", "Product 28", 311m },
                    { 29, "Description for product 29", "Product 29", 354m },
                    { 30, "Description for product 30", "Product 30", 417m },
                    { 31, "Description for product 31", "Product 31", 673m },
                    { 32, "Description for product 32", "Product 32", 344m },
                    { 33, "Description for product 33", "Product 33", 305m },
                    { 34, "Description for product 34", "Product 34", 459m },
                    { 35, "Description for product 35", "Product 35", 483m },
                    { 36, "Description for product 36", "Product 36", 770m },
                    { 37, "Description for product 37", "Product 37", 217m },
                    { 38, "Description for product 38", "Product 38", 332m },
                    { 39, "Description for product 39", "Product 39", 305m },
                    { 40, "Description for product 40", "Product 40", 227m },
                    { 41, "Description for product 41", "Product 41", 152m },
                    { 42, "Description for product 42", "Product 42", 505m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 43, "Description for product 43", "Product 43", 113m },
                    { 44, "Description for product 44", "Product 44", 234m },
                    { 45, "Description for product 45", "Product 45", 180m },
                    { 46, "Description for product 46", "Product 46", 597m },
                    { 47, "Description for product 47", "Product 47", 332m },
                    { 48, "Description for product 48", "Product 48", 129m },
                    { 49, "Description for product 49", "Product 49", 199m },
                    { 50, "Description for product 50", "Product 50", 259m },
                    { 51, "Description for product 51", "Product 51", 218m },
                    { 52, "Description for product 52", "Product 52", 984m },
                    { 53, "Description for product 53", "Product 53", 709m },
                    { 54, "Description for product 54", "Product 54", 345m },
                    { 55, "Description for product 55", "Product 55", 640m },
                    { 56, "Description for product 56", "Product 56", 183m },
                    { 57, "Description for product 57", "Product 57", 884m },
                    { 58, "Description for product 58", "Product 58", 197m },
                    { 59, "Description for product 59", "Product 59", 278m },
                    { 60, "Description for product 60", "Product 60", 878m },
                    { 61, "Description for product 61", "Product 61", 562m },
                    { 62, "Description for product 62", "Product 62", 129m },
                    { 63, "Description for product 63", "Product 63", 692m },
                    { 64, "Description for product 64", "Product 64", 314m },
                    { 65, "Description for product 65", "Product 65", 218m },
                    { 66, "Description for product 66", "Product 66", 688m },
                    { 67, "Description for product 67", "Product 67", 163m },
                    { 68, "Description for product 68", "Product 68", 388m },
                    { 69, "Description for product 69", "Product 69", 561m },
                    { 70, "Description for product 70", "Product 70", 614m },
                    { 71, "Description for product 71", "Product 71", 189m },
                    { 72, "Description for product 72", "Product 72", 887m },
                    { 73, "Description for product 73", "Product 73", 342m },
                    { 74, "Description for product 74", "Product 74", 299m },
                    { 75, "Description for product 75", "Product 75", 919m },
                    { 76, "Description for product 76", "Product 76", 618m },
                    { 77, "Description for product 77", "Product 77", 612m },
                    { 78, "Description for product 78", "Product 78", 411m },
                    { 79, "Description for product 79", "Product 79", 257m },
                    { 80, "Description for product 80", "Product 80", 157m },
                    { 81, "Description for product 81", "Product 81", 253m },
                    { 82, "Description for product 82", "Product 82", 347m },
                    { 83, "Description for product 83", "Product 83", 126m },
                    { 84, "Description for product 84", "Product 84", 910m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 85, "Description for product 85", "Product 85", 683m },
                    { 86, "Description for product 86", "Product 86", 387m },
                    { 87, "Description for product 87", "Product 87", 649m },
                    { 88, "Description for product 88", "Product 88", 443m },
                    { 89, "Description for product 89", "Product 89", 978m },
                    { 90, "Description for product 90", "Product 90", 195m },
                    { 91, "Description for product 91", "Product 91", 625m },
                    { 92, "Description for product 92", "Product 92", 569m },
                    { 93, "Description for product 93", "Product 93", 177m },
                    { 94, "Description for product 94", "Product 94", 755m },
                    { 95, "Description for product 95", "Product 95", 155m },
                    { 96, "Description for product 96", "Product 96", 751m },
                    { 97, "Description for product 97", "Product 97", 944m },
                    { 98, "Description for product 98", "Product 98", 350m },
                    { 99, "Description for product 99", "Product 99", 652m },
                    { 100, "Description for product 100", "Product 100", 410m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 16 },
                    { 3, 3, 14 },
                    { 4, 4, 3 },
                    { 5, 5, 13 },
                    { 6, 6, 8 },
                    { 7, 7, 12 },
                    { 8, 8, 0 },
                    { 9, 9, 10 },
                    { 10, 10, 14 },
                    { 11, 11, 5 },
                    { 12, 12, 5 },
                    { 13, 13, 14 },
                    { 14, 14, 15 },
                    { 15, 15, 13 },
                    { 16, 16, 9 },
                    { 17, 17, 1 },
                    { 18, 18, 5 },
                    { 19, 19, 15 },
                    { 20, 20, 12 },
                    { 21, 21, 7 },
                    { 22, 22, 2 },
                    { 23, 23, 15 },
                    { 24, 24, 16 },
                    { 25, 25, 9 },
                    { 26, 26, 7 },
                    { 27, 27, 6 },
                    { 28, 28, 7 },
                    { 29, 29, 13 },
                    { 30, 30, 3 },
                    { 31, 31, 16 },
                    { 32, 32, 5 },
                    { 33, 33, 1 },
                    { 34, 34, 16 },
                    { 35, 35, 18 },
                    { 36, 36, 18 },
                    { 37, 37, 19 },
                    { 38, 38, 9 },
                    { 39, 39, 11 },
                    { 40, 40, 15 },
                    { 41, 41, 5 },
                    { 42, 42, 13 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 43, 43, 1 },
                    { 44, 44, 0 },
                    { 45, 45, 0 },
                    { 46, 46, 12 },
                    { 47, 47, 9 },
                    { 48, 48, 5 },
                    { 49, 49, 0 },
                    { 50, 50, 0 },
                    { 51, 51, 1 },
                    { 52, 52, 12 },
                    { 53, 53, 19 },
                    { 54, 54, 15 },
                    { 55, 55, 0 },
                    { 56, 56, 12 },
                    { 57, 57, 8 },
                    { 58, 58, 9 },
                    { 59, 59, 17 },
                    { 60, 60, 12 },
                    { 61, 61, 10 },
                    { 62, 62, 2 },
                    { 63, 63, 6 },
                    { 64, 64, 7 },
                    { 65, 65, 18 },
                    { 66, 66, 8 },
                    { 67, 67, 15 },
                    { 68, 68, 16 },
                    { 69, 69, 2 },
                    { 70, 70, 6 },
                    { 71, 71, 9 },
                    { 72, 72, 6 },
                    { 73, 73, 16 },
                    { 74, 74, 13 },
                    { 75, 75, 14 },
                    { 76, 76, 3 },
                    { 77, 77, 4 },
                    { 78, 78, 0 },
                    { 79, 79, 12 },
                    { 80, 80, 2 },
                    { 81, 81, 17 },
                    { 82, 82, 10 },
                    { 83, 83, 10 },
                    { 84, 84, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 85, 85, 15 },
                    { 86, 86, 11 },
                    { 87, 87, 1 },
                    { 88, 88, 1 },
                    { 89, 89, 12 },
                    { 90, 90, 2 },
                    { 91, 91, 13 },
                    { 92, 92, 8 },
                    { 93, 93, 0 },
                    { 94, 94, 5 },
                    { 95, 95, 13 },
                    { 96, 96, 0 },
                    { 97, 97, 10 },
                    { 98, 98, 17 },
                    { 99, 99, 4 },
                    { 100, 100, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductInStockId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductInStockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
