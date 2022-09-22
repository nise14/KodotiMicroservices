namespace Catalog.Service.EventHandler.Exceptions;

public class ProductInStockUpdateStockCommandException : Exception
{
    public ProductInStockUpdateStockCommandException(string message) : base(message)
    {

    }
}