var slowDataDownloader = new SlowDataDownloader();

var idsList = new List<string>
{ "id1", "id2", "id3", "id1", "id3", "id1", "id2"};

DownloadData(idsList);

Console.ReadKey();

void DownloadData(List<string> ids)
{
    foreach(var id in ids)
        Console.WriteLine(slowDataDownloader.DownloadData(id));
}

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    private readonly Cache<string, string> _cache = new();

    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, DownloadDataWithoutCaching);
    }

    private string DownloadDataWithoutCaching(string resourceId)
    {
        Thread.Sleep(1000);
        return resourceId + " package data";
    }
}

public class Cache<TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedData = [];

    public TData Get(TKey key, Func<TKey, TData> getDataForTheFirstTime)
    {
        if(!_cachedData.ContainsKey(key))
        {
            _cachedData[key] = getDataForTheFirstTime(key);
        }

        return _cachedData[key];
    }
}