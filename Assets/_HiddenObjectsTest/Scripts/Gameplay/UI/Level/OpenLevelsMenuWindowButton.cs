using Infrastructure.Attributes;
using Infrastructure.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Level
{
  public class OpenLevelsMenuWindowButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    
    private WindowService _windowService;

    [Inject]
    private void Construct(WindowService windowService) => 
      _windowService = windowService;

    private void OnEnable() => 
      _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => 
      _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick() => 
      _windowService.Open<LevelsMenuWindow>();
  }
}