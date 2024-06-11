using System;
using Infrastructure.SaveLoadSystem;
using Infrastructure.SaveLoadSystem.SaveLoaders;

namespace Gameplay.UI.LevelsMenu
{
  public class LevelSlotPresenter : IDisposable
  {
    private LevelSlotView _view;
    private readonly LevelsSaveDataProvider _levelsProvider;
    private readonly LevelData _levelData;
    private readonly GameRepository _gameRepository;

    public LevelSlotPresenter(LevelSlotView view, LevelData levelData,
      LevelsSaveDataProvider levelsProvider)
    {
      _view = view;
      _levelData = levelData;
      _levelsProvider = levelsProvider;

      _levelData.OnDataUpdated += UpdateImage;
      UpdateInfo();
    }

    private void UpdateInfo()
    {
      _levelsProvider.TryGetProgressById(_levelData.ID, out int progress);
      _view.SetProgress((float)progress / _levelData.ProgressCounter);
      _view.SetName(_levelData.Name);
      _view.SetInteractable(false);
      _view.SetBackGround(_levelData.Sprite);
      _view.SetClose(true);
      _view.AnimateLoading(true);
    }

    private void UpdateImage()
    {
      _view.SetBackGround(_levelData.Sprite);
      _view.SetClose(false);
      _view.AnimateLoading(false);
      _view.SetInteractable(true);
    }

    public void Dispose()
    {
      _view = null;
      _levelData.OnDataUpdated -= UpdateImage;
    }
  }
}