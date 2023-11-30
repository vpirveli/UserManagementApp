﻿using Application.Entities.UserEntity.Commands;
using Application.Entities.UserProfileEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserProfileEntity.Handler
{
    internal class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UpdateUserProfileHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetByIdAsync(request.Id);

            if (userProfile is not null)
            {
                userProfile.FirstName = request.FirstName;
                userProfile.LastName = request.LastName;
                userProfile.PersonalNumber = request.PersonalNumber;
            }

            await _userProfileRepository.UpdateUserAsync(userProfile);
        }
    }
}
