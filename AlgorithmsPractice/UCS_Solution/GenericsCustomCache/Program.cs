// Decorator pattern applied
// Here, it can be chosen the way of downloading
// SlowDataDownloader or CachingDataDownloader

//var dataDownloader = new SlowDataDownloader();
// CachingDataDownloader works as a wrapper around SlowDataDownloader
// enriching it with a caching feature
var dataDownloader =
    new CachingDataDownloader(new SlowDataDownloader());

var idsList = new List<string>
{ "id1", "id2", "id3", "id1", "id3", "id1", "id2"};

foreach(var id in idsList)
{
    Console.WriteLine(dataDownloader.DownloadData(id));
}

Console.ReadKey();

// OCP applied
// To apply the decorator pattern in this class
// It need to implement the same interface as the decorated type
// with a new version
// Now, this class is in charge of caching, not about how the data is accessed
public class CachingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly Cache<string, string> _cache = new();

    public CachingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    // As we are using the decorator pattern on SlowDataDownloader
    // This class will implement IDataDownloader,
    //  Assign a SlowDataDownloader instance when using the constructor, 
    //  Add cache functionality
    //  and call SlowDataDownloader.DownloadData
    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, _dataDownloader.DownloadData);
    }
}

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

// This class is fully dedicated to download data and not about caching it
public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class Cache<TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedData = [];

    public TData Get(TKey key, Func<TKey, TData> getDataForTheFirstTime)
    {
        if(!_cachedData.ContainsKey(key))
            _cachedData[key] = getDataForTheFirstTime(key);

        return _cachedData[key];
    }
}