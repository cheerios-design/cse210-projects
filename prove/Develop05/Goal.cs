
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _pointAmount;
    protected bool _isCompletable;
    private bool _isComplete;

    public Goal(string Name, string Description, int PointAmount, bool IsCompletable)
    {
        _name = Name;
        _description = Description;
        _pointAmount = PointAmount;
        _isCompletable = IsCompletable;
    }
    
    public bool IsCompletable()
    {
        return _isCompletable;
    }
    public int GetPointAmount()
    {
        return _pointAmount;
    }
    public void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();

        Console.Write("What is a short description of the goal? ");
        _description = Console.ReadLine();

        Console.Write("What is the point value for this goal? ");
        var num = int.Parse(Console.ReadLine());
        var _pointAmount = num;

        _isComplete = false;
    }
    public abstract bool RecordEvent();

    internal object GetName()
    {
        throw new NotImplementedException();
    }

    internal object GetDescription()
    {
        throw new NotImplementedException();
    }
}