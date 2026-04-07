using SQLite; // Needed for SQLiteConnection
using System.IO;
using CyclicKanban.Models; // Needed so this file knows what a KanbanTask is

namespace CyclicKanban.Data
{
    public class LocalDbService
    {
        private readonly string _dbPath;

        // This variable holds our active connection to the database
        private SQLiteConnection _connection;

        public LocalDbService()
        {
            _dbPath = Path.Combine(FileSystem.AppDataDirectory, "kanban.db3");
        }

        // We will call this method right when the app starts
        public void Init()
        {
            // If the connection is already open, stop here so we don't do it twice
            if (_connection != null)
                return;

            // Step 1: Establish the connection (and create the file if needed)
            _connection = new SQLiteConnection(_dbPath);

            // Step 2: Create the tables based on our Blueprints!
            // Note: If the tables already exist from a previous launch, SQLite just safely ignores this.
            _connection.CreateTable<KanbanTask>();
            _connection.CreateTable<SubTask>();
        }

        public void AddTask(KanbanTask newTask)
        {
            Init(); // Make sure the database is ready before we try to use it
            _connection.Insert(newTask); // This will turn C# objects into database rows for us
        }

        public List<KanbanTask> GetTasks()
        {
            Init(); // Make sure the database is ready before we try to use it
            return _connection.Table<KanbanTask>().ToList(); // This will turn database rows back into C# objects for us
        }

        public void UpdateTask(KanbanTask task)
        {
            Init(); // Make sure the database is ready before we try to use it
            _connection.Update(task); // This will update the existing row in the database that matches the Id of the task we pass in
        }

        public void DeleteTask(KanbanTask task)
        {
            Init(); // Make sure the database is ready before we try to use it
            _connection.Delete(task); // This will delete the row in the database that matches the Id of the task we pass in
        }

        public List<SubTask> GetSubTasks(int taskId)
        {
            Init(); // Make sure the database is ready before we try to use it
            return _connection.Table<SubTask>()
                .Where(s => s.KanbanTaskId == taskId)
                .ToList(); // This will return all subtasks that belong to the given taskID
        }
    }
}