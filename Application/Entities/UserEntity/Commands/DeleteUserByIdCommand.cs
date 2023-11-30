using MediatR;

namespace Application.Entities.UserEntity.Commands;

public class DeleteUserByIdCommand : IRequest
{
    public int Id { get; set; }
}
