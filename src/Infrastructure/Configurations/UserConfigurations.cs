using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
            userId => userId.Value,
            value => new UserId(value));

        builder.Property(x => x.Name).HasMaxLength(100);

        builder.Property(x => x.Email).HasMaxLength(100);

        builder.HasIndex(x => x.Email).IsUnique();

    }
}
