using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Row>();

        foreach(var row in csvData.Rows)
        {
            var newRowIntData = new Dictionary<string, int>();
            var newRowFloatData = new Dictionary<string, float>();
            var newRowBoolData = new Dictionary<string, bool>();
            var newRowStringData = new Dictionary<string, string>();
            var newRowData = new Dictionary<string, object>();

            for(int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string cellString = row[columnIndex];

                if(string.IsNullOrEmpty(cellString))
                {
                    continue;
                }
                if(int.TryParse(cellString, out var valueAsInt))
                {
                    newRowIntData[column] = valueAsInt;
                }
                else if(float.TryParse(cellString, out var valueAsFloat))
                {
                    newRowFloatData[column] = valueAsFloat;
                }
                else if(cellString == "TRUE")
                {
                    newRowBoolData[column] = true;
                }
                else if(cellString == "FALSE")
                {
                    newRowBoolData[column] = false;
                }
                else
                    newRowStringData[column] = cellString;
            }

            resultRows.Add(new Row(newRowData, newRowStringData, newRowIntData, newRowFloatData, newRowBoolData));
        }
        return new TableData(csvData.Columns, resultRows);
    }
}