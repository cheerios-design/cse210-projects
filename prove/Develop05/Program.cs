using System;
using System.Collections.Generic;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static string menu = "";

    static void Menu()
{
    while (menu != "6")
    {
        Console.WriteLine($"You have {GetPointAmount()} points.");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");
        menu = Console.ReadLine();

        switch (menu)
        {
            case "1":
                CreateNewGoal();
                break;
            case "2":
                ListGoals();
                break;
            case "3":
                SaveGoals();
                break;
            case "4":
                LoadGoals();
                break;
            case "5":
                RecordEvent();
                break;
            case "6":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break; //This modification includes the default case, which will handle any input that does 
                //not match the provided cases. It displays an error message and prompts the user to try again.
        }
    }
}

    static int GetPointAmount()
    {
        int totalPoints = 0;
        foreach (var goal in goals)
        {
            totalPoints += goal.GetPointAmount();
        }
        return totalPoints;
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter your simple goal name: ");
                string name = Console.ReadLine();
                SimpleGoal simpleGoal = new SimpleGoal(name, "Description", 1000, true); // Adjust parameters as needed
                goals.Add(simpleGoal);
                break;
            case "2":
                Console.Write("Enter your eternal goal name: ");
                string eternalName = Console.ReadLine();
                EternalGoal eternalGoal = new EternalGoal(eternalName, "Description", 100); // Adjust parameters as needed
                goals.Add(eternalGoal);
                break;
            case "3":
                Console.Write("Enter your checklist goal name: ");
                string checklistName = Console.ReadLine();
                ChecklistGoal checklistGoal = new ChecklistGoal(checklistName, "Description", 50, 10, 500); // Adjust parameters as needed
                goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void ListGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"Name: {goal.GetName()}, Description: {goal.GetDescription()}, Points: {goal.GetPointAmount()}, Completable: {goal.IsCompletable()}");
        }
    }

    static void SaveGoals()
    {
        // Implement saving goals to a file or any other storage mechanism
        // Example code using InOut class:
        InOut inOut = new InOut();
        inOut.SaveGoal();
    }

    static void LoadGoals()
    {
        // Implement loading goals from a file or any other storage mechanism
        // Example code using InOut class:
        InOut inOut = new InOut();
        inOut.LoadGoals();
    }

    static void RecordEvent()
    {
        // Implement recording events for goals
        // Example code using Recorder class:
        Recorder recorder = new Recorder(0, "Recorder Title");
        // Add code to interact with the recorder or goals to record events
    }
}
