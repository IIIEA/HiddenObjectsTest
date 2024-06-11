using System.Collections.Generic;

namespace Infrastructure.SaveLoadSystem.SaveLoaders
{
  public class LevelsSaveDataProvider
  {
    private Dictionary<int, int> _levelsSaveData = new();

    public bool TryGetProgressById(int id, out int progress)
    {
      if (_levelsSaveData.TryGetValue(id, out var value))
      {
        progress = value;
        return true;
      }

      progress = default;
      return false;
    }

    public void SetProgressById(int id, int progress) => 
      _levelsSaveData[id] = progress;

    public Dictionary<int, int> Provide() => 
      new(_levelsSaveData);

    public void SetData(Dictionary<int, int> data) => 
      _levelsSaveData = data;
  }
}