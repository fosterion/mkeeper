using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mkeeper.Db.Entities;

namespace Mkeeper.Db.Configurations;

public class CashflowConfiguration : IEntityTypeConfiguration<Cashflow>
{
    public void Configure(EntityTypeBuilder<Cashflow> builder)
    {
        builder.UseTptMappingStrategy(); // TODO: remove
    }
}
