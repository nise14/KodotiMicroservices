using Catalog.Common;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandler.Commands;
using Catalog.Service.EventHandler.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Service.EventHandler
{
    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(ApplicationDbContext context, ILogger<ProductInStockUpdateStockEventHandler> loger)
        {
            _context = context;
            _logger = loger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---ProductInStockUpdateStockCommand started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("---Retrieve products from dtabase");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product {entry.ProductId} - doesn't have enough stock");
                        throw new ProductInStockUpdateStockCommandException($"Product {entry.ProductId} - doesn't have enough stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"Product {entry.ProductId} - its stock was substracted - new stock {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);

                        _logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists record");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"Product {entry.ProductId} - its stock was increase and its new stock is {entry.Stock}");
                }

                await _context.SaveChangesAsync();

                _logger.LogInformation("---ProductInStockUpdateStockCommand ended");
            }
        }
    }
}