public class SubTask
{
    public string Name { get; set; }
    public bool IsDone { get; set; }

    // The '?' makes the TimeSpan nullable, meaning the user doesn't HAVE to set a timer.
    public TimeSpan? TargetTime { get; set; }
    public TimeSpan ActualTime { get; set; }

    public string Notes { get; set; }
}