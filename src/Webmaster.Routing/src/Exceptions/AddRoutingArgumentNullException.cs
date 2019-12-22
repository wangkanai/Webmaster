// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;

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