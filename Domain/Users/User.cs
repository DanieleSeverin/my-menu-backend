using Domain.Abstractions;
using Domain.Users;

namespace Domain.Users;

public sealed class User
{
    private User(UserId id, FirstName firstName, LastName lastName, Email email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
    }

    public UserId Id { get; init; }
    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(UserId.New(), firstName, lastName, email);

        return user;
    }
}