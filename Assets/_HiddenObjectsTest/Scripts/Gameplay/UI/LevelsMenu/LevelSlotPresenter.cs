using System;
using Gameplay.LevelSystem;
using Infrastructure.SaveLoadSystem;

namespace Gameplay.UI
{
  public class LevelSlotPresenter : IDisposable
  {
    private LevelSlotView _view;
    private readonly LevelLoader _levelLoader;
    private readonly LevelData _levelData;
    private readonly GameRepository _gameRepository;

    public LevelSlotPresenter(LevelSlotView view, LevelData levelData,
      LevelLoader levelLoader)
    {
      _view = view;
      _levelData = levelData;
      _levelLoader = levelLoader;

      _view.AddButtonListener(OnViewClick);
      _levelData.OnImageUpdated += ShowLoaded;
      _levelData.OnProgressChanged += OnProgressChanged;
      UpdateInfo();
    }

    private void OnProgressChanged(int progress)
    {
      ShowLoaded();
    }

    private void OnViewClick() =>
      _levelLoader.LoadLevel(_levelData);

    private void UpdateInfo()
    {
      var infoLoaded = _levelData.Sprite != null;

      if (infoLoaded)
        ShowLoaded();
      else
        ShowUnloaded();
    }

    private void ShowLoaded()
    {
      var isCompleted = _levelData.ProgressCounter <= 0;

      _view.SetInteractable(!isCompleted);
      _view.SetClose(false);
      _view.AnimateLoading(false);

      _view.SetProgress(1f - (float)_levelData.ProgressCounter / _levelData.MaxProgressCounter);
      _view.SetName(isCompleted ? "Completed" : _levelData.Name);
      _view.SetBackGround(_levelData.Sprite);
    }

    private void ShowUnloaded()
    {
      _view.SetInteractable(false);
      _view.SetClose(true);
      _view.AnimateLoading(true);
    }

    public void Dispose()
    {
      _view.RemoveButtonListener(OnViewClick);
      _view = null;
      _levelData.OnImageUpdated -= ShowLoaded;
      _levelData.OnProgressChanged -= OnProgressChanged;
    }
  }
}