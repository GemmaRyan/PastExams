namespace Diarmuid_2_June_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> allCitites = new List<string>();
            string path = @"../../../cities.csv";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {

                    StreamReader sr = new StreamReader(fs);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        allCitites.Add(line);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException myError)
            {
                Console.WriteLine("File issue");
            }
            List<string> readInList = new List<string>();
            string searchAgain = "yes";
            do
            {
                Console.Write("Please enter city name: ");
                string cityName = Console.ReadLine();
                bool notfound = true;
                for (int i = 0; i < allCitites.Count; i++)
                {
                    readInList = allCitites[i].Split(',').ToList();
                    if (readInList[1] == cityName)
                    {
                        if (int.Parse(readInList[2]) < 10)
                        {
                            Console.WriteLine($"It's cold in {cityName}");
                        }
                        else if (int.Parse(readInList[2]) < 25)
                        {
                            Console.WriteLine($"It's moderate in {cityName}");
                        }
                        else
                        {
                            Console.WriteLine($"It's hot in {cityName}");
                        }

                        notfound = false;
                    }
                }
                if (notfound)
                {
                    Console.WriteLine($"Sorry no data for {cityName}");
                }
                do
                {
                    Console.Write("Search again: ");
                    searchAgain = Console.ReadLine();
                }
                while (searchAgain.ToLower() != "yes" && searchAgain.ToLower() != "no");

            }
            while (searchAgain.ToLower() == "yes");
        }

    }
}
