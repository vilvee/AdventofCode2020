using System.Threading.Channels;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = "./data.txt";

            string[] patternLines = File.ReadAllLines(input);

            char[][] pattern = patternLines.Select(x => x.ToArray()).ToArray();

            //part 1
           // List<char> extracted = ExtractPatternCharacters(pattern, 3, 1);
           // int treesCount = extracted.Count(c => c == '#');
           // Console.WriteLine(treesCount);

            //part 2
            int[] rightSlopes = { 1, 3, 5, 7, 1 };
            int[] downSlopes = { 1, 1, 1, 1, 2 };
            List<char> extracted = new List<char>();
            int[] numsOfTrees = new int[rightSlopes.Length];

            for (int i = 0; i < rightSlopes.Length; i++)
            {
                extracted = ExtractPatternCharacters(pattern, rightSlopes[i], downSlopes[i]);
                numsOfTrees[i] = extracted.Count(c => c == '#');
            }

            foreach (var tree in numsOfTrees)
            {
                Console.WriteLine(tree);
            }

            long prod = numsOfTrees.Aggregate(1L, (a, b) => a * b);
            Console.WriteLine(prod);
        }

        public static List<char> ExtractPatternCharacters(char[][] input, int right, int down)
        {
            int width = input[0].Length; 
            int height = input.Length;

            List<char> extractedChars = new List<char>();

            for (int x = 0, y = 0; y < height; x += right, y += down)
            {
                extractedChars.Add(input[y][x % width]); //wrap around
            }

            return extractedChars;
        }

    }
}
