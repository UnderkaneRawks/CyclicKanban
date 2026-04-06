using System.IO; //Brings tools for handling file paths and directories

namespace CyclicKanban.Data
{
    public class LocalDbService
    {
        // private variable to hold the path to the database file
        private readonly string _dbPath;

        public LocalDbService()
        {
            // Combines the app's data directory with the database file name to create the full path
            _dbPath = Path.Combine(FileSystem.AppDataDirectory, "kanban.db3");
        }
    }
}