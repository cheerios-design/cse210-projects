public class MathAssignment : Assignment
{
    // Fields are made readonly
    private readonly string _textbookSection;
    private readonly string _problems;

    // Constructor calls base constructor and initializes readonly fields
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method with expression-bodied syntax
    public string GetHomeworkList() => $"Section {_textbookSection} Problems {_problems}";
}
