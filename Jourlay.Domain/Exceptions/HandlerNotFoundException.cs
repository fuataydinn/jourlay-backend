﻿namespace Jourlay.Domain.Exceptions;

public class HandlerNotFoundException : Exception
{
    public HandlerNotFoundException(string message) : base(message)
    {
    }

    public HandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
