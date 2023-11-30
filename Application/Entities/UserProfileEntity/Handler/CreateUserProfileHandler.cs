using Application.Entities.UserEntity.Commands;
using Application.Entities.UserProfileEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using Infrastructure.Data;
using MediatR;
namespace Application.Entities.UserEntity.Handler
{
    internal class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public CreateUserProfileHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile userProfile = new UserProfile();

            userProfile.Id = request.Id;
            userProfile.FirstName = request.FirstName;
            userProfile.LastName = request.LastName;
            userProfile.PersonalNumber = request.PersonalNumber;

            await _userProfileRepository.CreateUserAsync(userProfile);
        }
    }
}
