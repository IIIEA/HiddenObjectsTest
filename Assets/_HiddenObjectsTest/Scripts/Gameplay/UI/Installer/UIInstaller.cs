using Gameplay.UI.LevelsMenu;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using UnityEngine;

namespace Gameplay.UI.Installer
{
  public class UIInstaller : GameInstaller
  {
    [Listener]
    [SerializeField] private LevelMenuView _levelMenuView;
  }
}