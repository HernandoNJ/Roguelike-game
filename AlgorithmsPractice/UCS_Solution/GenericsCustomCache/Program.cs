var dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();


// after the data identified by ID “id1” is fetched for the first time, the next time, it could be served from the cache. 

// A generic Cache class is defined and used. It should be able to work for any type of key and data, not only strings like here.
// The first time we fetch the data identified by a certain key, it still works slowly. But the next time this data is fetched it should be served from the cache, so it should happen almost immediately. 

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public CacheManager<string, string> cacheManager = new CacheManager<string, string>();

    public string DownloadData(string resourceId)
    {
        // let's imagine this method downloads real data very slowly
        Thread.Sleep(1000);

        var resourceData = "Data package loaded for " + resourceId;

        if(!cacheManager.HasKey(resourceId))
            cacheManager.AddItem(resourceId, resourceData);
        else
            Console.WriteLine($"Item already cached. id: {resourceId}, data: {cacheManager.GetItem(resourceId)}");

        return resourceId + " data downloaded";
    }
}

public class FastDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        // Check if the resourceId is in the cache dictionary

        // let's imagine this method downloads real data very slowly
        //Thread.Sleep(1000);
        //var resourceData = "Some data for " + resourceId;
        //var cache = new StringCache(resourceId, resourceData);

        return "Some data for " + resourceId;
    }
}

public class CacheManager<T1, T2>
{
    private readonly Dictionary<T1, T2> _cacheDictionary = new Dictionary<T1, T2>();

    public bool HasKey(T1 key)
        => _cacheDictionary.ContainsKey(key);

    public void AddItem(T1 id, T2 data)
    {
        if(!_cacheDictionary.ContainsKey(id))
            _cacheDictionary.Add(id, data);
    }

    public T2 GetItem(T1 id)
        => _cacheDictionary[id];
}