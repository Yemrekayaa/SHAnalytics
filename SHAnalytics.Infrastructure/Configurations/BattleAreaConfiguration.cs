using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class BattleAreaConfiguration : IEntityTypeConfiguration<BattleArea>
    {
        public void Configure(EntityTypeBuilder<BattleArea> builder)
        {
            builder.HasMany(ba => ba.Battles).WithOne(b => b.BattleArea).HasForeignKey(b => b.BattleAreaId);
        }
    }
}
