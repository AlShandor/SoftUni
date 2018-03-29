
using System;
using Logger.Contracts;
using Logger.Entities;
using Logger.Entities.Appenders;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile("logFile.txt");
                        appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                    default:
                        throw new ArgumentException("Invalid Appender type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            ErrorLevel errorLevel;
            bool hasParsed = Enum.TryParse<ErrorLevel>(levelString, out errorLevel);
            if (!hasParsed)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!");
            }

            return errorLevel;
        }
    }
}
