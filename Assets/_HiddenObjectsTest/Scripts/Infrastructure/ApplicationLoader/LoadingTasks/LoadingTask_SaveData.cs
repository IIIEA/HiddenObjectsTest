using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Infrastructure.ApplicationLoader.LoadingTasks
{
  [UsedImplicitly]
  public sealed class LoadingTask_SaveData : ILoadingTask
  {
    public float Weight { get; private set; } = 0.7f;

    public async UniTask Do(Action<LoadingResult> callback)
    {
      await UniTask.CompletedTask;

      callback.Invoke(LoadingResult.Success());
    }
  }
}