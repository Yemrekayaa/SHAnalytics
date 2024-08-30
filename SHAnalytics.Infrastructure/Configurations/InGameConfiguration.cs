using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class InGameConfiguration : IEntityTypeConfiguration<InGame>
    {
        public void Configure(EntityTypeBuilder<InGame> builder)
        {
            builder.HasMany(b => b.Sessions).WithOne(s => s.InGame).HasForeignKey(s => s.InGameId);
        }
    }
}
