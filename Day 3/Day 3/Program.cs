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

            List<char> extracted = ExtractPatternCharacters(pattern, 3, 1);

            int treesCount = extracted.Count(c => c == '#');
            Console.WriteLine(treesCount);

        }

        public static List<char> ExtractPatternCharacters(char[][] input, int right, int down)
        {
            int width = input[0].Length; 
            int height = input.Length;

            List<char> extractedChars = new List<char>();

            for (int x = 0, y = 0; y < height; x += right, y += down)
            {
                extractedChars.Add(input[y][x % width]);
            }

            return extractedChars;
        }

    }
}
