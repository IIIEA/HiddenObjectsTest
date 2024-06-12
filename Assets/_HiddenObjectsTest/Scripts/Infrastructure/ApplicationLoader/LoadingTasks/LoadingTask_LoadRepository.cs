using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.SaveLoadSystem;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  public sealed class LoadingTaskLoadRepository : ILoadingTask
  {
    private SaveLoadManager _saveLoadManager;
    private GameManager _gameManager;
    
    public float Weight { get; private set; } = 0.75f;
    
    [Inject]
    private void Construct(SaveLoadManager saveLoadManager, GameManager gameManager)
    {
        _gameManager = gameManager;
        _saveLoadManager = saveLoadManager;
    }

    public UniTask Do(Action<LoadingResult> callback)
    {
      LoadingScreen.ReportProgress(Weight);
      
      _saveLoadManager.Load();
      _gameManager.StartGame();
      callback?.Invoke(LoadingResult.Success());
      
      return UniTask.CompletedTask;
    }
  }
}