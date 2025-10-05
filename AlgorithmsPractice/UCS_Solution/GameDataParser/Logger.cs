public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void Log(Exception ex)
    {
        // Date and time the ex happens
        // Ex message
        // Stack trace
        // Don't delete old entries, but append the new ones
        // At the end of the file
        var entry =
        // $@ -> multi line string
    $@"DATE: {DateTime.Now}
    EXCEPTION MESSAGE: {ex.Message}
    STACK TRACE: {ex.StackTrace}
            
        "; // Empty line above for better visuals

        // Using AppendAllText method from File class
        File.AppendAllText(_logFileName,entry);
    }
}