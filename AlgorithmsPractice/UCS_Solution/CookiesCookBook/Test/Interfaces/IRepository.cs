namespace CookiesCookBook.Test.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Read();
        void Save(List<T> items);
    }
}
