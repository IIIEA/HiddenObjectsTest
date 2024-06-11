using Gameplay.UI.Level;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using Infrastructure.UI;
using UnityEngine;

namespace Gameplay.UI.Installer
{
  public class UIInstaller : GameInstaller
  {
    [Listener]
    [SerializeField] private LevelsMenuWindow _levelsMenuWindow;
    
    [Service(typeof(LevelWindow))]
    [SerializeField] private LevelWindow _levelWindow;
    
    [Service(typeof(WindowService))]
    private WindowService _windowService = new();

    public override void Inject(ServiceLocator serviceLocator)
    {
      _windowService.AddWindow(_levelsMenuWindow);
      _windowService.AddWindow(_levelWindow);
      
      _windowService.SetActiveWindow(_levelsMenuWindow);
    }
  }
}