﻿using System.Collections.Generic;
using Infrastructure.Attributes;
using Infrastructure.GameManagment;
using Infrastructure.Locator;
using WebRequestSystem;

public class GameDataInstaller : GameInstaller
{
    [Service(typeof(GameDataManager), typeof(ILevelsProvider))]
    private GameDataManager _gameDataManager = new();

    [Service(typeof(AssetLoader))]
    private AssetLoader _assetLoader = new();

    public override void Inject(ServiceLocator serviceLocator)
    {
      _gameDataManager.Construct(_assetLoader);
    }
}

public interface ILevelsProvider
{
  IEnumerable<LevelData> ProvideLevels();
}