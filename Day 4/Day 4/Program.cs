namespace Day_4
{
    internal class Program
    {
        /*byr (Birth Year)
           iyr (Issue Year)
           eyr (Expiration Year)
           hgt (Height)
           hcl (Hair Color)
           ecl (Eye Color)
           pid (Passport ID)
           cid (Country ID)
        */
        static void Main(string[] args)
        {
            string input = "./data.txt";
            string line;
            List<string[]> passportList = new List<string[]>();
            string[] fields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            using (StreamReader st = new StreamReader(input))
            {
                List<string> currentPassport = new List<string>();

                while ((line = st.ReadLine()) != null)
                {

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (currentPassport.Count > 0)
                        {
                            passportList.Add(currentPassport.SelectMany(entry => entry.Split(' ')).ToArray());
                            currentPassport.Clear();
                        }
                    }
                    else
                    {
                        currentPassport.Add(line);
                    }
                }

                // Process any remaining passport data after the loop
                if (currentPassport.Count > 0)
                {
                    passportList.Add(currentPassport.SelectMany(entry => entry.Split(' ')).ToArray());
                }
            }

            // Convert the list of passport strings to a jagged array
            string[][] passports = passportList.ToArray();


            int validPassports = PassportFieldVerification(passports, fields);
            Console.WriteLine(validPassports);


        }
        public static int PassportFieldVerification(string[][] passports, string[] fields)
        {
            return passports.Count(passport => fields.All(field => passport.Any(line => line.StartsWith(field))));
        }

    }
}
