using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using UnityEngine;

namespace Infrastructure.ApplicationLoader
{
  public sealed class ApplicationLoader : MonoBehaviour, IDisposable
  {
    [SerializeField] private bool _isLoadOnStart;
    [SerializeField] private ServiceLocator _serviceLocator;
    [SerializeField] private LoadingPipeline _pipeline;

    private CancellationTokenSource _cancellationToken = new ();
    private List<ILoadingTask> _loadingTasks = new();

    public Action<float> OnProgressChanged;

    private void Start()
    {
      if (_isLoadOnStart)
      {
        LoadApplication();
      }
    }

    private async void LoadApplication()
    {
      LoadingScreen.Show();
      CreateTasks(_pipeline.GetTaskList());

      foreach (ILoadingTask task in _loadingTasks)
      {
        var tcs = new TaskCompletionSource<LoadingResult>();
        task.Do(result => tcs.TrySetResult(result));

        var uniTask = tcs.Task;
        uniTask.AddTo(_cancellationToken.Token);
        
        LoadingResult result = await uniTask;

        if (!result.IsSuccess)
        {
          LoadingScreen.ReportError(result.Error);
          return;
        }
      }

      LoadingScreen.Hide();
    }

    private void CreateTasks(Type[] tasks)
    {
      foreach (Type taskType in tasks)
      {
        var instance = Activator.CreateInstance(taskType);
        ILoadingTask task = (ILoadingTask)instance;
        DependencyInjector.Inject(instance, _serviceLocator);
        _loadingTasks.Add(task);
      }
    }

    public void Dispose()
    {
      _cancellationToken?.Dispose();
    }
  }
}