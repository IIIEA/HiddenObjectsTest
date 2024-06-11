using System.Collections.Generic;

namespace Infrastructure.GameManagment
{
  public interface IGameListenerProvider
  {
    IEnumerable<IGameListener> ProvideListeners();
  }
}