using Application.Users.Create;
using Application.Users.Get;
using Carter;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class User : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetUserQuery(new UserId(id))));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPost("users/post", async ([FromBody] CreateUserCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });
    }
}