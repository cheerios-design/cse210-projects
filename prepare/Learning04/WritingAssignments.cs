public class WritingAssignment : Assignment
{
    // Fields are made readonly
    private readonly string _title;

    // Constructor calls base constructor and initializes readonly fields
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method with expression-bodied syntax
    public string GetWritingInformation() => $"{_title} by {StudentName}";
}
