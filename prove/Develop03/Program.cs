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
    private int totalWords;
    private int wordsHidden;

    public int Progress => wordsHidden * 100 / totalWords;

    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        string[] textWords = text.Split(' ');
        totalWords = textWords.Length;
        words = new Word[this.reference.EndVerse - this.reference.StartVerse + 1, totalWords];

        int verseIndex = 0;
        for (int i = 0; i < totalWords; i++)
        {
            words[verseIndex, i] = new Word(textWords[i]);

            if (i == totalWords - 1 && verseIndex < words.GetLength(0) - 1)
            {
                i = -1; 
                verseIndex++;
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference.ToString());

        for (int i = 0; i < words.GetLength(0); i++)
        {
            for (int j = 0; j < words.GetLength(1); j++)
            {
                Console.Write(words[i, j].Display() + " ");
            }
            Console.WriteLine();
        }

        DisplayProgress();
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        for (int i = 0; i < words.GetLength(0); i++)
        {
            for (int j = 0; j < words.GetLength(1); j++)
            {
                if (random.Next(2) == 0 && !words[i, j].IsHidden)
                {
                    words[i, j].IsHidden = true;
                    wordsHidden++;
                }
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        return wordsHidden == totalWords;
    }

    private void DisplayProgress()
    {
        Console.WriteLine($"Progress: {Progress}% complete\n");
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
