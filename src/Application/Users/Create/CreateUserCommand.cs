﻿using MediatR;

namespace Application.Users.Create;

public record CreateUserCommand(
    string Name,
    string Email) : IRequest;
