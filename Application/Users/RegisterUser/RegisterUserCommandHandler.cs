using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Users;

namespace Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        //TODO: validate password

        string encryptedPassword = _passwordHasher.Hash(request.Password);

        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email),
            new Password(encryptedPassword));

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id.Value;
    }
}