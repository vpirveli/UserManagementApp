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
    internal class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserByIdAsync(request.Id);
        }
    }
}
