using Application.DTOs;
using Application.Entities.UserProfileEntity.Queries;
using Domain.Abstraction;
using Domain.Models;
using MediatR;

namespace Application.Entities.UserProfileEntity.Handler;

internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDTO>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public GetUserProfileByIdHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<UserProfileDTO> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        UserProfile? user = await _userProfileRepository.GetByIdAsync(request.Id);
        UserProfileDTO dto = new UserProfileDTO();

        if (user is not null)
        {
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.PersonalNumber = user.PersonalNumber;
        }

        return dto;
    }
}
