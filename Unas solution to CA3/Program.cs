namespace Unas_solution_to_CA3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Event ev = new Event("hello", "opps", -3, 2);


            string path = @"../../../testData2.csv";
            List<Event> events = ReadEvents(path);


            foreach (Event e in events)
                Console.WriteLine(e.ToString());
        }
        static List<Event> ReadEvents(string path)
        {
            List<Event> events = new List<Event>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string input;
                    string name;
                    string eventType;
                    decimal price;
                    int capactity;
                    int seatsSold;

                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] fields = input.Split(',');

                        // Note that the data is not sufficiently validated here. What additional checks would you add?

                        if ((fields.Length == 5)

                            && (decimal.TryParse(fields[2], out price))
                            && (int.TryParse(fields[3], out capactity))
                            && (int.TryParse(fields[4], out seatsSold))
                            && (price > 0)
                            && (capactity > 0)
                            && (seatsSold > 0))
                        {
                            name = fields[0];
                            eventType = fields[1];
                            Event ev = new Event(name, eventType, price, capactity, seatsSold);
                            events.Add(ev);  
                        }
                        else if ((fields.Length == 4)
                        && (decimal.TryParse(fields[2], out price))
                        && (int.TryParse(fields[3], out capactity))
                        && (price > 0)
                        && (capactity > 0))

                        {
                            name = fields[0];
                            eventType = fields[1];
                            Event ev = new Event(name, eventType, price, capactity);
                            events.Add(ev);
                        }
                        else
                        {
                            Console.WriteLine("Error in input " + input);

                        }
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File: {path} not found: {ex.Message}");
            }
            return events;
        }
    }
}
