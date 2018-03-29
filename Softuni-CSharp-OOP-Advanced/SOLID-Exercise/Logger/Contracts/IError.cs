namespace Logger.Contracts
{
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        String Message { get; }

        ErrorLevel Level { get; }
    }
}


