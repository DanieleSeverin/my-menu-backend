using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Users;

namespace Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LogInUserCommandHandler(IUserRepository userRepository,
                                   IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<AccessTokenResponse>> Handle(
        LogInUserCommand request,
        CancellationToken cancellationToken)
    {
        Email email = new Email(request.Email);

        User? user = await _userRepository.GetByEmailAsync(email);

        if(user is null)
        {
            return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
        }

        //TODO: check password

        var accessTokenResult = _jwtProvider.Generate(user);

        //if (accessTokenResult.IsFailure)
        //{
        //    return Result.Failure<AccessTokenResponse>(/*todo*/);
        //}

        return new AccessTokenResponse(accessTokenResult.Value);
    }
}