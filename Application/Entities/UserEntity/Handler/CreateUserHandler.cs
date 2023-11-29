using Application.Entities.UserEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserEntity.Handler
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserDbContext userRepository;

        public CreateUserHandler(UserDbContext userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User();

            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;

            await userRepository.Users.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}
