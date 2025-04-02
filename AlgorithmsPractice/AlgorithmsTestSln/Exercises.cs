namespace AlgorithmsTest;

public class Exercises
{
    #region 2D Array

    /* Explanation
    i index for rows
    j index for columns
    index i = 0, index j = 0 ... A
    index i = 0, index j = 1 ... B
    index i = 0, index j = 2 ... C
    Next row
    index i = 1, index j = 0 ... D
    index i = 1, index j = 1 ... E
    index i = 1, index j = 2 ... F
    */

        char[,] letters = new char[2, 3]
        {
            { 'A', 'B', 'C' },
            { 'D', 'E', 'F' },
        };

        public void PrintLetters()
        {
            var height = letters.GetLength(0);
            var width = letters.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine($"i is {i}");
                for (int j = 0; j < width; j++)
                {
                    Console.WriteLine($"j is {j}");
                    Console.WriteLine($"letter is {letters[i, j]}");
                }

                if (i == 0) Console.WriteLine("********* New row ***************");
            }
        }

        /* Exercise: Find Max value
         *Return the maxim value from the array.
         * If any of the array's dimensions is zero, it means the array is empty, and the method should return -1.
         */

        int FindMax(int[,] numbers)
        {
            var width = numbers.GetLength(0);
            var height = numbers.GetLength(1);

            if (width == 0 || height == 0) return -1;

            int max = numbers[0, 0];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (numbers[i, j] > max) max = numbers[i, j];
                }
            }

            return max;
        }

    #endregion

    #region Foreach
    // Used to execute code on every item in a collection

    bool IsAnyWordLongerThan(int length, string[] words)
    {
        foreach (var w in words)
        {
            if (w.Length > length) return true;
        }

        return false;
    }

    #endregion

    #region PrintWords

        List<string> words = ["Uno", "Dos", "Tres", "Cuatro", "Cinco"];

        public void PrintWords()
        {
            foreach (var word in words) Console.WriteLine(word);
        }
        public void PrintNewWords()
        {
            Console.WriteLine("********* New Words **************");
            Console.WriteLine();
            words.AddRange(["Seis","Siete"]);
            foreach (var word in words) Console.Write(word + " - ");
        }
    #endregion
        
    #region ArraySum
    
    public static int simpleArraySum(List<int> ar)
    {
        var sum = 0;
        foreach (var n in ar) sum += n;
        return sum;
    }
    
    public void PrintArraySumText()
    {
        Console.WriteLine("******* Array Sum ************");
        Console.WriteLine();
        Console.WriteLine("Enter numbers separated by spaces.");
        ConsoleReadText();
        //StreamWriterText();

        void ConsoleReadText()
        {
            var ar = Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .ToList()
                .Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            var result = simpleArraySum(ar);
            Console.WriteLine(result);
        }

        void StreamWriterText()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = simpleArraySum(ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
    
    #endregion
    
    #region CompareTriplets
    
    #endregion
    
}