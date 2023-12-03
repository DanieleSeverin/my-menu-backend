using Domain.Abstractions;
using Domain.Users;

namespace Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Result<string> Generate(User user);
}
