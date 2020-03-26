using System;
using System.Collections.Generic;
using System.Text;

namespace WriteToJson
{
    public class ExportException : Exception
    {
        public ExportException() { }

        public ExportException(string message) : base(message) { }

        public ExportException(string message, Exception inner) : base(message, inner) { }
    }
}
