using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

/// <summary>
/// Represents an individual journal entry.
/// </summary>
class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    /// <summary>
    /// Displays the entry details to the console.
    /// </summary>
    public void DisplayEntry()
    {
        Console.WriteLine($"\nDate: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
    }
}

/// <summary>
/// Manages the collection of journal entries.
/// </summary>
class PromptJournal
{
    public List<Entry> Entries { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PromptJournal"/> class.
    /// </summary>
    public PromptJournal()
    {
        Entries = new List<Entry>();
    }

    /// <summary>
    /// Adds a new entry to the journal.
    /// </summary>
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    /// <summary>
    /// Displays all entries in the journal to the console.
    /// </summary>
    public void DisplayJournal()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("\nJournal is empty.");
        }
        else
        {
            foreach (var entry in Entries)
            {
                entry.DisplayEntry();
            }
        }
    }

    /// <summary>
    /// Saves the journal to a specified file in JSON format.
    /// </summary>
    public void SaveToFile(string filename)
    {
        var jsonEntries = JsonConvert.SerializeObject(Entries, Formatting.Indented);
        File.WriteAllText(filename, jsonEntries);
    }

    /// <summary>
    /// Loads entries from a JSON file and replaces the current journal entries.
    /// </summary>
    public void LoadFromFile(string filename)
    {
        try
        {
            var jsonEntries = File.ReadAllText(filename);
            Entries = JsonConvert.DeserializeObject<List<Entry>>(jsonEntries);
            Console.WriteLine($"\nJournal loaded from {filename}.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nFile not found. Could not load the journal.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nError loading the journal: {e.Message}");
        }
    }
}

/// <summary>
/// Main application class for MemoMind.
/// </summary>
class MemoMindApp
{
    private PromptJournal journal;
    private string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="MemoMindApp"/> class.
    /// </summary>
    public MemoMindApp()
    {
        journal = new PromptJournal();
    }

    /// <summary>
    /// Runs the MemoMind application.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[new Random().Next(prompts.Length)];
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Entry entry = new Entry { Prompt = prompt, Response = response, Date = date };
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("\nEnter the filename to save the journal: ");
                    string filenameSave = Console.ReadLine();
                    journal.SaveToFile(filenameSave);
                    break;

                case "4":
                    Console.Write("\nEnter the filename to load the journal: ");
                    string filenameLoad = Console.ReadLine();
                    journal.LoadFromFile(filenameLoad);
                    break;

                case "5":
                    Console.WriteLine("\nExiting MemoMind. Goodbye!");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}

/// <summary>
/// Main program class.
/// </summary>
class Program
{
    static void Main()
    {
        MemoMindApp app = new MemoMindApp();
        app.Run();
    }
}
