using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userInput;
        do
        {
            Console.Write("Enter number: ");
            userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }

        } while (userInput != 0);

        // Compute the sum
        int sum = numbers.Sum();

        // Compute the average
        double average = numbers.Average();

        // Find the maximum
        int maxNumber = numbers.Max();

        // Find the smallest positive number
        int smallestPositive = numbers.Where(x => x > 0).DefaultIfEmpty(0).Min();

        // Sort the list
        List<int> sortedList = numbers.OrderBy(x => x).ToList();

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        
        Console.WriteLine("The sorted list is:");
        foreach (var num in sortedList)
        {
            Console.WriteLine(num);
        }
    }
}
