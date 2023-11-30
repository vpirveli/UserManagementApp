using MediatR;

namespace Application.Entities.UserEntity.Commands;

public class CreateUserCommand : IRequest
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

}
