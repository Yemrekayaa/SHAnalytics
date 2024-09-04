using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasMany(b => b.BattleAreas).WithOne(ba => ba.Session).HasForeignKey(ba => ba.SessionId);
            builder.HasMany(b => b.Difficulties).WithOne(d => d.Session).HasForeignKey(d => d.SessionId);
        }
    }
}
