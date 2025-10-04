Console.WriteLine("Hello");
Console.ReadKey();

public class PersonDataReader
{
    private readonly IPeopleRepository _peopleRepository;
    private readonly ILogger _logger;

    public PersonDataReader(
        IPeopleRepository peopleRepository,
        ILogger logger)
    {
        _peopleRepository = peopleRepository;
        _logger = logger;
    }

    public Person ReadPersonData(int personId)
    {
        try
        {
            // What kind of exception throw? hard to know
            // IPeopleRepository is implemented
            // but the exact type is not known
            // any exception may happen
            // here a generic exception is ok
            // because the exception is logged and then rethrown
            return _peopleRepository.Read(personId);
        }
        catch (Exception ex)
        {
            _logger.Log(ex);
            throw new Exception();
        }
    }


}

public interface ILogger
{
    void Log(Exception ex);
}

public interface IPeopleRepository
{
    Person Read(int id);
}

public class Logger : ILogger
{
    public void Log(Exception ex)
    {

    }
}

public class Person
{
    public int Id { get; }
}