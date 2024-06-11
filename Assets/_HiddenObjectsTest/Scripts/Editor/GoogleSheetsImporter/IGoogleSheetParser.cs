using System;

namespace GoogleSheetsImporter
{
  public interface IGoogleSheetParser<T> where T : struct
  {
    void Parse(T header, string token);
  }
}