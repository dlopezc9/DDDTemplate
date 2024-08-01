namespace Domain.Users;

public class User
{
    public User(UserId id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public UserId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
}
