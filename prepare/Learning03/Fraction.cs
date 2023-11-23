// Fraction.cs

using System;

public class Fraction
{
    private int _top = 1;
    private int _bottom = 1;

    // Constructors
    public Fraction() { }

    public Fraction(int top) => _top = top;

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom != 0 ? bottom : 1;
    }

    // Properties
    public int Top
    {
        get => _top;
        set => _top = value;
    }

    public int Bottom
    {
        get => _bottom;
        set => _bottom = value != 0 ? value : 1;
    }

    // Methods
    public string GetFractionString() => $"{_top}/{_bottom}";

    public double GetDecimalValue() => (double)_top / _bottom;
}
