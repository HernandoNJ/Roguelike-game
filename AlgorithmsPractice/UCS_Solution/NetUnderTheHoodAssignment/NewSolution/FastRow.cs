namespace CsvDataAccess.NewSolution;

public class FastRow
{
    // Each time a value is stored, it is boxed, taking time and memory
    // private Dictionary<string, object> _data;

    // Using dictionaries adds more memory for each row
    // With the advantage of gaining performance by avoiding boxing - unboxing
    // For now, it has 4000 rows, so it may be helpful
    // and for other cases, like having only 4 columns, 
    // boxing - unboxing may be better
    private readonly Dictionary<string, int> _intsData = [];
    private readonly Dictionary<string, bool> _boolsData = [];
    private readonly Dictionary<string, string> _stringsData = [];
    private readonly Dictionary<string, float> _floatsData = [];

    public void AssignCell(string columnName, bool value)
         => _boolsData[columnName] = value;
    public void AssignCell(string columnName, int value)
         => _intsData[columnName] = value;
    public void AssignCell(string columnName, float value)
         => _floatsData[columnName] = value;
    public void AssignCell(string columnName, string value)
         => _stringsData[columnName] = value;

    public object GetAtColumn(string columnName)
    {
        if(_intsData.ContainsKey(columnName))
            return _intsData[columnName];

        else if(_boolsData.ContainsKey(columnName))
            return _boolsData[columnName];

        else if(_floatsData.ContainsKey(columnName))
            return _floatsData[columnName];

        else if(_stringsData.ContainsKey(columnName))
            return _stringsData[columnName];

        return null;
    }
}
