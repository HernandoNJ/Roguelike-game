using System.Diagnostics;

// Getting how much it takes to execute the method
Stopwatch stopwatch = Stopwatch.StartNew();

//var ints = CreateCollectionOfRandomLengthWithConstraints<DateTime>(0);
//stopwatch.Stop();
//Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");
// It took ~1.94 sec.

var ints2 = CreateCollectionWithFixedSize<DateTime>(0);
stopwatch.Stop();
Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");
// It took ~1,49 sec.

Console.ReadKey();

IEnumerable<T> CreateCollectionWithFixedSize<T>(
    int maxLength) where T : new()
{
    var length = 100000000;
    var resultList = new List<T>(length);

    for (int i = 0; i < length; i++)
    {
        resultList.Add(new T());
    }

    return resultList;
}