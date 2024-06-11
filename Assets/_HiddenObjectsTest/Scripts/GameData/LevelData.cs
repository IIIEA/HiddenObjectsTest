using System;
using System.Collections.Generic;

[Serializable]
public struct LevelData
{
  public int ID;
  public string ImageURL;
  public string ImageName;
  public int ProgressCounter;
}

[Serializable]
public struct LevelsData
{
  public List<LevelData> Levels;
}