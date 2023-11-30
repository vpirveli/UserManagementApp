using Application.DTOs;
using MediatR;

namespace Application.Entities.UserProfileEntity.Queries;

public class GetUserProfileByIdQuery : IRequest<UserProfileDTO>
{
    public int Id { get; set; }
}
