using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Users;

namespace Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, LogInResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;

    public LogInUserCommandHandler(IUserRepository userRepository,
                                   IJwtProvider jwtProvider,
                                   IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<LogInResponse>> Handle(
        LogInUserCommand request,
        CancellationToken cancellationToken)
    {
        Email email = new Email(request.Email);

        User? user = await _userRepository.GetByEmailAsync(email);

        if(user is null)
        {
            return Result.Failure<LogInResponse>(UserErrors.InvalidCredentials);
        }

        (bool verified, bool needsUpgrade) =
            _passwordHasher.Check(user.Password.Value, request.Password);

        if(!verified)
        {
            return Result.Failure<LogInResponse>(UserErrors.InvalidCredentials);
        }

        if (needsUpgrade)
        {
            // TODO
        }

        var accessTokenResult = _jwtProvider.GenerateAccessToken(user);
        var refreshTokenResult = _jwtProvider.GenerateRefreshToken();

        //TODO: store refresh token on db

        return new LogInResponse(accessTokenResult.Value, refreshTokenResult.Value);
    }
}