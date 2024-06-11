using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;

namespace GoogleSheetsImporter
{
  public class GoogleSheetsDataImporter
  {
    private readonly SheetsService _service;
    private readonly string _spreadsheetId;

    public GoogleSheetsDataImporter(string credentialsPath, string spreadsheetId)
    {
      _spreadsheetId = spreadsheetId;

      GoogleCredential credential;
      using (var stream = new System.IO.FileStream(credentialsPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
      {
        credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);
      }

      _service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential
      });
    }

    public async Task DownloadAndParseSheet<T>(string sheetName, IGoogleSheetParser<T> parser) where T : struct
    {
      Debug.Log($"Starting downloading sheet (${sheetName})...");

      var range = $"{sheetName}!A1:Z";
      var request = _service.Spreadsheets.Values.Get(_spreadsheetId, range);

      ValueRange response;
      try
      {
        response = await request.ExecuteAsync();
      }
      catch (System.Exception e)
      {
        Debug.LogError($"Error retrieving Google Sheets data: {e.Message}");
        return;
      }

      if (response is { Values: not null })
      {
        var headers = new List<string>();

        var tableArray = response.Values;
        Debug.Log($"Sheet downloaded successfully: {sheetName}. Parsing started.");

        var firstRow = tableArray[0];
        foreach (var cell in firstRow)
        {
          headers.Add(cell.ToString());
        }

        var rowsCount = tableArray.Count;
        for (var i = 1; i < rowsCount; i++)
        {
          var row = tableArray[i];
          var rowLength = row.Count;

          for (var j = 0; j < rowLength; j++)
          {
            var cell = row[j];
            var header = headers[j];

            if (Enum.TryParse(header, out T result))
            {
              parser.Parse(result, cell.ToString());
            }
          }
        }

        Debug.Log($"Sheet parsed successfully.");
      }
      else
      {
        Debug.LogWarning("No data found in Google Sheets.");
      }
    }
  }
}