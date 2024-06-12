using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using UnityEngine;

namespace Gameplay.LevelSystem.Installer
{
  public class LevelInstaller : GameInstaller
  {
    [Service(typeof(ImageClickHandler))]
    [SerializeField] private ImageClickHandler _imageClickHandler;

    [Service(typeof(LevelLoader))]
    private LevelLoader _levelLoader = new();
  }
}