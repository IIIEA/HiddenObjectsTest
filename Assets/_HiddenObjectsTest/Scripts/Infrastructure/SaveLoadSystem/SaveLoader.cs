using Infrastructure.GameManager;

namespace Infrastructure.SaveLoadSystem
{
  public abstract class SaveLoader<TData, TService> : ISaveLoader
  {
    public void LoadGame(IGameRepository gameRepository, GameContext gameContext)
    {
      // var service = gameServices.GetSingle<TService>();
      //
      // if (gameRepository.TryGetData(out TData data))
      // {
      //   SetupData(service, data);
      //   Debug.Log($"<color=green>Data loaded: {typeof(TData).Name}</color>"); 
      // }
      // else
      // {
      //   SetupDefaultData(service);
      //   Debug.Log($"<color=green>Default data setted: {service.GetType().Name}</color>");
      // }
    }

    public void SaveGame(IGameRepository gameRepository, GameContext gameContext)
    {
      // var service = gameServices.GetSingle<TService>();
      // var data = ConvertToData(service);
      // gameRepository.SetData(data);
      //
      // Debug.Log($"<color=green>Data saved: {typeof(TData)}</color>");
    }

    protected abstract TData ConvertToData(TService service);
    protected abstract void SetupData(TService service, TData data);
    protected abstract void SetupDefaultData(TService service);
  }
}