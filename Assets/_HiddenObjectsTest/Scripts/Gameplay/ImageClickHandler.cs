using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay
{
  public class ImageClickHandler : MonoBehaviour, IPointerDownHandler
  {
    private Action _onClickAction;
    
    public void OnPointerDown(PointerEventData eventData)
    {
      _onClickAction?.Invoke();
    }

    public void SetEvent(Action onClickAction)
    {
      _onClickAction = onClickAction;
    }
  }
}