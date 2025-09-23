using CookiesCookBook.Test;
using CookiesCookBook.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Test.Repos
{
    public class TextFileRepository<T> : BaseRepository<T>
    {
        private readonly ITextFormatter<T> _formatter;

        public TextFileRepository(string folder, string fileName, ITextFormatter<T> formatter)
            : base(folder, fileName)
        {
            _formatter = formatter;
        }

        public override List<T> Read()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<T>();

                var lines = File.ReadAllLines(FilePath);
                return lines.Select(line => _formatter.Deserialize(line)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading text file: {ex.Message}");
                return new List<T>();
            }
        }

        public override void Save(List<T> items)
        {
            try
            {
                var lines = items.Select(item => _formatter.Serialize(item));
                File.WriteAllLines(FilePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing text file: {ex.Message}");
            }
        }
    }
}