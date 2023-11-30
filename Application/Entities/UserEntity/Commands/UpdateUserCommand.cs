using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserEntity.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
