using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.LevelsMenu
{
  public class LevelSlotView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _background;
    [SerializeField] private Image _progressImage;
    [SerializeField] private Button _button;

    public void SetProgress(float progress) => 
      _progressImage.fillAmount = progress;

    public void SetBackGround(Sprite background) => 
      _background.sprite = background;

    public void SetName(string name) => 
      _name.text = name;
  }
}