using Application.DTOs;
using MediatR;

namespace Application.Entities.UserEntity.Queries;

public class GetUserQuery : IRequest<IEnumerable<UserDTO>>
{
}
