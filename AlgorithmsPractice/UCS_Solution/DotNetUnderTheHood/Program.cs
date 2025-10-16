// CSV file location
const string path =
    @"C:\Users\herna\Documents\Dev\zFiles\031 sampleData.csv";

// Store the result of Read() (CSV data) in data.
var data = new CsvReader().Read(path);

Console.ReadKey();

// Class responsible for reading a CSV file.
public class CsvReader
{
    // Public method to read the CSV file at the given path.
    public CsvData Read(string path)
    {
        // Creating a StreamReader class instance to read the file content line by line.
        // The 'using var' statement ensures the StreamReader is properly disposed of (closed)
        // once it goes out of scope, even if an error occurs.
        using var streamReader = new StreamReader(path);

        // Read the very first line of the CSV file. This line is assumed to contain the column headers (names).
        // The Split(separator: ",") method divides the line into an array of strings, using , as the delimiter.
        var columnHeaders =
            streamReader.ReadLine().Split(separator: ",");

        // Initialize a list to hold the data rows (all lines after the header).
        var records = new List<string[]>();

        // Loop through the rest of the file line by line until the end is reached.
        while(!streamReader.EndOfStream)
        {
            // Read the next line of data and Split it using ,
            var currentRow =
                streamReader.ReadLine().Split(separator: ",");

            // Add the array of cells (one row of data) to the list of rows.
            records.Add(currentRow);
        }

        return new CsvData(columnHeaders, records);
    }
}

// Class representing the structured data read from the CSV file.
// It acts as a container for the column headers and the data rows (records).
public class CsvData
{
    public CsvData(string[] columns, IEnumerable<string[]> rows)
    {
        Columns = columns; // Assign the column headers.
        Rows = rows;       // Assign the data rows.
    }

    public string[] Columns { get; }

    public IEnumerable<string[]> Rows { get; }
}