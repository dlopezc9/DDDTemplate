using Application.Users.Get;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : ControllerBase
    {
        private readonly IMediator mediator;

        public User(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get/{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await mediator.Send(new GetUserQuery(new UserId(id)));
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
