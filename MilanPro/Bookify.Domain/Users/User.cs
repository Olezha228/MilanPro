using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;

namespace Bookify.Domain.Users;

public sealed class User : Entity
{
    public User(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }

    public static User Create(FirstName firstName, LastName lastName, Email email) 
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
