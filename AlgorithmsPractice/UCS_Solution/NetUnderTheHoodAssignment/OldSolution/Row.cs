namespace CsvDataAccess.OldSolution;

public class Row
{
    private Dictionary<string, object> _data;
    private readonly Dictionary<string, string> StringData = [];
    private readonly Dictionary<string, int> IntData = [];
    private readonly Dictionary<string, float> FloatData = [];
    private readonly Dictionary<string, bool> BoolData = [];

    public Row(Dictionary<string, object> data,
               Dictionary<string, string> stringData,
               Dictionary<string, int> intData,
               Dictionary<string, float> floatData,
               Dictionary<string, bool> boolData)
    {
        StringData = stringData;
        IntData = intData;
        FloatData = floatData;
        BoolData = boolData;
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        if(_data.ContainsKey(columnName))
        {
            return _data[columnName];
        }
        return null;
    }
}