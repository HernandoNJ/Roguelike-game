var numbers = new List<int>() { 5,3,2,8,17,7 };

//SimpleTwoInts minAndMax = GetMinMax(numbers);
SimpleTuple<int,int> minAndMax = GetMinMaxWithTuples(numbers);
Console.WriteLine($"Min is {minAndMax.Item1}");
Console.WriteLine($"Max is {minAndMax.Item2}");

Console.ReadKey();

SimpleTuple<int,int> GetMinMaxWithTuples(IEnumerable<int> inputList)
{
    if (!inputList.Any())
        throw new InvalidOperationException(
            $"The input collection cannot be empty.");

    int min = inputList.First();
    int max = inputList.First();

    foreach (int number in numbers)
    {
        if (number > max) max = number;
        if (number < min) min = number;
    }
    return new SimpleTuple<int,int>(min,max);
}

/*Creating a new type to store 2 ints
 Instead of using bool isParsed = int.TryParse("abc",out int result)
 To avoid using out as a parameter, that should be a return item
 Algorithm: set of instructions followed to solve a problem
 1. Check if the collection is empty. If so, return
 2. Create variables for min and max elements. Both can be the first item
 of the collection
 3. Iterate the collection
 4. Compare each item with the variables we have
 5. Return the values */
SimpleTwoInts GetMinMax(IEnumerable<int> inputList)
{
    if (!inputList.Any())
        throw new InvalidOperationException(
            $"The input collection cannot be empty.");

    int min = inputList.First();
    int max = inputList.First();

    foreach (int number in numbers)
    {
        if (number > max) max = number;
        if (number < min) min = number;
    }
    return new SimpleTwoInts(min,max);
}

public class SimpleTuple<T1, T2>
{
    public T1 Item1 { get; }
    public T2 Item2 { get; }

    public SimpleTuple(T1 item1,T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}

public class SimpleTwoInts
{
    public int Int1 { get; }
    public int Int2 { get; }

    public SimpleTwoInts(int int1,int int2)
    {
        Int1 = int1;
        Int2 = int2;
    }
}