namespace Testing;

public class PositiveNumbersCalculator:NumbersCalculator
{
    protected override bool CanBeAdded(int number) => number > 0;
}