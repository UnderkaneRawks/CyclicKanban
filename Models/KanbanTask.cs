using SQLite; // We must add this at the very top of the file!

namespace CyclicKanban.Models
{
    public class KanbanTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ProjectName { get; set; }
        public string Category { get; set; }
        public string TaskName { get; set; }

        // Using [Ignore] so that SQLite doesn't try to store this array directly in the database
        [Ignore]
        public SubTask[] SubTasks { get; set; } = new SubTask[7];
    }
}