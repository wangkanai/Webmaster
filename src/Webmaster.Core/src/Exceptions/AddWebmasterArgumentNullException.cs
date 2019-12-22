// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

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