using System;
using System.Collections.Generic;

namespace GoogleSheetsImporter
{
  public enum LevelsDataHeaderType
  {
    ID,
    ImageURL,
    ImageName,
    ProgressCounter
  }
  
  public class LevelsDataParser : IGoogleSheetParser<LevelsDataHeaderType>
  {
    private readonly GameData _gameData;
    private LevelData _currentlevelData;
    
    public LevelsDataParser(GameData gameData)
    {
      _gameData = gameData;
      _gameData.LevelsData = new List<LevelData>();
    }
    
    public void Parse(LevelsDataHeaderType header, string token)
    {
      switch (header)
      {
        case LevelsDataHeaderType.ID:
          _currentlevelData = new LevelData()
          {
            ID = int.Parse(token)
          };
          _gameData.LevelsData.Add(_currentlevelData);
          break;
        case LevelsDataHeaderType.ImageURL:
          _currentlevelData.ImageURL = token;
          break;
        case LevelsDataHeaderType.ImageName:
          _currentlevelData.ImageName = token;
          break;
        case LevelsDataHeaderType.ProgressCounter:
          _currentlevelData.ProgressCounter = int.Parse(token);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(header), header, null);
      }
    }
  }
}