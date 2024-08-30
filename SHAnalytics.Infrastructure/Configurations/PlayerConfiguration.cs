using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasMany(b => b.InGames).WithOne(s => s.Player).HasForeignKey(s => s.PlayerId);
        }
    }
}
