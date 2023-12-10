using Domain.Abstractions;
using Domain.Tokens;
using Domain.Users;

namespace Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Result<AccessToken> GenerateAccessToken(User user);
    Result<RefreshToken> GenerateRefreshToken(User user);
}
