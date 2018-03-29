using System.Globalization;
using Logger.Contracts;

namespace Logger.Entities.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string Layout = "{0} - {1} - {2}";
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Layout, dateString, error.Level.ToString(), error.Message);

            return formattedError;
        }
    }
}


