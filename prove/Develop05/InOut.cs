using System.Xml.Linq;
using System.IO; 

public class InOut
{
    public void SaveGoal()
    {
        string filename = "myFile.txt";
        Console.Write("What is the name of your file? ");
        filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
        // You can add text to the file with the WriteLine method
        outputFile.WriteLine("This will be the first line in the file.");
        
        // You can use the $ and include variables just like with Console.WriteLine
        string color = "Blue";
        outputFile.WriteLine($"My favorite color is {color}");
        }
        return;
    }
    public void LoadGoals()
    {
        string filename = "myFile.txt";
        Console.Write("What is the name of your file? ");
        filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
    }
    public void ReadGoal()
    {
        string filename = "myFile.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string firstName = parts[0];
            string lastName = parts[1];
        }
    }
}