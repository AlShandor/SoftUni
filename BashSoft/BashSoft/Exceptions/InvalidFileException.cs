using System;

public class InvalidFileException : Exception
{
    private const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

    public InvalidFileException()
        :base(ForbiddenSymbolsContainedInName)
    {
        
    }

    public InvalidFileException(string message)
        :base(message)
    {
        
    }
}