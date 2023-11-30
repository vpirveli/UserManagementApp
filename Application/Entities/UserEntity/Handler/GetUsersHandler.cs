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
    internal class GetUserHandler : IRequestHandler<GetUserQuery, IEnumerable<UserDTO>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            List<UserDTO> dtos = new List<UserDTO>();

            foreach (var user in users)
            {
                UserDTO dto = new UserDTO();

                dto.UserName = user.UserName;
                dto.Email = user.Email;
                dto.Password = user.Password;
                dto.IsActive = user.IsActive;

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
