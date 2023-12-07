public class Circle : Shape
{
    // Private member variable for radius
    private double _radius;

    // Constructor that accepts color and radius, and calls the base constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method from the base class
    public override double GetArea()
    {
        // Calculate and return the area of the circle
        return Math.PI * _radius * _radius;
    }
}

// Circle is a new class that inherits from the Shape base class.
// It has a private member variable _radius to store the radius of the circle.
// The constructor of Circle accepts the color and radius as parameters. It calls the base class constructor using base(color) to set the color.
// The GetArea method is overridden to calculate and return the area of the circle based on its radius.