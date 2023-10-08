using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "./data.txt";

            //PART 1
            //  List<string> groupList = DivideGroupsAnyone(input);
            //  groupList.ForEach(group => Console.WriteLine(group));
            //  int totalYes = groupList.Sum(group => group.Length);
            //  Console.WriteLine(totalYes);

            //Part

            List<string> groupList2 = DivideGroupsEveryone(input);
            // groupList2.ForEach(group => Console.WriteLine(group));
            int totalYes = groupList2.Sum(group => group.Length);
            Console.WriteLine(totalYes);



        }

        private static List<string> DivideGroupsAnyone(string input)
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

        private static List<string> DivideGroupsEveryone(string input)
        {
            List<string> groupList = new List<string>();

            using (StreamReader sr = new StreamReader(input))
            {
                List<string> lines = new List<string>();
                string line;
                int peopleCounter = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (lines.Count > 0)
                        {
                            string joinLines = string.Join("", lines);
                            string everyoneYes = new string(joinLines.Where(c =>
                                joinLines.Count(ch => ch == c) == peopleCounter).ToArray());
                            string uniqueAnswers = new string(everyoneYes.Distinct().ToArray());
                            groupList.Add(string.Join("", uniqueAnswers));
                            peopleCounter = 0;
                            lines.Clear();


                        }
                    }
                    else
                    {
                        lines.Add(line);
                        peopleCounter++;
                    }
                }
                if (lines.Count > 0)
                {
                    string joinLines = string.Join("", lines);
                    string everyoneYes = new string(joinLines.Where(c =>
                        joinLines.Count(ch => ch == c) == peopleCounter).ToArray());
                    string uniqueAnswers = new string(everyoneYes.Distinct().ToArray());
                    groupList.Add(string.Join("", uniqueAnswers));
                    peopleCounter = 0;
                }
            }
            return groupList;
        }
    }
}
