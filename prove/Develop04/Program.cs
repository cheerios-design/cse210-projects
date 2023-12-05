using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// Base class for all activities
class BaseActivity
{
    protected int duration; // Duration of the activity in seconds

    // Constructor to initialize the duration
    public BaseActivity(int duration)
    {
        this.duration = duration;
    }

    // Method to start the activity
    public void StartActivity()
    {
        DisplayStartingMessage(); // Display common starting message
        Thread.Sleep(3000); // Pause for several seconds
        PerformActivity(); // Perform activity-specific actions
        DisplayEndingMessage(); // Display common ending message
    }

    // Method to display the common starting message (can be overridden by subclasses)
    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine("Common starting message for all activities");
    }

    // Method to display the common ending message (can be overridden by subclasses)
    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the activity. Time: {duration} seconds.");
    }

    // Method to perform activity-specific actions (to be overridden by subclasses)
    protected virtual void PerformActivity()
    {
        // Implementation specific to each activity
    }
}

// Breathing Activity class
class BreathingActivity : BaseActivity
{
    // Constructor to initialize the duration via the base class constructor
    public BreathingActivity(int duration) : base(duration) { }

    // Override method to display the specific starting message for breathing activity
    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage(); // Call the base class method
        Console.WriteLine("Breathing activity starting message");
    }

    // Override method to perform breathing activity-specific actions
    protected override void PerformActivity()
    {
        // Implementation specific to breathing activity
        Console.WriteLine("Follow the prompts:");
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// Reflection Activity class
class ReflectionActivity : BaseActivity
{
    private List<string> usedPrompts; // Keep track of used prompts

    public ReflectionActivity(int duration) : base(duration)
    {
        usedPrompts = new List<string>();
    }

    // Override method to display the specific starting message for reflection activity
    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage(); // Call the base class method
        Console.WriteLine("Reflection activity starting message");
    }

    // Override method to perform reflection activity-specific actions
    protected override void PerformActivity()
    {
        // Implementation specific to reflection activity
        Console.WriteLine("Think about the following prompt:");
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // Shuffle the prompts to ensure randomness
        prompts = prompts.OrderBy(x => Guid.NewGuid()).ToArray();

        foreach (string prompt in prompts)
        {
            if (!usedPrompts.Contains(prompt))
            {
                usedPrompts.Add(prompt);

                Console.WriteLine(prompt);

                // Ask reflection questions with countdowns
                for (int i = 0; i < duration; i++)
                {
                    Console.WriteLine("Reflecting...");
                    Thread.Sleep(1000); // Pause for 1 second
                }
            }
        }
    }
}

// Listing Activity class
class ListingActivity : BaseActivity
{
    private List<string> usedPrompts; // Keep track of used prompts

    public ListingActivity(int duration) : base(duration)
    {
        usedPrompts = new List<string>();
    }

    // Override method to display the specific starting message for listing activity
    protected override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage(); // Call the base class method
        Console.WriteLine("Listing activity starting message");
    }

    // Override method to perform listing activity-specific actions
    protected override void PerformActivity()
    {
        // Implementation specific to listing activity
        Console.WriteLine("Think about the following prompt:");
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Shuffle the prompts to ensure randomness
        prompts = prompts.OrderBy(x => Guid.NewGuid()).ToArray();

        foreach (string prompt in prompts)
        {
            if (!usedPrompts.Contains(prompt))
            {
                usedPrompts.Add(prompt);

                Console.WriteLine(prompt);

                Console.WriteLine("Listing items:");
                for (int i = 0; i < duration; i++)
                {
                    Console.WriteLine($"Item {i + 1}");
                    Thread.Sleep(1000); // Pause for 1 second
                }

                Console.WriteLine($"Number of items listed: {duration}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Get user input for activity type and duration
        Console.Write("Choose an activity (1: Breathing, 2: Reflection, 3: Listing): ");
        int activityType = int.Parse(Console.ReadLine());

        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        // Create an instance of the corresponding activity class
        BaseActivity activity;
        switch (activityType)
        {
            case 1:
                activity = new BreathingActivity(duration);
                break;
            case 2:
                activity = new ReflectionActivity(duration);
                break;
            case 3:
                activity = new ListingActivity(duration);
                break;
            default:
                Console.WriteLine("Invalid activity type. Exiting...");
                return;
        }

        // Call StartActivity() on the instance
        activity.StartActivity();
    }
}
