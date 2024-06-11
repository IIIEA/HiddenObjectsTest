using System;
using JetBrains.Annotations;

namespace Infrastructure.Attributes
{
  [MeansImplicitUse]
  [AttributeUsage(AttributeTargets.Field)]
  public sealed class ServiceAttribute : Attribute
  {
    public readonly Type[] Contracts;

    public ServiceAttribute(params Type[] contracts)
    {
      Contracts = contracts;
    }
  }
}