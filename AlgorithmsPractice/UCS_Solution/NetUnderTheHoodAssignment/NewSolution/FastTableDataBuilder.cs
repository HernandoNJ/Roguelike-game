using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultFastRows = new List<FastRow>();

        foreach(var FastRow in csvData.Rows)
        {
            var newRow = new FastRow();

            for(int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = FastRow[columnIndex];

                if(string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if(int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRow.AssignCell(column, valueAsInt);
                }
                else if(float.TryParse(valueAsString, out var valueAsFloat))
                {
                    newRow.AssignCell(column, valueAsFloat);
                }
                else if(valueAsString == "TRUE")
                {
                    newRow.AssignCell(column, true);
                }
                else if(valueAsString == "FALSE")
                {
                    newRow.AssignCell(column, false);
                }
                else
                {
                    newRow.AssignCell(column, valueAsString);
                }
            }

            resultFastRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultFastRows);
    }
}