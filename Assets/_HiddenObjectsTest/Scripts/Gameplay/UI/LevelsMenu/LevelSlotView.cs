using DG.Tweening;
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
    [SerializeField] private Image _closeImage;
    [SerializeField] private Image _loadingImage;

    private Tween _tween;
    
    public void SetProgress(float progress) => 
      _progressImage.fillAmount = progress;

    public void SetBackGround(Sprite background) => 
      _background.sprite = background;

    public void SetName(string name) => 
      _name.text = name;

    public void SetInteractable(bool isInteractable) => 
      _button.interactable = isInteractable;

    public void SetClose(bool isClosed) => 
      _closeImage.gameObject.SetActive(isClosed);

    public void SetCloseImage(Sprite sprite) => 
      _closeImage.sprite = sprite;

    public void AnimateLoading(bool isLoading)
    {
      _loadingImage.gameObject.SetActive(isLoading);

      if (isLoading)
      {
        _tween = _loadingImage.transform.DOLocalRotate(new Vector3(0, 0, -180), 25f)
          .SetSpeedBased()
          .SetLoops(-1, LoopType.Incremental)
          .SetLink(_loadingImage.gameObject);
      }
      else
      {
        _tween?.Complete();
      }
    }
  }
}