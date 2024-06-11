using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay
{
  public class ImageClickHandler : MonoBehaviour, IPointerDownHandler, IDisposable
  {
    private Action _onClickAction;
    
    public void OnPointerDown(PointerEventData eventData) => 
      _onClickAction?.Invoke();

    public void SetEvent(Action onClickAction) => 
      _onClickAction = onClickAction;

    public void Dispose() => 
      _onClickAction = null;
  }
}