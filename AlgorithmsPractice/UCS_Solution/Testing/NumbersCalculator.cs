namespace Testing;

public class NumbersCalculator
{
    public int CalculateSum(List<int> numbers)
    {
        var sum = 0;
        foreach (var number in numbers)
        {
            if(CanBeAdded(number)) sum += number;
        }

        return sum;
    }

    protected virtual bool CanBeAdded(int number) => true;
}