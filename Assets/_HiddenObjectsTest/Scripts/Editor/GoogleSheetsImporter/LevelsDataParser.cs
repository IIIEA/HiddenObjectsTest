using System;
using System.Collections.Generic;
using UnityEngine;

namespace GoogleSheetsImporter
{
  public enum LevelsDataHeaderType
  {
    ID,
    LevelName,
    ImageURL,
    ImageName,
    ProgressCounter
  }
  
  public class LevelsDataParser : IGoogleSheetParser<LevelsDataHeaderType>
  {
    private readonly GameData _gameData;
    private LevelConfig _currentlevelConfig;
    
    public LevelsDataParser(GameData gameData)
    {
      _gameData = gameData;
      _gameData.LevelsConfigs = new List<LevelConfig>();
    }
    
    public void Parse(LevelsDataHeaderType header, string token)
    {
      Debug.LogError(token);
      
      switch (header)
      {
        case LevelsDataHeaderType.ID:
          _currentlevelConfig = new LevelConfig()
          {
            ID = int.Parse(token)
          };
          _gameData.LevelsConfigs.Add(_currentlevelConfig);
          break;
        case LevelsDataHeaderType.LevelName:
          _currentlevelConfig.LevelName = token;
          break;
        case LevelsDataHeaderType.ImageURL:
          _currentlevelConfig.ImageURL = token;
          break;
        case LevelsDataHeaderType.ImageName:
          _currentlevelConfig.ImageName = token;
          break;
        case LevelsDataHeaderType.ProgressCounter:
          _currentlevelConfig.ProgressCounter = int.Parse(token);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(header), header, null);
      }
    }
  }
}