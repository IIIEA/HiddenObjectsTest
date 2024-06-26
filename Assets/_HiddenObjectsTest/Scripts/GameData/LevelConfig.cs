﻿using System;
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
  private int _progress;
  
  public int ID;
  public string Name;
  public int MaxProgressCounter;

  public int ProgressCounter
  {
    get => _progress;
    set
    {
      _progress = value;
      OnProgressChanged?.Invoke(_progress);
    }
  }
  
  
  public Sprite Sprite
  {
    get => _sprite;
    set
    {
      _sprite = value;
      OnImageUpdated?.Invoke();
    }
  }

  public event Action<int> OnProgressChanged;
  public event Action OnImageUpdated;
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