using System;

public class CourseNotFoundException : Exception
{
    private const string InvalidNumberOfScoresMessage = "The number of scores for the given course is greater than the possible.";

    public CourseNotFoundException()
        :base(InvalidNumberOfScoresMessage)
    {
        
    }

    public CourseNotFoundException(string message)
        :base(message)
    {
        
    }
}

