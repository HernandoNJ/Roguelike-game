const string filePath = "file.txt";

/* Syntactic sugar for this
var writer = new FileWriter(filePath);
try
{
    writer.Write("some text");
    writer.Write("some other text");
}
finally
{
    writer.Dispose();.
} 
*/
using(var writer = new FileWriter(filePath))
{
    writer.Write("some text");
    writer.Write("some other text");
}

// With using, Dispose() will be called at the end of the scope of this variable
using var reader = new SpecificLineFromTextFileReader(filePath);
var third = reader.ReadLineNumber(3);
var fourth = reader.ReadLineNumber(4);

Console.WriteLine("Third line is: " + third);
Console.WriteLine("Fourth line is: " + fourth);

Console.WriteLine("Press any key to exit");
Console.ReadKey();

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _streamReader;
    public SpecificLineFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public string ReadLineNumber(int LineNumber)
    {
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

        for(int i = 1;i < LineNumber;i++) _streamReader.ReadLine();

        return _streamReader.ReadLine();
    }

    // Use to free unmanaged resources
    // Implementing Dispose() should be done using the Dispose pattern
    public void Dispose()
    {
        _streamReader?.Dispose();
    }
}

public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        // Call Flush so the text data in the buffer is written to the file on disk immediately
        _streamWriter.Flush();
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
    }
}