using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_FinishLoading : ILoadingTask
  {
    public float Weight { get; private set; } = 1f;

    public async UniTask Do(Action<LoadingResult> callback)
    {
      await UniTask.WaitForSeconds(1f);

      // LoadingScreen.ReportProgress(Weight);
      callback.Invoke(LoadingResult.Success());
    }
  }
}