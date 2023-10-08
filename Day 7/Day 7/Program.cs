using System.Text;
using System.Text.RegularExpressions;

namespace Day_7
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string inputt = "./data.txt";
            Dictionary<string, List<string>> bags = ExtractBags(inputt);

            string targetBag = "shiny gold";
            int count = 0;


            foreach (string bag in bags.Keys)
            {
                if (CanContain(bag, targetBag, bags))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static bool CanContain(string currentBag, string target, Dictionary<string, List<string>> bags)
        {
            //no key found
            if (!bags.ContainsKey(currentBag))
            {
                return false;
            }

            //current bag directly contains the target
            if (bags[currentBag].Contains(target))
            {
                return true;
            }

            // current bag can indirectly contain the target
            foreach (string insideBag in bags[currentBag])
            {
                if (CanContain(insideBag, target, bags))
                {
                    return true;
                }
            }

            return false;
        }


        static Dictionary<string, List<string>> ExtractBags(string inputt)
        {
            Dictionary<string, List<string>> bags = new Dictionary<string, List<string>>();

            using (StreamReader sr = new StreamReader(inputt))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    List<string> values = new List<string>(); ;

                    var words = line.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    string key = words.Length > 1 ? $"{words[0]} {words[1]}" : "";

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (Regex.IsMatch(words[i], @"^\d+$"))
                        {
                            if (i + 2 < words.Length)
                            {
                                values.Add($"{words[i + 1]} {words[i + 2]}");
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(key) && values.Count > 0)
                    {
                        bags.Add(key, values);
                    }

                }
                return bags;
            }
        }
    }
}
