using Infrastructure.Attributes;
using Infrastructure.GameManagment;

namespace Infrastructure.SaveLoadSystem
{
  public sealed class SaveLoadManager
  {
    private ISaveLoader[] _saveLoaders;
    private GameRepository _repository;
    private GameContext _gameContext;

    [Inject]
    public void Construct(ISaveLoader[] saveLoaders, GameRepository repository, GameContext gameContext)
    {
      _gameContext = gameContext;
      _saveLoaders = saveLoaders;
      _repository = repository;
    }
    
    public void Save()
    {
      if (_saveLoaders == null)
        return;

      foreach (var saveLoader in _saveLoaders)
      {
        saveLoader.SaveGame(_repository, _gameContext);
      }

      _repository.SaveState();
    }

    public void Load()
    {
      _repository.LoadState();
      
      foreach (var saveLoader in _saveLoaders)
      {
        saveLoader.LoadGame(_repository, _gameContext);
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
      if (pauseStatus)
      {
          Save();
      }
    }

    private void OnApplicationQuit()
    {
      Save();
    }
  }
}