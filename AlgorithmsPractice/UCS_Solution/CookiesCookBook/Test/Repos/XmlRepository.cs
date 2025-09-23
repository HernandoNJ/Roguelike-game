using System.Xml.Serialization;

namespace CookiesCookBook.Test.Repos
{
    public class XmlRepository<T> : BaseRepository<T>
    {
        public XmlRepository(string folder, string fileName) : base(folder, fileName) { }

        public override List<T> Read()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<T>();

                var serializer = new XmlSerializer(typeof(List<T>));
                using var reader = new StreamReader(FilePath);
                return (List<T>?)serializer.Deserialize(reader) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML: {ex.Message}");
                return new List<T>();
            }
        }

        public override void Save(List<T> items)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using var writer = new StreamWriter(FilePath);
                serializer.Serialize(writer, items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing XML: {ex.Message}");
            }
        }
    }
}