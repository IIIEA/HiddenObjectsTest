using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using WebRequestSystem;

public class GameDataManager : ILevelsProvider
{
  private readonly List<LevelData> _levels = new();
  private AssetLoader _assetLoader;

  public void Construct(AssetLoader assetLoader)
  {
    _assetLoader = assetLoader;
  }

  public void SetData(GameData gameData)
  {
    SetupLevelsData(gameData.LevelsConfigs);
  }

  public IEnumerable<LevelData> ProvideLevels()
  {
    foreach (var levelData in _levels)
    {
      yield return levelData;
    }
  }

  public void SetupSavesData(IEnumerable<(int ID,int Progress)> levelsProgress)
  {
    foreach (var data in levelsProgress)
    {
      var levelData = _levels.FirstOrDefault(x => x.ID == data.ID);

      if (levelData != null)
        levelData.ProgressCounter = data.Progress;
    }
  }

  private void SetupLevelsData(IEnumerable<LevelConfig> levelConfigs)
  {
    foreach (var levelConfig in levelConfigs)
    {
      var levelData = new LevelData()
      {
        ID = levelConfig.ID,
        Name = levelConfig.LevelName,
        MaxProgressCounter = levelConfig.ProgressCounter,
        ProgressCounter = levelConfig.ProgressCounter
      };

      UpdateNetworkData(levelData, levelConfig).Forget();
      _levels.Add(levelData);
    }
  }

  private async UniTaskVoid UpdateNetworkData(LevelData levelData, LevelConfig levelConfig)
  {
    var sprite = await _assetLoader.LoadSpriteAsync(levelConfig.ImageURL);
    levelData.Sprite = sprite;
  }
}