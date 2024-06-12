using System.Collections.Generic;

public interface ILevelsProvider
{
  IEnumerable<LevelData> ProvideLevels();
}