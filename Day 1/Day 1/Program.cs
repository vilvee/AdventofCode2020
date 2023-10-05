namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string input = "./data.txt";
			string output, line;
            List<int> nums = new List<int>();
            int result;


            try
            {
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(input))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        nums.Add(int.Parse(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < nums.Count; i++)
            { 
                for(int j = 0; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] == 2020)
                    {
                        Console.WriteLine(nums[i] * nums[j]);
                        break;
                    }
                }
            }
        }
    }
}
