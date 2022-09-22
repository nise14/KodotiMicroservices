using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ProductInStockId);

            List<ProductInStock> stocks = new List<ProductInStock>();
            Random random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                stocks.Add(new ProductInStock
                {
                    ProductId = i,
                    ProductInStockId = i,
                    Stock = random.Next(0, 20)
                });
            }

            entityBuilder.HasData(stocks);
        }
    }
}