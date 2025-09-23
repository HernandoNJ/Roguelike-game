using System.Text.Json;

namespace CookiesCookBook.Test.Repos
{
    public class JsonRepository<T> : BaseRepository<T>
    {
        public JsonRepository(string folder, string fileName) : base(folder, fileName) { }

        public override List<T> Read()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<T>();

                var json = File.ReadAllText(FilePath);
                var items = JsonSerializer.Deserialize<List<T>>(json);

                if (items == null)
                {
                    Console.WriteLine("Warning: JSON file was empty or invalid.");
                    return new List<T>();
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
                return new List<T>();
            }
        }

        public override void Save(List<T> items)
        {
            try
            {
                var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing JSON: {ex.Message}");
            }
        }
    }
}
