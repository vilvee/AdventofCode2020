using System.Reflection;
using System.Text;
using static System.Text.RegularExpressions.Regex;

namespace Day_4
{
    internal class Program
    {
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

            Console.WriteLine(passportList.Count);
            int validPassports = PassportFieldVerification(passports, fields);
            Console.WriteLine(validPassports);


        }

        /*PART 1
                public static int PassportFieldVerification(string[][] passports, string[] fields)
                {
                    return passports.Count(passport => fields.All(field => passport.Any(line => line.StartsWith(field))));
                }
        */

        public static int PassportFieldVerification(string[][] passports, string[] fields)
        {
            int validPassportsCount = 0;

            foreach (var passport in passports)
            {
                bool allFieldsPresent = true;

                foreach (string field in fields)
                {
                    bool fieldPresent = false;

                    foreach (string line in passport)
                    {
                        if (line.StartsWith(field))
                        {
                            fieldPresent = ValidateField(line, field);
                            break;
                        }
                    }

                    if (!fieldPresent)
                    {
                        allFieldsPresent = false;
                        break;
                    }
                }

                if (allFieldsPresent)
                {
                    validPassportsCount++;
                }

            }

            return validPassportsCount;
        }

        public static bool ValidateField(string line, string field)
        {
            string[] lines = line.Split(':');
            string fieldInfo = lines[1];


            switch (field)
            {
                case "byr":
                    int number = int.Parse(fieldInfo);
                    bool fourDigits = fieldInfo.Length == 4;
                    bool withinRange = number is >= 1920 and <= 2002;
                    return (fourDigits && withinRange);
                case "iyr":
                    number = int.Parse(fieldInfo);
                    fourDigits = fieldInfo.Length == 4;
                     withinRange = number is >= 2010 and <= 2020;
                    return (fourDigits && withinRange);
                case "eyr":
                    number = int.Parse(fieldInfo);
                    fourDigits = fieldInfo.Length == 4;
                     withinRange = number is >= 2020 and <= 2030;
                    return (fourDigits && withinRange);
                case "hgt":
                    return ValidateHeight(fieldInfo);
                case "hcl":
                    return IsMatch(fieldInfo, @"^#[0-9a-fA-F]{6}$");
                case "ecl":
                    string[] eyeColors = { "blu", "amb", "brn", "gry", "grn", "hzl", "oth" };
                    return Array.Exists(eyeColors, color => color == fieldInfo);
                case "pid":
                    return IsMatch(fieldInfo, @"^\d{9}$");
                default:
                    return false;

            }
        }

        static bool ValidateHeight(string fieldInfo)
        {
            StringBuilder heightString = new StringBuilder();
            StringBuilder unit = new StringBuilder();
            foreach (var c in fieldInfo)
            {
                if (char.IsDigit(c))
                {
                    heightString.Append(c);
                }
                else
                {
                    unit.Append(c);
                }
            }

            int height = Convert.ToInt32(heightString.ToString());

            if (unit.ToString() == "cm")
            {
                return height is >= 150 and <= 193;
            }
            else if (unit.ToString() == "in")
            {
                return height is >= 59 and <= 76;
            }
            return false;
        }
    }
}
