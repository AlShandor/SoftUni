
using System.Collections.Generic;
using Logger.Contracts;

namespace Logger
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public ILayout Layout { get; }

        public IAppender Appender { get; }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
