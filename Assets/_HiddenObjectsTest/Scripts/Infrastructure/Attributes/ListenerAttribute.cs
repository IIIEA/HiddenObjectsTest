using System;
using JetBrains.Annotations;

namespace Infrastructure.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ListenerAttribute : Attribute
    {
    
    }
}