namespace Michaels_June2023_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($" {"#",-10} {"Eircode",-10} {"Rent",-10} {"Eligible",-10} {"Bed Spaces",-10} {"Cost per bed Rates",-10}");
            //Question 1

            Propertiy prop = new Propertiy("d913k5", 1400, 3);
            Console.WriteLine(prop.ToString());

            CommercialProperty prop2 = new CommercialProperty("d913k5", 1000, 2, "A");
            Console.WriteLine(prop2.ToString());
            //Question2

            string Path = "../../../baseText.txt";

            try
            {

                using (StreamReader sr = File.OpenText(Path))
                {
                    string input;

                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] field = input.Split(',');
                        double rent; int bedSpaces;

                        if (field.Length == 3 && double.TryParse(field[1], out rent) && int.TryParse(field[2], out bedSpaces) && bedSpaces > 0)
                        {
                            Propertiy[] prop3 = new Propertiy[4];
                            prop = new Propertiy(field[0], rent, bedSpaces);
                            Console.WriteLine(prop.ToString());

                        }
                        else if (field.Length == 4 && double.TryParse(field[1], out rent) && (int.TryParse(field[2], out bedSpaces)) && bedSpaces > 0)
                        {
                            CommercialProperty[] prop4 = new CommercialProperty[4];
                            prop4[0] = new CommercialProperty(field[0], rent, bedSpaces, field[3]);

                        }
                        else
                        {
                            throw new ArgumentException("Error in input" + input);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error input" + ex);
            }

        }
    }
}
