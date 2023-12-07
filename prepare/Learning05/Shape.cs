public class Shape
{
    // Member variable for color
    private string color;

    // Getter and setter for color
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    // Constructor that accepts color and sets it
    public Shape(string color)
    {
        this.color = color;
    }

    // Virtual method for GetArea
    public virtual double GetArea()
    {
        // Default implementation for the base class
        return 0;
    }
}

//I added a color member variable to the Shape class.
// Getter and setter methods (Color property) are provided for accessing and modifying the color variable.
// A constructor is created to accept the color as a parameter and set it during object initialization.
// The GetArea method is declared as virtual, allowing derived classes to override it. 
//-The default implementation returns 0, 
//and this method can be overridden in derived classes with their specific implementations.