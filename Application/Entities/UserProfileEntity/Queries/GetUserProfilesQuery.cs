using Application.DTOs;
using MediatR;

namespace Application.Entities.UserProfileEntity.Queries;

public class GetUserProfilesQuery : IRequest<IEnumerable<UserProfileDTO>>
{
}
