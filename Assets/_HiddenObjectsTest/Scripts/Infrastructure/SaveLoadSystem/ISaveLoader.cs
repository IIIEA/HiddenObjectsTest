using Infrastructure.GameManagment;

namespace Infrastructure.SaveLoadSystem
{
  public interface ISaveLoader
  {
    void LoadGame(IGameRepository gameRepository, GameContext gameContext);
    void SaveGame(IGameRepository gameRepository, GameContext gameContext);
  }
}