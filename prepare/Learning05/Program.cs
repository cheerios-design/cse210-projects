using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test for Square
        Square mySquare = new Square("Red", 5);

        // Call GetColor() and GetArea() methods for Square
        string squareColor = mySquare.Color;
        double squareArea = mySquare.GetArea();

        // Print results for Square
        Console.WriteLine("Square:");
        Console.WriteLine($"Color: {squareColor}");
        Console.WriteLine($"Area: {squareArea}");
        Console.WriteLine();

        // Test for Rectangle
        Rectangle myRectangle = new Rectangle("Blue", 4, 6);

        // Call GetColor() and GetArea() methods for Rectangle
        string rectangleColor = myRectangle.Color;
        double rectangleArea = myRectangle.GetArea();

        // Print results for Rectangle
        Console.WriteLine("Rectangle:");
        Console.WriteLine($"Color: {rectangleColor}");
        Console.WriteLine($"Area: {rectangleArea}");
        Console.WriteLine();

        // Test for Circle
        Circle myCircle = new Circle("Green", 3);

        // Call GetColor() and GetArea() methods for Circle
        string circleColor = myCircle.Color;
        double circleArea = myCircle.GetArea();

        // Print results for Circle
        Console.WriteLine("Circle:");
        Console.WriteLine($"Color: {circleColor}");
        Console.WriteLine($"Area: {circleArea}");
        Console.WriteLine();

        // Create a list to hold shapes
        List<Shape> shapesList = new List<Shape>();

        // Add Square, Rectangle, and Circle to the list
        shapesList.Add(mySquare);
        shapesList.Add(myRectangle);
        shapesList.Add(myCircle);

        // Iterate through the list of shapes
        foreach (Shape shape in shapesList)
        {
            // Call and display GetColor() and GetArea() methods for each shape
            Console.WriteLine($"{shape.GetType().Name}:");
            Console.WriteLine($"Color: {shape.Color}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine();
        }

        // Wait for user input before closing the console
        Console.ReadLine();
    }
}



// In this example, we create a Square instance with color "Red" and a side length of 5. 
// We then call the GetColor() property from the base class (Shape) to get the color and 
// the overridden GetArea() method in the Square class to get the area. The results are printed to the console.

//Instances of Square, Rectangle, and Circle are created.
// The GetColor() and GetArea() methods are called for each shape.
// The results are printed to the console for verification.

//A List<Shape> called shapesList is created to hold instances of shapes.
// Instances of Square, Rectangle, and Circle are added to the list.
// The foreach loop is used to iterate through the list, and for each shape, 
//the GetColor() and GetArea() methods are called and displayed.