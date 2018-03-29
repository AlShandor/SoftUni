
using System;
using System.Collections.Generic;
using Logger.Contracts;
using Logger.Factories;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split('|');
                string errorLevelString = args[0];
                string dateTimeString = args[1];
                string message = args[2];
                IError error = errorFactory.CreateError(dateTimeString, errorLevelString, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
