using System;
using JetBrains.Annotations;

namespace Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    [MeansImplicitUse]
    public sealed class InjectAttribute : Attribute
    {
    
    }
}