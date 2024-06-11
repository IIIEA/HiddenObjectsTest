using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_DownloadingGameData : ILoadingTask
  {
    private const string DOWNLOAD_URL = "https://raw.githubusercontent.com/IIIEA/HiddenObjectsTest/main/LevelsData.json";
    
    public float Weight => 1f;

    public async UniTask Do(Action<LoadingResult> callback)
    {
      UnityWebRequest www = UnityWebRequest.Get(DOWNLOAD_URL);
      
      await www.SendWebRequest().ToUniTask();
      
      if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
      {
        Debug.LogError(www.error);
      }
      else
      {
        string jsonText = www.downloadHandler.text;
        GameData gameData = JsonConvert.DeserializeObject<GameData>(jsonText);
      }
      
      // LoadingScreen.ReportProgress(Weight);
      callback.Invoke(LoadingResult.Success());
    }
  }
}