
using System.Collections.Generic;

namespace Logger.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }


        void Log(IError error);
    }
}
