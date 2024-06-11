using System;
using Infrastructure.UI;

namespace Gameplay.UI.Level
{
  public class LevelPresenter : IDisposable
  {
    private LevelWindow _levelWindow;
    private LevelData _levelData;
    private readonly ImageClickHandler _clickHandler;
    private readonly WindowService _windowService;

    public LevelPresenter(LevelWindow levelWindow, LevelData levelData,
      ImageClickHandler clickHandler, WindowService windowService)
    {
      _levelWindow = levelWindow;
      _levelData = levelData;
      _clickHandler = clickHandler;
      _windowService = windowService;

      SetupLevel();
      _clickHandler.SetEvent(OnClick);
      _levelWindow.OnOpened += SetupLevel;
      _levelWindow.OnClosed += Dispose;
    }

    private void SetupLevel()
    {
      _levelWindow.SetCounter(_levelData.ProgressCounter.ToString());
      _levelWindow.SetImage(_levelData.Sprite);
    }

    private void OnClick()
    {
      _levelData.ProgressCounter--;
      _levelWindow.SetCounter(_levelData.ProgressCounter.ToString());
      CheckEndGame(_levelData.ProgressCounter);
    }

    private void CheckEndGame(int counter)
    {
      if (counter <= 0)
      {
        _windowService.Open<LevelsMenuWindow>();
      }
    }

    public void Dispose()
    {
      _levelWindow.OnOpened -= SetupLevel;
      _levelWindow.OnClosed -= Dispose;
      
      _clickHandler.Dispose();
      _levelWindow = null;
      _levelData = null;
    }
  }
}