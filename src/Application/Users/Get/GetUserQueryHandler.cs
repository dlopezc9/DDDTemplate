using Application.Data;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Get;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IDataContext _context;

    public GetUserQueryHandler(IDataContext context)
    {
        _context = context;
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .Where(x => x.Id == request.UserId)
            .Select(u => new UserResponse(
                u.Id.Value,
                u.Name,
                u.Email))
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return user;
    }
}
