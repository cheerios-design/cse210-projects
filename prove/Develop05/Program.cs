using System;

// A parent class called Person
public class Person
{
    private string _name;

    public Person(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
}

// A child class called Student
public class Student : Person
{
    private string _number;

    // Calling the parent constructor using "base"!
    public Student(string name, string number) : base(name)
    {
        _number = number;
    }

    public string GetNumber()
    {
        return _number;
    }
}

class Program
{
    static void Main()
    {
        // Creating an instance of the Student class
        Student student = new Student("Brigham", "234");

        // Accessing the GetName and GetNumber methods
        string name = student.GetName();
        string number = student.GetNumber();

        // Printing the results
        Console.WriteLine(name);
        Console.WriteLine(number);
    }
}
