using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Attributes;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using WebRequestSystem;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_DownloadingGameData : ILoadingTask
  {
    private GameDataManager _gameDataManager;
    private AssetLoader _assetLoader;

    private const string DOWNLOAD_URL = "https://raw.githubusercontent.com/IIIEA/HiddenObjectsTest/main/LevelsData.json";
    
    public float Weight => 1f;

    [Inject]
    private void Construct(GameDataManager gameDataManager, AssetLoader assetLoader)
    {
      _assetLoader = assetLoader;
      _gameDataManager = gameDataManager;
    }
    
    public async UniTask Do(Action<LoadingResult> callback)
    {
      var jsonText = await _assetLoader.LoadTextAsync(DOWNLOAD_URL);
      
      GameData gameData = JsonUtility.FromJson<GameData>(jsonText);
      _gameDataManager.SetData(gameData);

      // LoadingScreen.ReportProgress(Weight);
      callback.Invoke(LoadingResult.Success());
    }
  }
}