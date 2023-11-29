using Application.DTOs;
using Application.Entities.UserEntity.Commands;
using Application.Entities.UserEntity.Queries;
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
    internal class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.Id);
            UserDTO dto = new UserDTO();

            if (user is not null)
            {
                dto.UserName = user.UserName;
                dto.Email = user.Email;
                dto.Password = user.Password;
                dto.IsActive = user.IsActive;
            }

            return dto;
        }
    }
}
