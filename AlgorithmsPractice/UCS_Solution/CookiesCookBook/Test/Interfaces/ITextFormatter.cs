namespace CookiesCookBook.Test.Interfaces
{
    public interface ITextFormatter<T>
    {
        string Serialize(T item);
        T Deserialize(string line);
    }
}