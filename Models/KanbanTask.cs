public class KanbanTask
{
    public string ProjectName { get; set; }
    public string Category { get; set; }
    public string TaskName { get; set; }

    // An Array strictly limited to 7 slots
    public SubTask[] SubTasks { get; set; } = new SubTask[7];
}