using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming
{
    public class ServiceComunicationException : Exception
    {
        public ServiceComunicationException()
        {

        }

        public ServiceComunicationException(string message)
            : base(message)
        {

        }

        public ServiceComunicationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
