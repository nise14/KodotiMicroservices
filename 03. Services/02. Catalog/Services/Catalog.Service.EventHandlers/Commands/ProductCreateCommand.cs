using MediatR;

namespace Catalog.Service.EventHandler.Commands
{
    public class ProductCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}