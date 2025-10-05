try
{
    ComplexMethod();
}
catch (InvalidOperationException ex)
when (ex.Message == "Cannot connect to a service")
{
    Console.WriteLine("Check your internet connection");
    throw;
}

try
{
    ComplexMethodWithCustomExceptions();
}
catch (ConnectionException ex)
{
    Console.WriteLine("Check your internet connection");
    throw;
}
catch (JsonParsingException ex)
{
    Console.WriteLine("Unable to parse JSON. JSON body is: " + ex.JsonBody);
    throw;
}

Console.ReadKey();

void ComplexMethod()
{
    // 1. connecting
    // Devs may change a bit the message for "Failed to connect to the service"
    // Better to define another exception types
    throw new InvalidOperationException("Cannot connect to a service");

    // 2. authorizing
    throw new InvalidOperationException("Cannot authorize the user");

    // 3. retrieving data as Json
    throw new InvalidOperationException("Cannot retrieve data");

    // 4. parsing the Json data to a C# type
    throw new InvalidOperationException("Cannot parse Json data");
}

void ComplexMethodWithCustomExceptions()
{
    // 1. connecting
    throw new ConnectionException("Cannot connect to a service");

    // 2. authorizing
    throw new AuthorizationException("Cannot authorize the user");

    // 3. retrieving data as Json
    throw new DataAccessException("Cannot retrieve data");

    // 4. parsing the Json data to a C# type
    // Providing additional info such as the json string
    throw new JsonParsingException("Cannot parse Json data");
}

public class ConnectionException : Exception
{
    public ConnectionException() { }

    public ConnectionException(string message) : base(message) { }

    public ConnectionException(string message,Exception innerException)
        : base(message,innerException)
    {

    }
}

public class AuthorizationException : Exception
{
    public AuthorizationException()
    {

    }

    public AuthorizationException(string message)
        : base(message)
    {

    }

    public AuthorizationException(string message,Exception innerException)
        : base(message,innerException)
    {

    }
}

public class DataAccessException : Exception
{
    public DataAccessException()
    {

    }

    public DataAccessException(string message)
        : base(message)
    {

    }

    public DataAccessException(string message,Exception innerException)
        : base(message,innerException)
    {

    }
}

public class JsonParsingException : Exception
{
    public string JsonBody { get; }

    public JsonParsingException()
    {

    }

    public JsonParsingException(string message)
        : base(message)
    {

    }

    public JsonParsingException(
        string message,Exception innerException)
        : base(message,innerException)
    {

    }

    public JsonParsingException(
        string message,string jsonBody)
        : base(message)
    {
        JsonBody = jsonBody;
    }

    public JsonParsingException(
        string message,string jsonBody,Exception innerException)
        : base(message,innerException)
    {
        JsonBody = jsonBody;
    }
}