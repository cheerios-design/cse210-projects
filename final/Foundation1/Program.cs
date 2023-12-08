using System;
using System.Collections.Generic;

// Abstract class for Comment
public abstract class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    // Abstract method to display comment information
    public abstract void DisplayComment();
}

// Concrete class for TextComment, inheriting from Comment
public class TextComment : Comment
{
    public TextComment(string commenterName, string commentText) : base(commenterName, commentText) { }

    // Implementation of the abstract method to display text comments
    public override void DisplayComment()
    {
        Console.WriteLine($"{CommenterName}: {CommentText}");
    }
}

// Abstract class for Video
public abstract class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    protected List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    // Abstract method to add comments
    public abstract void AddComment(string commenterName, string commentText);

    // Abstract method to get the number of comments
    public abstract int GetNumComments();

    // Abstract method to display video information
    public abstract void DisplayVideoInfo();
}

// Concrete class for VideoWithTextComments, inheriting from Video
public class VideoWithTextComments : Video
{
    public VideoWithTextComments(string title, string author, int lengthSeconds) : base(title, author, lengthSeconds) { }

    // Implementation of the abstract method to add text comments
    public override void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new TextComment(commenterName, commentText);
        comments.Add(newComment);
    }

    // Implementation of the abstract method to get the number of comments
    public override int GetNumComments()
    {
        return comments.Count;
    }

    // Implementation of the abstract method to display video information
    public override void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            comment.DisplayComment();
        }
        
        Console.WriteLine("\n" + new string('-', 30) + "\n");  // Separator between videos
    }
}

class Program
{
    static void Main()
    {
        // Creating videos and adding comments
        Video video1 = new VideoWithTextComments("Python Basics", "John Doe", 300);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "I learned a lot, thanks!");

        Video video2 = new VideoWithTextComments("Web Development with Django", "Jane Smith", 600);
        video2.AddComment("Charlie", "Awesome content!");
        video2.AddComment("David", "Could you make a series on advanced topics?");

        Video video3 = new VideoWithTextComments("Machine Learning Fundamentals", "Alex Johnson", 450);
        video3.AddComment("Eva", "Very informative, thanks!");
        video3.AddComment("Frank", "I have a question about the third concept.");

        // Creating a list of videos
        List<Video> videoList = new List<Video> { video1, video2, video3 };

        // Displaying information for each video
        foreach (Video video in videoList)
        {
            video.DisplayVideoInfo();
        }
    }
}
