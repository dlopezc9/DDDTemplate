using Domain.Users;
using MediatR;

namespace Application.Users.Get;

public record GetUserQuery(UserId UserId) : IRequest<UserResponse>;

public record UserResponse(
    Guid Id,
    string Name,
    string Email);
