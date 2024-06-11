using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.ApplicationLoader
{
  public interface ILoadingTask
  {
    float Weight { get; }
    UniTask Do(Action<LoadingResult> callback);
  }

  public readonly struct LoadingResult
  {
    public readonly bool IsSuccess;
    public readonly string Error;

    private LoadingResult(bool success, string error)
    {
      IsSuccess = success;
      Error = error;
    }

    public static LoadingResult Success()
    {
      return new LoadingResult(true, null);
    }

    public static LoadingResult Fail(string error)
    {
      return new LoadingResult(false, error);
    }
  }
}