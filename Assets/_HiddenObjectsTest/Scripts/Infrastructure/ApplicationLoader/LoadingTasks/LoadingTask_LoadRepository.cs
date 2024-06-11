using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Attributes;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  public sealed class LoadingTaskLoadRepository : ILoadingTask
  {
    // private SaveLoadManager _saveLoadManager;
    // private GameManager.GameManager _gameManager;
    //
    public float Weight { get; private set; } = 0.7f;
    //
    // [Inject]
    // private void Construct(SaveLoadManager saveLoadManager, GameManager.GameManager gameManager)
    // {
    //     _gameManager = gameManager;
    //     _saveLoadManager = saveLoadManager;
    // }

    public async UniTask Do(Action<LoadingResult> callback)
    {
      await UniTask.WaitForSeconds(0.5f);

      // LoadingScreen.ReportProgress(Weight);
      // _saveLoadManager.Load();
      // _gameManager.StartGame();
      callback?.Invoke(LoadingResult.Success());
    }
  }
}