using Application.DTOs;
using Application.Entities.UserEntity.Commands;
using Application.Entities.UserEntity.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator Mediator)
    {
        _mediator = Mediator;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<UserDTO> GetUserById([FromQuery] GetUserByIdQuery query)
    {
        return await _mediator.Send(query);
    }

    // GET: api/<UserController/all>
    [HttpGet("all")]
    public async Task<IEnumerable<UserDTO>> GetAllUsers([FromQuery] GetUserQuery query)
    {
        return await _mediator.Send(query);
    }

    // POST api/<UserController>
    [HttpPost]
    public async Task CreateUser(CreateUserCommand userCommand)
    {
        await _mediator.Send(userCommand);
    }

    // PUT api/<UserController>/5
    [HttpPut]
    public async Task Put(UpdateUserCommand updateUser)
    {
        await _mediator.Send(updateUser);
    }

    // DELETE api/<UserController>/5
    [HttpDelete]
    public async Task Delete(DeleteUserByIdCommand deleteUserByIdCommand)
    {
        await _mediator.Send(deleteUserByIdCommand);
    }
}
