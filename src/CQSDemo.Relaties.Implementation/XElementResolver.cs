using System;
using System.Xml.Linq;
using AutoMapper;

namespace CQSDemo.Relaties.Implementation
{
    public class XElementResolver<T> : ValueResolver<XElement, T>
    {
        protected override T ResolveCore(XElement source)
        {
            if (string.IsNullOrEmpty(source?.Value))
                return default(T);

            return (T)Convert.ChangeType(source.Value, typeof(T));
        }
    }
}