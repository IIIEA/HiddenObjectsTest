using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using Infrastructure.SaveLoadSystem.SaveLoaders;
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

      _saveLoadManager.Construct(saveLoaders, _gameRepository, serviceLocator.GetService<GameContext>());
    }

    private ISaveLoader[] GetSaveLoaderList()
    {
      ISaveLoader[] saveLoaders =
      {
        new LevelsSaveLoader()
      };

      return saveLoaders;
    }
  }
}