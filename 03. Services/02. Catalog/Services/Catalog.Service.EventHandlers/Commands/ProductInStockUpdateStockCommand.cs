using MediatR;
using Catalog.Common;

namespace Catalog.Service.EventHandler.Commands
{
    public class ProductInStockUpdateStockCommand : INotification
    {
        public List<ProductInStockUpdateItem> Items { get; set; } = new List<ProductInStockUpdateItem>();
    }

    public class ProductInStockUpdateItem
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public ProductInStockAction Action { get; set; }
    }
}