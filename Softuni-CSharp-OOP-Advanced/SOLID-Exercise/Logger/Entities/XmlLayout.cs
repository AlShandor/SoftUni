
using System;
using System.Globalization;
using Logger.Contracts;

namespace Logger.Entities
{
   public class XmlLayout : ILayout
   {
       private string Layout = "<log>" + Environment.NewLine +
                                     "\t<date>{0}</date>" + Environment.NewLine +
                                     "\t<level>{1}</level>" + Environment.NewLine +
                                     "\t<message>{2}</message>" + Environment.NewLine +
                                     "</log>";
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(Layout, dateString, error.Level.ToString(), error.Message);

            return formattedError;
        }
    }
}
