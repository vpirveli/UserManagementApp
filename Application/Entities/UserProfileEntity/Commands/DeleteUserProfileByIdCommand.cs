using MediatR;

namespace Application.Entities.UserProfileEntity.Commands;

public class DeleteUserProfileByIdCommand : IRequest
{
    public int Id { get; set; }
}
