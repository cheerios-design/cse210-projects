public class Assignment
{
    // Fields are made readonly
    private readonly string _studentName;
    private readonly string _topic;

    // Constructor initializes readonly fields
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Properties with expression-bodied syntax
    public string StudentName => _studentName;
    public string Topic => _topic;

    // Method with expression-bodied syntax
    public string GetSummary() => $"{_studentName} - {_topic}";
}
