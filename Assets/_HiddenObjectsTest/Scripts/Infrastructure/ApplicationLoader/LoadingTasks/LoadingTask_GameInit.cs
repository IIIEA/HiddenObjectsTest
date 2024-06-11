using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using JetBrains.Annotations;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_GameInit : ILoadingTask
  {
    private GameContext _gameContext;

    public float Weight { get; private set; } = 0.5f;

    [Inject]
    private void Construct(GameContext gameContext)
    {
      _gameContext = gameContext;
    }

    public UniTask Do(Action<LoadingResult> callback)
    {
      // LoadingScreen.ReportProgress(Weight);
      _gameContext.StartInject();
      callback.Invoke(LoadingResult.Success());

      return UniTask.CompletedTask;
    }
  }
}