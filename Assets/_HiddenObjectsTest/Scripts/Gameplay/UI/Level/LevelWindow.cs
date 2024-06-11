using System;
using Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Level
{
  public class LevelWindow : MonoBehaviour, IWindow
  {
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TMP_Text _counterText;

    public event Action OnOpened;
    public event Action OnClosed;
    
    public void SetImage(Sprite sprite) => 
      _backgroundImage.sprite = sprite;

    public void SetCounter(string counter) => 
      _counterText.text = counter;

    public void Open()
    {
      gameObject.SetActive(true);
      OnOpened?.Invoke();
    }

    public void Close()
    {
      gameObject.SetActive(false);
      OnClosed?.Invoke();
    }
  }
}