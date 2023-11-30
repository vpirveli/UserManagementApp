﻿using Application.DTOs;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.UserProfileEntity.Queries
{
    public class GetUserProfilesQuery : IRequest<IEnumerable<UserProfileDTO>>
    {
    }
}
