using System.Threading.Channels;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "./data.txt";
            string output, line;
            int counter = 0;
            char[] separators = { '-', ' ', ':' };
            List<string> passwords = new List<string>();
            List<string> letter = new List<string>();
            List<int> minAllowed = new List<int>();
            List<int> maxAllowed = new List<int>();


            try
            {
                using(StreamReader sr = new StreamReader(input))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] splitOne = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        minAllowed.Add(int.Parse(splitOne[0]));
                        maxAllowed.Add(int.Parse(splitOne[1]));
                        letter.Add(splitOne[2]);
                        passwords.Add(splitOne[3]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            for (int i = 0; i < passwords.Count; i++)
            {
                if (Calculation( minAllowed[i], maxAllowed[i], letter[i], passwords[i]))
                {
                    counter ++;
                }

            }

            Console.WriteLine(counter);

        }
        public static bool Calculation(int min, int max, string letter, string password)
        {

            foreach(char c in letter)
            {
                int occurence = password.AsSpan().Count(c);
                    if( occurence < min || occurence > max) return false;
            }

            return true;
        }
    }


}
