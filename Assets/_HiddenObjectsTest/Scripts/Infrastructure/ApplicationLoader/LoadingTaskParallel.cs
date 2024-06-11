using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Infrastructure.ApplicationLoader
{
  public class LoadingTaskParallel : ILoadingTask
  {
    public float Weight { get; }

    private readonly IReadOnlyList<ILoadingTask> _childrens;

    private Action<LoadingResult> _callback;
    private int _pointer;

    public LoadingTaskParallel(IReadOnlyList<ILoadingTask> children)
    {
      _childrens = children;
    }

    public async UniTask Do(Action<LoadingResult> callback)
    {
      foreach (var child in _childrens)
      {
        await child.Do(OnTaskCompleted);
      }
    }

    private void OnTaskCompleted(LoadingResult result)
    {
      if (result.IsSuccess)
      {
        _callback?.Invoke(result);
        _callback = null;
        return;
      }

      _pointer++;

      if (_pointer >= _childrens.Count)
        _callback.Invoke(LoadingResult.Success());
    }
  }
}