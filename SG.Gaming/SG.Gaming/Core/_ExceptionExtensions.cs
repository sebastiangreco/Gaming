using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming
{
    public static class _CoreExtensions
    {

        public static TException FirstExceptionOfType<TException>(this Exception ex)
            where TException : Exception
        {
            TException result = ex as TException;
            if (result != null)
            {
                return result;
            }
            AggregateException aggregate = ex as AggregateException;
            if (aggregate != null)
            {
                foreach (var item in aggregate.InnerExceptions)
                {
                    result = FirstExceptionOfType<TException>(item);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
        public static Exception FirstNonAggregateException(this Exception ex)
        {
            AggregateException aggregate = ex as AggregateException;
            if (aggregate != null)
            {
                foreach (var item in aggregate.InnerExceptions)
                {
                    return FirstNonAggregateException(item);
                }
            }
            return ex;
        }
        public static string FormatException(this Exception ex, string tag)
        {
            if (ex != null)
            {
                string message = string.Empty;
                AggregateException aggregates = ex as AggregateException;
                if (aggregates != null)
                {
                    message = string.Format("<Exception tag=\"{2}\" message=\"{0}\" type=\"{1}\">", EscapeXml(ex.Message), ex.GetType().ToString(), tag);
                    foreach (var item in aggregates.InnerExceptions)
                    {
                        message += string.Format("\r\n<InnerException message=\"{0}\" type=\"{1}\" stack=\"{2}\" />\r\n", EscapeXml(item.Message), item.GetType().ToString(), EscapeXml(item.StackTrace));
                    }
                    message += "</Exception>";
                }
                else
                {
                    message = string.Format("<Exception tag=\"{3}\" message=\"{0}\" type=\"{1}\" stack=\"{2}\">", EscapeXml(ex.Message), ex.GetType().ToString(), EscapeXml(ex.StackTrace), tag);
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        message += string.Format("\r\n<InnerException message=\"{0}\" type=\"{1}\" stack=\"{2}\" />\r\n", EscapeXml(ex.Message), ex.GetType().ToString(), EscapeXml(ex.StackTrace));
                    }
                    message += "</Exception>";
                }
                return message;
            }
            return string.Empty;
        }
        public static string EscapeXml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) { return string.Empty; }

            //TODO:COULD: Escape xml from PCL
            return xml;
        }


    }
}
