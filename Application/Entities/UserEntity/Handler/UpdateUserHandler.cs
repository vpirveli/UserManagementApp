using Application.Entities.UserEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserEntity.Handler
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.Id);

            if (user is not null)
            {
                user.UserName = request.UserName;
                user.Password = request.Password;
                user.Email = request.Email;
            }

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
