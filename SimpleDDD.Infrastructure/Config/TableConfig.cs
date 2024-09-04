using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleDDD.Domain.Entity;

namespace SimpleDDD.Infrastructure.Config;

public class TableConfig : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable(nameof(Table));
        builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}
