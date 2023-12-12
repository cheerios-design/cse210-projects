using System;
using System.Collections.Generic;

class Activity
{
    private int durationMinutes;
    private double distance;

    public Activity(int durationMinutes, double distance)
    {
        this.durationMinutes = durationMinutes;
        this.distance = distance;
    }

    public virtual double GetDistance()
    {
        return distance;
    }

    public virtual double GetSpeed()
    {
        return (GetDistance() / durationMinutes) * 60;
    }

    public virtual double GetPace()
    {
        return durationMinutes / GetDistance();
    }

    public int GetDuration()
    {
        return durationMinutes;
    }

    public virtual string GetSummary()
    {
        return $"Type: Generic Activity, Duration: {GetDuration()} minutes, Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min/km";
    }
}

class Running : Activity
{
    private double shoeMileage;

    public Running(int durationMinutes, double distance, double shoeMileage) : base(durationMinutes, distance)
    {
        this.shoeMileage = shoeMileage;
    }

    public override double GetDistance()
    {
        return base.GetDistance() * 0.62; // Convert km to miles
    }

    public override double GetPace()
    {
        return base.GetPace() * 60; // Convert min/km to min/mile
    }

    public override string GetSummary()
    {
        return $"Type: Running, Duration: {base.GetDuration()} minutes, Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile, Shoe Mileage: {shoeMileage} miles";
    }
}

class Cycling : Activity
{
    private string terrain;

    public Cycling(int durationMinutes, double distance, string terrain) : base(durationMinutes, distance)
    {
        this.terrain = terrain;
    }

    public override string GetSummary()
    {
        return $"Type: Cycling, Duration: {base.GetDuration()} minutes, Distance: {base.GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min/km, Terrain: {terrain}";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(int durationMinutes, int laps) : base(durationMinutes, laps * 50 / 1000)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000; // Convert laps to km
    }

    public override string GetSummary()
    {
        return $"Type: Swimming, Duration: {base.GetDuration()} minutes, Laps: {laps}, Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min/km";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(30, 5, 150));
        activities.Add(new Cycling(45, 20, "Mountain"));
        activities.Add(new Swimming(40, 30));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
