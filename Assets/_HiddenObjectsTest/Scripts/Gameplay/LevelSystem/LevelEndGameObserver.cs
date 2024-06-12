using System;
using Gameplay.UI;
using Infrastructure.UI;

namespace Gameplay.LevelSystem
{
  public class LevelEndGameObserver : IDisposable
  {
    private LevelData _levelData;
    private ImageClickHandler _clickHandler;
    private WindowService _windowService;

    public LevelEndGameObserver(LevelData levelData, ImageClickHandler clickHandler, WindowService windowService)
    {
      _levelData = levelData;
      _clickHandler = clickHandler;
      _windowService = windowService;
      
      _clickHandler.SetEvent(OnClick);
    }
    
    private void OnClick()
    {
      _levelData.ProgressCounter--;
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
      _clickHandler.Dispose();
      _levelData = null;
      _windowService = null;
      _clickHandler = null;
    }
  }
}