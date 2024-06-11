using Infrastructure.Locator;

namespace Infrastructure.GameManagment
{
  public interface IInjectProvider
  {
    void Inject(ServiceLocator serviceLocator);
  }
}