namespace Testing.DiamondProblem;

public class Animal
{
    public virtual void MakeNoise() => Console.WriteLine("Animal noise");
}

public class HousePet:Animal
{
    public override void MakeNoise() => Console.WriteLine("Mmmmm!");
}

public class Feline:Animal
{
    public override void MakeNoise() => Console.WriteLine("Mrrr!");
}

// It inherits MakeNoise() from both
// If MakeNoise() is called here, which one will be called? 
// The one from Feline or Housepet?
// public class DomesticCat: Feline, Housepet
public class DomesticCat : Feline //, Housepet
{
    public override void MakeNoise() => Console.WriteLine("Meow!");
}