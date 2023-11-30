using MediatR;

namespace Application.Entities.UserEntity.Commands;

public class UpdateUserCommand : IRequest
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }
}
