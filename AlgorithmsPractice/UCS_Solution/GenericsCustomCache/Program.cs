var slowDataDownloader = new SlowDataDownloader();
var fastDataDownloader = new FastDataDownloader();
var cacheManager = new CacheManager<string, string>();

var idsList = new List<string>
{ "id1", "id2", "id3", "id1", "id3", "id1", "id2"};

Func<string, bool> IsIdCached = cacheManager.IsCached;

DownloadData(idsList, IsIdCached);

Console.ReadKey();

void DownloadData(List<string> ids, Func<string, bool> predicate)
{
    foreach(var id in ids)
    {
        if(predicate(id))
        {
            Console.WriteLine(fastDataDownloader.DownloadData(id));
        }
        else
        {
            Console.WriteLine(slowDataDownloader.DownloadData(id));
            var data = slowDataDownloader.DownloadData(id);
            cacheManager.CacheData(id, data);
        }
    }
}

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(1000);
        return resourceId + " package data";
    }
}

public class FastDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(200);
        return resourceId + " package data ... Fast download";
    }
}

public class CacheManager<T1, T2>
{
    private readonly Dictionary<T1, T2> cache = new Dictionary<T1, T2>();

    public bool IsCached(T1 key) => cache.ContainsKey(key);

    public void CacheData(T1 id, T2 data) => cache.Add(id, data);
}