using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public class AddWebmasterArgumentNullException : ArgumentNullException
    {
        public AddWebmasterArgumentNullException(string paramName)
            : base(paramName) { }
    }

    public class AddWebmasterCoreArgumentNullException : ArgumentNullException
    {
        public AddWebmasterCoreArgumentNullException(string paramName)
            : base(paramName) { }
    }
}
