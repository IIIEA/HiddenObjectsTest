using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using UnityEngine;

namespace Infrastructure.ApplicationLoader
{
  public sealed class ApplicationLoader : MonoBehaviour
  {
    [SerializeField] private bool _isLoadOnStart;
    [SerializeField] private ServiceLocator _serviceLocator;
    [SerializeField] private LoadingPipeline _pipeline;

    private List<ILoadingTask> _loadingTasks = new();

    public Action<float> OnProgressChanged;
    public event Action OnLoadingCompleted;
    public event Action<string> OnLoadingFailed;

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

        LoadingResult result = await tcs.Task;

        if (!result.IsSuccess)
        {
          LoadingScreen.ReportError(result.Error);
          return;
        }
      }

      LoadingScreen.Hide();
      OnLoadingCompleted?.Invoke();
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
  }
}