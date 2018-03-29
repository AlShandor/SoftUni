
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Logger.Contracts;
using Logger.Factories;

namespace Logger
{
    public class Startup
    {
        static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string appenderType = tokens[0];
                string layoutType = tokens[1];
                string levelString = "INFO";

                if (tokens.Length == 3)
                {
                    levelString = tokens[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, levelString, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }
    }
}
