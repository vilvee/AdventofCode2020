using System.Linq;
using System.Threading.Channels;
using static System.Collections.Specialized.BitVector32;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "./data.txt";
            
            List<string> groupList = DivideGroups(input);

            //groupList.ForEach(group => Console.WriteLine(group));
            int totalYes = 0;
            foreach (var group in groupList)
            {
                totalYes += group.Length;
            }

            Console.WriteLine(totalYes);

        }

        private static List<string> DivideGroups(string input)
        {
            List<string> groupList = new List<string>();

            using (StreamReader sr = new StreamReader(input))
            {
                List<string> lines = new List<string>();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (lines.Count > 0)
                        {
                            string joinLines = string.Join("", lines);
                            string uniqueAnswers = new string(joinLines.Distinct().ToArray());
                            groupList.Add(string.Join("", uniqueAnswers));
                            lines.Clear();
                        }
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }

                if (lines.Count > 0)
                {
                    string joinLines = string.Join("", lines);
                    string uniqueAnswers = new string(joinLines.Distinct().ToArray());
                    groupList.Add(string.Join("", uniqueAnswers));
                  
                }
            }
            return groupList;
        }
    }
}
