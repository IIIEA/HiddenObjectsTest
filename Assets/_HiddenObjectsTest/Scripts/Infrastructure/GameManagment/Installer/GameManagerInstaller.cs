using Infrastructure.Attributes;
using UnityEngine;

namespace Infrastructure.GameManagment.Installer
{
  public class GameManagerInstaller : GameInstaller
  {
    [SerializeField, Service(typeof(GameManager))]
    private GameManager _gameManager;

    [SerializeField, Service(typeof(GameContext))]
    private GameContext _gameContext;
  }

}