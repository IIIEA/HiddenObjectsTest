using Infrastructure.Attributes;
using Infrastructure.GameManager;

namespace Infrastructure.SaveLoadSystem
{
  public sealed class SaveLoadManager
  {
    private ISaveLoader[] _saveLoaders;
    private GameRepository _repository;

    [Inject]
    public void Construct(ISaveLoader[] saveLoaders, GameRepository repository)
    {
      _saveLoaders = saveLoaders;
      _repository = repository;
    }
    
    public void Save()
    {
      GameContext context = default;

      if (_saveLoaders == null)
        return;

      foreach (var saveLoader in _saveLoaders)
      {
        saveLoader.SaveGame(_repository, context);
      }

      _repository.SaveState();
    }

    public void Load()
    {
      _repository.LoadState();

      GameContext context = default;

      foreach (var saveLoader in _saveLoaders)
      {
        saveLoader.LoadGame(_repository, context);
      }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
      if (!hasFocus)
      {
        Save();
      }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
      // if (pauseStatus)
      // {
      //     Save();
      // }
    }

    private void OnApplicationQuit()
    {
      Save();
    }
  }
}