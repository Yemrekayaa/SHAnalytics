using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(b => b.TotalTime).HasDefaultValue(0);
            builder.Property(b => b.TotalPlayed).HasDefaultValue(0);
            builder.HasMany(b => b.Sessions).WithOne(s => s.Player).HasForeignKey(s => s.PlayerId);
        }
    }
}
