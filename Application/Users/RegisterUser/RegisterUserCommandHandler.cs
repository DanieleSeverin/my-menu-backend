﻿using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Users;

namespace Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncrypter _passwordHasher;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordEncrypter passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var validatedPasswordResult = Password.Validate(request.Password);

        if (validatedPasswordResult.IsFailure)
        {
            return Result.Failure<Guid>(validatedPasswordResult.Error!);
        }

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