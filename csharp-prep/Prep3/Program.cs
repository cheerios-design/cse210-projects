using System;

class Program
{
    static void Main()
    {
        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to the Guess My Number game!");

        int userGuess;  // Declare userGuess outside the loop

        do
        {
            Console.Write("What is your guess? ");
            userGuess = Convert.ToInt32(Console.ReadLine());

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (userGuess != magicNumber);
    }
}
