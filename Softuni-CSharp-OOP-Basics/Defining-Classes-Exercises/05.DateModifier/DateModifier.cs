using System;

class DateModifier
{
    private DateTime startingDate;
    private DateTime endDate;

    public DateTime StartingDate = new DateTime();
    public DateTime EndDate = new DateTime();

    public DateModifier(DateTime startDate, DateTime endDate)
    {
        StartingDate = startDate;
        EndDate = endDate;
    }

    public int GetDifferenceBetweenDates()
    {
        int difference = (StartingDate - EndDate).Days;
        return Math.Abs(difference);
    }
}
