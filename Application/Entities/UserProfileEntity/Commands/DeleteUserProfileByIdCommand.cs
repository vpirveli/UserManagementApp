using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserProfileEntity.Commands
{
    public class DeleteUserProfileByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
