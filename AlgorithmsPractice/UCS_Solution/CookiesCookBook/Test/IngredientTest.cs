using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Test
{
    public class IngredientTest
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public IngredientTest(string name, string instructions)
        {
            Name = name;
            Instructions = instructions;
        }
    }
}
