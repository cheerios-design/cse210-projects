using System;

class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string Display()
    {
        return IsHidden ? "___" : Text;
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string reference)
    {
        // Parse reference string into book, chapter, and verse components
        // You may need to enhance this based on your specific use cases
        // For simplicity, assuming the reference is always in the format "Book Chapter:StartVerse-EndVerse"
        string[] parts = reference.Split(' ');
        Book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]);
        string[] verseRange = chapterVerse[1].Split('-');
        StartVerse = int.Parse(verseRange[0]);
        EndVerse = verseRange.Length > 1 ? int.Parse(verseRange[1]) : StartVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

class Scripture
{
    private readonly Reference reference;
    private readonly Word[,] words;

public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        string[] textWords = text.Split(' ');
        words = new Word[this.reference.EndVerse - this.reference.StartVerse + 1, textWords.Length];

        int verseIndex = 0;
        for (int i = 0; i < textWords.Length; i++)
        {
            words[verseIndex, i] = new Word(textWords[i]);

            // Move to the next verse if needed
            if (i == textWords.Length - 1 && verseIndex < words.GetLength(0) - 1)
            {
                i = -1; // Reset i
                verseIndex++;
            }
        }
    }

    public void Display()
{
    try
    {
        Console.Clear();
    }
    catch (System.IO.IOException)
    {
        // Ignore the exception if clearing the console fails
    }

    Console.WriteLine(reference.ToString());

    for (int i = 0; i < words.GetLength(0); i++)
    {
        for (int j = 0; j < words.GetLength(1); j++)
        {
            Console.Write(words[i, j].Display() + " ");
        }
        Console.WriteLine();
    }
}


    public void HideRandomWords()
    {
        Random random = new Random();

        for (int i = 0; i < words.GetLength(0); i++)
        {
            for (int j = 0; j < words.GetLength(1); j++)
            {
                if (random.Next(2) == 0) // 50% chance of hiding the word
                {
                    words[i, j].IsHidden = true;
                }
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        string reference = "John 3:16";
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture(reference, text);

        do
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        } while (!scripture.AreAllWordsHidden());
    }
}
