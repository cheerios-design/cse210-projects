using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        char letter;
        char sign = ' ';

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Determine the sign
        int lastDigit = (int)gradePercentage % 10;
        if (lastDigit >= 7)
        {
            sign = '+';
        }
        else if (lastDigit < 3 && gradePercentage >= 60)
        {
            sign = '-';
        }

        // Handle exceptional cases (A+, F+, F-)
        if (letter == 'A' && sign == '+')
        {
            sign = ' ';
        }
        else if (letter == 'F' && (sign == '+' || sign == '-'))
        {
            sign = ' ';
        }

        // Display the grade and sign
        Console.WriteLine($"Your final grade is: {letter}{sign}");

        // Check if passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time. Keep working hard!");
        }
    }
}
