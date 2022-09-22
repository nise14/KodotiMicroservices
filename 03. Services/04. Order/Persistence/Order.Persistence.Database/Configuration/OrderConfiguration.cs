using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.Database.Configuration;

public class OrderConfiguation
{
    public OrderConfiguation(EntityTypeBuilder<Domain.Order> entityBuilder)
    {
        entityBuilder.HasKey(x => x.OrderId);
    }
}