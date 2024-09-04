using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDDD.Domain.Entity;

namespace SimpleDDD.Infrastructure.Config;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasOne(o => o.Table).WithMany(o => o.Orders);
        builder.HasQueryFilter(o => o.IsDeleted == false);
    }
}
