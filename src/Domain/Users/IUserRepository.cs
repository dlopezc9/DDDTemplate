namespace Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);

    void Add(User user);
}
