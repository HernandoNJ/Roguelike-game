// This constructor is not parameterless
// var points = CreateCollectionOfRandomLengthWithConstraints<Point>(10); 

// Parameterless constructor
var ints = CreateCollectionOfRandomLengthWithConstraints<int>(10);

Console.ReadKey();

// Allow only T types with parameterless constructor
IEnumerable<T> CreateCollectionOfRandomLengthWithConstraints<T>(
    int maxLength) where T : new()
{
    var randomLength = new Random().Next(maxLength + 1);

    var resultList = new List<T>();
    for (int i = 0; i < randomLength; i++) resultList.Add(new T());

    return resultList;
}

public class Point
{
    public int x, y;

    public Point(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}