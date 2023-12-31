﻿using Application.DTOs;
using Application.Entities.UserProfileEntity.Queries;
using Domain.Abstraction;
using Domain.Models;
using MediatR;

namespace Application.Entities.UserProfileEntity.Handler;

internal class GetUserProfilesHandler : IRequestHandler<GetUserProfilesQuery, IEnumerable<UserProfileDTO>>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public GetUserProfilesHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<IEnumerable<UserProfileDTO>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<UserProfile> userProfiles = await _userProfileRepository.GetAllAsync();
        List<UserProfileDTO> dtos = new List<UserProfileDTO>();

        foreach (var userProfile in userProfiles)
        {
            UserProfileDTO dto = new UserProfileDTO();

            dto.FirstName = userProfile.FirstName;
            dto.LastName = userProfile.LastName;
            dto.PersonalNumber = userProfile.PersonalNumber;

            dtos.Add(dto);
        }

        return dtos;
    }
}
