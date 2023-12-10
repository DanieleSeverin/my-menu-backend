using Domain.Tokens;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class RefreshTokenConfigurations : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(token => token.Id);

        builder.Property(token => token.Id).HasConversion(
            tokenId => tokenId.Value,
            value => new RefreshTokenId(value));

        builder.Property(token => token.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
        
        builder.HasOne(token => token.User)
            .WithMany(user => user.RefreshTokens)
            .HasForeignKey(token => token.UserId)
            .HasPrincipalKey(user => user.Id);
    }
}
