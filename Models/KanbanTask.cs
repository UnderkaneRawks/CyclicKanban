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

        // We will need to change this array shortly!
        public SubTask[] SubTasks { get; set; } = new SubTask[7];
    }
}