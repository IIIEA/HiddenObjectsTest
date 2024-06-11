using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using Infrastructure.UI;
using UnityEngine;

namespace Gameplay.UI.Level
{
  public class LevelInstaller : GameInstaller
  {
    [SerializeField] private ImageClickHandler _imageClickHandler;

    [Service(typeof(LevelLoader))]
    private LevelLoader _levelLoader = new();

    public override void Inject(ServiceLocator serviceLocator)
    {
      var windowService = serviceLocator.GetService<WindowService>();
      var levelWindow = serviceLocator.GetService<LevelWindow>();
      
      _levelLoader.Construct(levelWindow, _imageClickHandler, windowService);
    }
  }
}