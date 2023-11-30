using Application.DTOs;
using MediatR;

namespace Application.Entities.UserEntity.Queries;

public class GetUserByIdQuery : IRequest<UserDTO>
{
    public int Id { get; set; }
}
