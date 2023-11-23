// Program.cs

using System;

class Program
{
    static void Main()
    {
        // Create an instance for 1/1 (using the first constructor)
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()}, Decimal Value: {fraction1.GetDecimalValue()}");

        // Create an instance for 5/1 (using the second constructor)
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()}, Decimal Value: {fraction2.GetDecimalValue()}");

        // Create an instance for 3/4 (using the third constructor)
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()}, Decimal Value: {fraction3.GetDecimalValue()}");

        // Create an instance for 1/3 (using the third constructor)
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"Fraction 4: {fraction4.GetFractionString()}, Decimal Value: {fraction4.GetDecimalValue()}");
    }
}
