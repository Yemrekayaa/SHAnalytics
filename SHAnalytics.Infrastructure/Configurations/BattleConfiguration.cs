using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class BattleConfiguration : IEntityTypeConfiguration<Battle>
    {
        public void Configure(EntityTypeBuilder<Battle> builder)
        {
            builder.HasMany(b => b.CardOptions).WithOne(co => co.Battle).HasForeignKey(co => co.BattleId);
        }
    }
}
