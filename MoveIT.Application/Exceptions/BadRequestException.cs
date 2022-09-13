﻿namespace MoveIT.Application.Exceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
        : base(message) { }
}