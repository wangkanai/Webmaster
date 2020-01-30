// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;

namespace Wangkanai.Webmaster.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MetaDescriptionAttribute : Attribute
    {
        private readonly string _description;

        public MetaDescriptionAttribute(string description)
        {
            this._description = description;
        }
    }
}