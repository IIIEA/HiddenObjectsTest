using Infrastructure.Attributes;
using Infrastructure.GameManager;
using Infrastructure.Locator;
using Sirenix.OdinInspector;

namespace Infrastructure.SaveLoadSystem.Installer
{
  public class SaveLoaderModuleInstaller : GameInstaller
  {
    [Service(typeof(SaveLoadManager))]
    private SaveLoadManager _saveLoadManager = new();

    [ShowInInspector, Service(typeof(GameRepository))]
    private GameRepository _gameRepository = new();

    public override void Inject(ServiceLocator serviceLocator)
    {
      var saveLoaders = GetSaveLoaderList();

      _saveLoadManager.Construct(saveLoaders, _gameRepository);
    }

    private ISaveLoader[] GetSaveLoaderList()
    {
      ISaveLoader[] saveLoaders =
      {

      };

      return saveLoaders;
    }
  }
}