public class ChecklistGoal : Goal
{
    private int _repetitions;
    private int _completedRepetitions;

    public ChecklistGoal(string Name, string Description, int PointAmount, int Repetitions, int CompletedRepetitions): base(Name, Description, PointAmount, true)
    {
        _repetitions = Repetitions;
        _completedRepetitions = CompletedRepetitions;
    }
    public override bool RecordEvent()
    {
        _isCompletable = true;
        return _isCompletable;
    }
    
}