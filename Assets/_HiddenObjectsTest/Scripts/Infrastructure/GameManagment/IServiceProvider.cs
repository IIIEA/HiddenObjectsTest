using System;
using System.Collections.Generic;

namespace Infrastructure.GameManagment
{
  public interface IServiceProvider
  {
    IEnumerable<(Type, object)> ProvideServices();
  }
}