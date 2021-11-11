﻿using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModularMonolith.User.Application.Exceptions;

namespace ModularMonolith.User.Application.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var identity = await _userManager.CreateAsync(new IdentityUser(request.UserName), request.Password);
            if (!identity.Succeeded)
                throw new RegisterException(identity.Errors);

            return Unit.Value;
        }
    }

}