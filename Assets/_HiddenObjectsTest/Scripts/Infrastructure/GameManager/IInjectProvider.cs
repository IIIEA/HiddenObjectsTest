using Infrastructure.Locator;

namespace Infrastructure.GameManager
{
  public interface IInjectProvider
  {
    void Inject(ServiceLocator serviceLocator);
  }
}