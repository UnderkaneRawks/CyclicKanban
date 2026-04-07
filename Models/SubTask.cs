using SQLite; // Don't forget this at the top!

namespace CyclicKanban.Models
{
    public class SubTask
    {
        // Every table needs its own Primary Key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // The Foreign Key! This links it back to the specific KanbanTask
        public int KanbanTaskId { get; set; }

        public string Name { get; set; }
        public bool IsDone { get; set; }
        public TimeSpan? TargetTime { get; set; }
        public TimeSpan ActualTime { get; set; }
        public string Notes { get; set; }
    }
}