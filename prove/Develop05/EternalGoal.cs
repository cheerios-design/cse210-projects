public class EternalGoal : Goal
{
    public EternalGoal(string Name, string Description, int PointAmount): base(Name, Description, PointAmount, true){}

    public override bool RecordEvent()
    {
        _isCompletable = false;
        return _isCompletable;
    }
}