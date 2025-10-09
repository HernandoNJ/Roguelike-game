
Console.ReadKey();

// Method with 1 parameter
void SomeMethod<TPet>(TPet pet) where TPet : Pet, IComparable<TPet>
{

}

// Method with 2 parameters
void SomeMethod2<TPet, TOwner>(TPet pet,TOwner owner)
    where TPet : Pet, IComparable<TPet>
    where TOwner : new()
{

}

public class Pet { }
public class PetOwner { }