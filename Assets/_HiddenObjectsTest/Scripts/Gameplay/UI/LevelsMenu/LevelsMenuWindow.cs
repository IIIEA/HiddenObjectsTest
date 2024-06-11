using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.UI;
using UnityEngine;

namespace Gameplay.UI
{
  public class LevelsMenuWindow : MonoBehaviour, IGameStartListener, IWindow
  {
    [SerializeField] private Transform _container;
    [SerializeField] private LevelSlotView _levelSlotView;

    private readonly Dictionary<LevelSlotView, LevelSlotPresenter> _viewPresenters = new();
    
    private ObjectPool<LevelSlotView> _levelsViewPool;
    private ILevelsProvider _levelsProvider;
    private LevelLoader _levelLoader;
    
    [Inject]
    private void Construct(ILevelsProvider levelsProvider, LevelLoader levelLoader)
    {
      _levelLoader = levelLoader;
      _levelsProvider = levelsProvider;
    }

    private void Awake()
    {
      _levelsViewPool = new ObjectPool<LevelSlotView>(_levelSlotView, container: _container);
    }

    private void UpdateInfo()
    {
      Debug.LogError(_levelsProvider.ProvideLevels().Count());
      
      foreach (var levelData in _levelsProvider.ProvideLevels())
      {
        var view = _levelsViewPool.GetInstance();
        var slotLevelPresenter = new LevelSlotPresenter(view, levelData, _levelLoader);
        
        _viewPresenters.Add(view, slotLevelPresenter);
      }
    }

    public void OnStartGame()
    {
      UpdateInfo();
    }

    public void Open()
    {
      UpdateInfo();
      gameObject.SetActive(true);
    }

    public void Close()
    {
      foreach (var keyValuePair in _viewPresenters)
      {
        keyValuePair.Value.Dispose();
        _levelsViewPool.Release(keyValuePair.Key, _container);
      } 

      _viewPresenters.Clear();
      
      gameObject.SetActive(false);
    }
  }
}