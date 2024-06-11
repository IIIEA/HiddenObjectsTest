using System;
using System.Collections.Generic;

namespace Infrastructure.GameManager
{
  public interface IServiceProvider
  {
    IEnumerable<(Type, object)> ProvideServices();
  }
}