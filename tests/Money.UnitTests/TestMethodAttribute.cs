#if XUNIT
using System;
using Xunit;

namespace Lsquared
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TestClassAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestMethodAttribute : FactAttribute
    {
    }
}
#endif