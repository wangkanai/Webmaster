using System;
using System.Runtime.Serialization;

namespace Wangkanai.Webmaster.Routing
{
    [Serializable]
    internal class AddRoutingArgumentNullException : ArgumentNullException
    {
        public AddRoutingArgumentNullException(string paramName)
            : base(paramName)
        {
        }
    }
}