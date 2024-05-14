namespace June_Exam_2023_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../../cities.txt";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(fs);
            string lineIn = sr.ReadLine();
            bool found;

            int cityNum;
            string[] city = new string[6];
            double[] temperature = new double[6];
            int i = 0;

            try
            {
                string[] fields = null;

                while (lineIn != null)
                {
                    fields = lineIn.Split(',');



                    cityNum = int.Parse(fields[0]);
                    city[i] = fields[1];
                    temperature[i] = double.Parse(fields[2]);

                    lineIn = sr.ReadLine();
                    i++;
                }

                if (sr != null)
                    sr.Close();
            }
            catch (IOException myError)
            {
                Console.WriteLine(myError.Message);

            }
            catch (Exception myError)
            {
                Console.WriteLine("there was a problem");
            }

            if (sr != null)
                sr.Close();
            // WeatherDescriptions(temperature);
        }
        static private string WeatherDescriptions(double temperature)
        {
            if (temperature > 25)
            {
                return "It's hot!";
            }
            else if (temperature <= 25 && temperature >= 10)
            {
                return "It's moderate.";
            }
            else { return "It's cold!"; }

        }
    }
}