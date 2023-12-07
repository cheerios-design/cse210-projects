public class Square : Shape
{
    // Private member variable for side
    private double _side;

    // Constructor that accepts color and side, and calls the base constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method from the base class
    public override double GetArea()
    {
        // Calculate and return the area of the square
        return _side * _side;
    }
}

// Square is a new class that inherits from the Shape base class.
// It has a private member variable _side to store the length of the side.
// The constructor of Square accepts the color and side as parameters, 
//and it calls the base class constructor using base(color) to set the color.
// The GetArea method is overridden to calculate and return the area of the square based on its side length.