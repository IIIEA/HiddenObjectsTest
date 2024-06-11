using Gameplay.UI.Level;
using Infrastructure.Locator;
using Infrastructure.UI;

namespace Gameplay
{
  public class LevelLoader
  {
    private LevelWindow _levelWindow;
    private ImageClickHandler _imageClickHandler;
    private WindowService _windowService;
    
    public void Construct(LevelWindow levelWindow, ImageClickHandler imageClickHandler,
      WindowService windowService)
    {
      _levelWindow = levelWindow;
      _imageClickHandler = imageClickHandler;
      _windowService = windowService;
    }
    
    public void LoadLevel(LevelData levelData)
    {
      var levelPresenter = new LevelPresenter(_levelWindow, levelData, _imageClickHandler, _windowService);
      _windowService.Open<LevelWindow>();
    }
  }
}