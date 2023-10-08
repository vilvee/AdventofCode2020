namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "./data.txt";
            string line;
            List<string> seatsList = new List<string>();
            List<int> seatIDs = new List<int>();

            using (StreamReader sr = new StreamReader(input))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    seatsList.Add(line);
                }
            }

            foreach (string seat in seatsList)
            {
                seatIDs.Add(SeatingLocator(seat));
            }



            seatIDs.Sort();

            //PART 2

            var result = Enumerable.Range(68, seatsList.Count).Except(seatIDs).ToArray();
            
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            
            Console.WriteLine(seatIDs.Last() );
        }

        /// <summary>
        /// PART 1
        /// </summary>
        static int SeatingLocator(string seat)
        {

            var seatRows = Enumerable.Range(0, 128).ToArray();
            var seatNumbers = Enumerable.Range(0, 8).ToArray();
            int lowerHalfRows = 0;
            int upperHalfRows = seatRows.Length - 1;
            int lowerHalfSeat = 0;
            int upperHalfSeat = seatNumbers.Length -1;
            int rowNumber = 0, seatNumber = 0;

            for (int i = 0; i < 7; i++)
            {
                int middleRows = (int)(upperHalfRows + lowerHalfRows) / 2;

                if (seat[i].Equals('B'))
                {
                    lowerHalfRows = middleRows + 1;
                }
                else if (seat[i].Equals('F'))
                {
                    upperHalfRows = middleRows;
                }

                rowNumber = (seat[6] == 'B') ? upperHalfRows : lowerHalfRows;
            }

            for (int i = 7; i < 10; i++)
            {
                int middleSeat = (int)(upperHalfSeat + lowerHalfSeat) / 2;

                if (seat[i].Equals('R'))
                {
                    lowerHalfSeat = middleSeat + 1;

                }
                else if (seat[i].Equals('L'))
                {
                    upperHalfSeat = middleSeat;

                }

                seatNumber = (seat[9] == 'R') ? upperHalfSeat : lowerHalfSeat;

            }


            //Console.WriteLine($"Row: {rowNumber}  Column: {seatNumber} Seat ID:{(rowNumber * 8) + seatNumber}");
            return (rowNumber * 8) + seatNumber;
        }
    }
}
