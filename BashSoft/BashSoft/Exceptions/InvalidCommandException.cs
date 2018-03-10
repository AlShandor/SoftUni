using System;
using BashSoft;

public class InvalidCommandException : Exception
{
    private const string InvalidCommandMessage = "The command '{input}' is invalid";

    public InvalidCommandException(string message)
        : base(message)
    {

    }
}


