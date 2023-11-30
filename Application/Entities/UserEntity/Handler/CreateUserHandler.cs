using Application.Entities.UserEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using Domain.Utilities;
using MediatR;

namespace Application.Entities.UserEntity.Handler;

internal class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = new User();

        user.UserName = request.UserName;
        user.Password = request.Password.ComputeMD5Hash();
        user.Email = request.Email;

        await _userRepository.CreateUserAsync(user);
    }
}
