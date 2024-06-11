namespace Infrastructure.SaveLoadSystem.SaveLoaders
{
  public class LevelsSaveLoader : SaveLoader<LevelsSaveData, LevelsSaveDataProvider>
  {
    protected override LevelsSaveData ConvertToData(LevelsSaveDataProvider service)
    {
      return new LevelsSaveData(levelsProgress: service.Provide());
    }

    protected override void SetupData(LevelsSaveDataProvider service, LevelsSaveData data)
    {
      service.SetData(data.LevelsProgress);
    }
  }
}