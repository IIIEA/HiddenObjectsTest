using System.Collections.Generic;

namespace Infrastructure.GameManager
{
  public interface IGameListenerProvider
  {
    IEnumerable<IGameListener> ProvideListeners();
  }
}