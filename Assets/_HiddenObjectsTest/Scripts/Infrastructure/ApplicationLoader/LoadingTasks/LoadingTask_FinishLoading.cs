using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_FinishLoading : ILoadingTask
  {
    public float Weight { get; private set; } = 1f;

    public UniTask Do(Action<LoadingResult> callback)
    {
      // LoadingScreen.ReportProgress(Weight);
      callback.Invoke(LoadingResult.Success());
      
      return UniTask.CompletedTask;
    }
  }
}