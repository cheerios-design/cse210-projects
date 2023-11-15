using System;

class Program
{
    static void Main()
    {
        do
        {
            PlayGuessMyNumberGame();
            
            Console.Write("Do you want to play again? (yes/no): ");
        } while (Console.ReadLine().ToLower() == "yes");
    }

    static void PlayGuessMyNumberGame()
    {
        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to the Guess My Number game!");

        int userGuess;
        int numberOfGuesses = 0;

        do
        {
            Console.Write("What is your guess? ");
            userGuess = Convert.ToInt32(Console.ReadLine());
            numberOfGuesses++;

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
                Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");
            }

        } while (userGuess != magicNumber);
    }
}
