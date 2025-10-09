var numbers = new List<int>() { 5,3,2,8,17,7 };

SimpleTwoInts minAndMax = GetMinMax(numbers);
Console.WriteLine($"Min is {minAndMax.Int1}");
Console.WriteLine($"Max is {minAndMax.Int2}");

Console.ReadKey();

// Creating a new type to store 2 ints
// Instead of using bool isParsed = int.TryParse("abc", out int result)
// To avoid using out as a parameter, that should be a return item
// Algorithm: set of instructions followed to solve a problem
// 1. Check if the collection is empty. If so, return
// 2. Create variables for min and max elements. Both can be the first item
// of the collection
// 3. Iterate the collection
// 4. Compare each item with the variables we have
// 5. Return the values 
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