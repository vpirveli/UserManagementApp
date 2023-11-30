using Application.DTOs;
using Application.Entities.UserProfileEntity.Commands;
using Application.Entities.UserProfileEntity.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator Mediator)
        {
            _mediator = Mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<UserProfileDTO> GetUserProfileById([FromQuery] GetUserProfileByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET: api/<UserController/all>
        [HttpGet("all")]
        public async Task<IEnumerable<UserProfileDTO>> GetAllUserProfiles([FromQuery] GetUserProfilesQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task CreateUserProfiles(CreateUserProfileCommand userCommand)
        {
            await _mediator.Send(userCommand);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task UpdateUserProfile(UpdateUserProfileCommand updateUser)
        {
            await _mediator.Send(updateUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        public async Task DeleteUserProfile(DeleteUserProfileByIdCommand deleteUserByIdCommand)
        {
            await _mediator.Send(deleteUserByIdCommand);
        }
    }
}
