using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public record LevelConfig
{
  public int ID;
  public string LevelName;
  public string ImageURL;
  public string ImageName;
  public int ProgressCounter;
}

public record LevelData
{
  private Sprite _sprite;
  
  public int ID;
  public string Name;
  public int ProgressCounter;
  
  public Sprite Sprite
  {
    get => _sprite;
    set
    {
      _sprite = value;
      OnDataUpdated?.Invoke();
    }
  }

  public event Action OnDataUpdated;
}

[Serializable]
public struct LevelsSaveData
{
  public Dictionary<int, int> LevelsProgress;

  public LevelsSaveData(Dictionary<int, int> levelsProgress)
  {
    LevelsProgress = levelsProgress;
  }
}