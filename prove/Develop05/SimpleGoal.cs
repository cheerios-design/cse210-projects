using System.Reflection.Metadata.Ecma335;

public class SimpleGoal : Goal
{
    public SimpleGoal(string Name, string Description, int PointAmount, bool IsCompletable): base(Name, Description, PointAmount, true)
    {}

    public override bool RecordEvent()
    {
        _isCompletable = true;
        return _isCompletable;
    }

}