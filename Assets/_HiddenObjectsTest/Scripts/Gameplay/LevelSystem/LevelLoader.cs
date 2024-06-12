using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.UI.Level;
using Infrastructure.UI;

namespace Gameplay.LevelSystem
{
  public class LevelLoader : IDisposable
  {
    private LevelWindow _levelWindow;
    private ImageClickHandler _imageClickHandler;
    private WindowService _windowService;

    private CancellationTokenSource _cancellationTokenSource = new();

    public void Construct(LevelWindow levelWindow, ImageClickHandler imageClickHandler,
      WindowService windowService)
    {
      _levelWindow = levelWindow;
      _imageClickHandler = imageClickHandler;
      _windowService = windowService;
    }

    public void LoadLevel(LevelData levelData)
    {
      _cancellationTokenSource?.Cancel();
      _cancellationTokenSource = new CancellationTokenSource();
      
      var levelPresenter = new LevelPresenter(_levelWindow, levelData)
        .AddTo(_cancellationTokenSource.Token);
      var levelEndGameObserver = new LevelEndGameObserver(levelData, _imageClickHandler, _windowService)
        .AddTo(_cancellationTokenSource.Token);

      _windowService.Open<LevelWindow>();
    }

    public void Dispose()
    {
      _imageClickHandler.Dispose();
      _cancellationTokenSource?.Dispose();
    }
  }
}