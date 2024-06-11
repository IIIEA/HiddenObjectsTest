using Infrastructure;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.SaveLoadSystem.SaveLoaders;
using UnityEngine;

namespace Gameplay.UI.LevelsMenu
{
  public class LevelMenuView : MonoBehaviour, IGameStartListener
  {
    [SerializeField] private Transform _container;
    [SerializeField] private LevelSlotView _levelSlotView;

    private ObjectPool<LevelSlotView> _levelsView;
    private ILevelsProvider _levelsProvider;
    private LevelsSaveDataProvider _saveDataProvider;

    [Inject]
    private void Construct(ILevelsProvider levelsProvider, 
      LevelsSaveDataProvider saveDataProvider)
    {
      _saveDataProvider = saveDataProvider;
      _levelsProvider = levelsProvider;
    }

    private void Awake()
    {
      _levelsView = new ObjectPool<LevelSlotView>(_levelSlotView, container: _container);
    }

    private void UpdateInfo()
    {
      foreach (var levelData in _levelsProvider.ProvideLevels())
      {
        var view = _levelsView.GetInstance();
        var slotLevelPresenter = new LevelSlotPresenter(view, levelData, _saveDataProvider);
      }
    }

    public void OnStartGame()
    {
      UpdateInfo();
    }
  }
}