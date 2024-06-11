using System.Linq;

namespace Infrastructure.SaveLoadSystem.SaveLoaders
{
  public class LevelsSaveLoader : SaveLoader<LevelsSaveData, GameDataManager>
  {
    protected override LevelsSaveData ConvertToData(GameDataManager service)
    {
      LevelsSaveData levelsSaveData = new LevelsSaveData();
      
      foreach (var levelData in service.ProvideLevels())
      {
        levelsSaveData.LevelsProgress.Add(levelData.ID, levelData.ProgressCounter);
      }

      return levelsSaveData;
    }

    protected override void SetupData(GameDataManager service, LevelsSaveData data)
    {
      var levelsProgressData = data.LevelsProgress.Select(o => (o.Key, o.Value));
      
      service.SetupSavesData(levelsProgressData);
    }
  }
}