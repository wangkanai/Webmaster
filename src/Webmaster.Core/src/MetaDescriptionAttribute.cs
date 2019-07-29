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
