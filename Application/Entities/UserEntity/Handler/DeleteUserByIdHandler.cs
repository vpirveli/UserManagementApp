﻿using Application.Entities.UserEntity.Commands;
using Domain.Abstraction;
using Domain.Models;
using MediatR;

namespace Application.Entities.UserEntity.Handler;

internal class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id);
        if (user is not null)
        {
            await _userRepository.DeleteUserAsync(user);
        }
    }
}
