using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace GoogleSheetsImporter
{
  public class ConfigImporterMenu
  {
    private const string SPREADSHEET_ID = "1As5BwjTB_JZlrBqzq6RsxPEtVGTel5GgCUnIOTa82UY";
    private const string LEVELS_SHEET_NAME = "LevelsData";
    private const string CREDENTIALS_PATH = "hidden-objects-test-eec256f03f33.json";

    [MenuItem("GoogleSheetImporter/Import Levels Data")]
    private static async void LoadItemsSettings()
    {
      var sheetImporter = new GoogleSheetsDataImporter(CREDENTIALS_PATH, SPREADSHEET_ID);

      var gameData = new GameData();
      var levelsDataParser = new LevelsDataParser(gameData);
      await sheetImporter.DownloadAndParseSheet(LEVELS_SHEET_NAME, levelsDataParser);

      var jsonForSaving = JsonUtility.ToJson(gameData);
      await System.IO.File.WriteAllTextAsync(Application.persistentDataPath + "/LevelsData.json", jsonForSaving);
      Debug.Log(jsonForSaving);
    }
  }
}