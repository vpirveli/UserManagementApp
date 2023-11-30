using Application.Entities.UserEntity.Commands;
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
    internal class DeleteUserProfileByIdHandler : IRequestHandler<DeleteUserProfileByIdCommand>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public DeleteUserProfileByIdHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task Handle(DeleteUserProfileByIdCommand request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (userProfile is not null) 
            {
                await _userProfileRepository.DeleteUserAsync(userProfile);
            }
        }
    }
}
