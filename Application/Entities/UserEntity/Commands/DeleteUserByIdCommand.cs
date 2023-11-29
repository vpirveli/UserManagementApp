using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserEntity.Commands
{
    public class DeleteUserByIdCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
