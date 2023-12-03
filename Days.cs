using System.Collections.Generic;

public class Days
{
    public static readonly List<string> AllDays = new List<string>
    {
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sunday"
    };

    public static bool IsValidDay(string day)
    {
        return AllDays.Contains(day);
    }
}