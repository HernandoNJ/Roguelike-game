using CookiesCookBook.Test.Interfaces;

namespace CookiesCookBook.Test.Repos
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        public string FilePath { get; private set; }

        protected BaseRepository(string folder, string fileName)
        {
            FilePath = GeneratePath(folder, fileName);
        }
        public abstract List<T> Read();
        public abstract void Save(List<T> items);
        public string GetPath() => FilePath;
        protected string GeneratePath(string folder, string fileName)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.FullName ?? baseDir;

            string fullFolder = Path.Combine(projectDir, folder);
            if (!Directory.Exists(fullFolder))
            {
               Console.WriteLine($"Folder '{fullFolder}' does not exist, Trying to create a new folder");
                Directory.CreateDirectory(fullFolder);
            }

            return Path.Combine(fullFolder, fileName);
        }
    }
}
