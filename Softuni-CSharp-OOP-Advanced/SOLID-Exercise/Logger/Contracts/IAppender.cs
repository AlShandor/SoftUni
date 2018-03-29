﻿
namespace Logger.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel Level { get; }

        void Append(IError error);
    }
}
