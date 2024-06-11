using System;
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
      _levelData.OnDataUpdated += UpdateImage;
      UpdateInfo();
    }

    private void OnViewClick() => 
      _levelLoader.LoadLevel(_levelData);

    private void UpdateInfo()
    {
      var infoLoaded = _levelData.Sprite != null;
      
      _view.SetInteractable(infoLoaded);
      _view.SetClose(!infoLoaded);
      _view.AnimateLoading(!infoLoaded);

      if (infoLoaded)
      {
        _view.SetProgress(1f - (float)_levelData.ProgressCounter / _levelData.MaxProgressCounter);
        _view.SetName(_levelData.Name);
        _view.SetBackGround(_levelData.Sprite);
      }
    }

    private void UpdateImage()
    {
      _view.SetBackGround(_levelData.Sprite);
      _view.SetProgress(1f - (float)_levelData.ProgressCounter / _levelData.MaxProgressCounter);
      
      _view.SetClose(false);
      _view.AnimateLoading(false);
      _view.SetInteractable(true);
    }

    public void Dispose()
    {
      _view.RemoveButtonListener(OnViewClick);
      _view = null;
      _levelData.OnDataUpdated -= UpdateImage;
    }
  }
}