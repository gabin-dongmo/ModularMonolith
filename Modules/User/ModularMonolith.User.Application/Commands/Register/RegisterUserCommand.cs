﻿using MediatR;

namespace ModularMonolith.User.Application.Commands.Register
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

}