public class Rectangle : Shape
{
    // Private member variables for width and height
    private double _width;
    private double _height;

    // Constructor that accepts color, width, and height, and calls the base constructor
    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }

    // Override the GetArea method from the base class
    public override double GetArea()
    {
        // Calculate and return the area of the rectangle
        return _width * _height;
    }
}

// Rectangle is a new class that inherits from the Shape base class.
// It has private member variables _width and _height to store the lengths of the sides.
// The constructor of Rectangle accepts the color, width, and height as parameters. It calls the base class constructor using base(color) to set the color.
// The GetArea method is overridden to calculate and return the area of the rectangle based on its width and height.