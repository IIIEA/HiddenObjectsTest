using System;

namespace Gameplay.UI.Level
{
  public class LevelPresenter : IDisposable
  {
    private LevelWindow _levelWindow;
    private LevelData _levelData;

    public LevelPresenter(LevelWindow levelWindow, LevelData levelData)
    {
      _levelWindow = levelWindow;
      _levelData = levelData;

      _levelData.OnProgressChanged += OnProgressChanged;
      _levelWindow.OnOpened += SetupLevel;
    }

    private void OnProgressChanged(int progress)
    {
      _levelWindow.SetCounter(progress.ToString());
    }

    private void SetupLevel()
    {
      _levelWindow.SetCounter(_levelData.ProgressCounter.ToString());
      _levelWindow.SetImage(_levelData.Sprite);
    }

    public void Dispose()
    {
      _levelData.OnProgressChanged -= OnProgressChanged;
      _levelWindow.OnOpened -= SetupLevel;

      _levelWindow = null;
      _levelData = null;
    }
  }
}