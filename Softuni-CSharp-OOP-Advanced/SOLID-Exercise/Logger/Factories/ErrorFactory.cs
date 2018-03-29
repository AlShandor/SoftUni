using System;
using System.Globalization;
using Logger.Entities;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public Error CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel;
            bool hasParsed = Enum.TryParse(errorLevelString, out errorLevel);
            if (!hasParsed)
            {
                throw new ArgumentException("Invalid Error type!");
            }

            Error error = new Error(dateTime, errorLevel, message);
            return error;
        }
    }
}
