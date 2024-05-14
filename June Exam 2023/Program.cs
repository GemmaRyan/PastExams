using System.Security.Cryptography;
using System.Xml.Serialization;

namespace June_Exam_2023
{
    internal class Program
    {
        static string[] properties = new string [4]; 
        static void Main(string[] args)
        {
            //string[] fields = new string[4];

            //for (int i = 0; i < properties.Length; i++) 
            //{
            //    Console.Write("Enter Rates Band if applicable y/n: ");
            //    string choice = Console.ReadLine().ToLower();

            //    if (choice == "y")      
            //    {
            //        CommercialProperty comProperty = new CommercialProperty();

            //        Console.Write("Enter Eircode: ");
            //        fields[0] = comProperty.Eircode = Console.ReadLine();

            //        Console.Write("Enter Rent: ");
            //        comProperty.Rent = double.Parse(Console.ReadLine());
            //        fields[1] = comProperty.Rent.ToString();

            //        Console.Write("Enter Bed Space Avaliable: ");
            //        comProperty.BedSpaces = int.Parse(Console.ReadLine());
            //        fields[2] = comProperty.BedSpaces.ToString();

            //        Console.Write("Enter Rates Band: ");
            //        fields[3] = comProperty.RateBand = Console.ReadLine();

            //        Console.WriteLine("");

            //        properties[i] = comProperty.ToString();

            //    }
            //    else {
            //        Property prop = new Property();

            //        Console.Write("Enter Eircode: ");
            //        fields[0] = prop.Eircode = Console.ReadLine();

            //        Console.Write("Enter Rent: ");
            //        prop.Rent = double.Parse(Console.ReadLine());
            //        fields[1] = prop.Rent.ToString();

            //        Console.Write("Enter Bed Space Avaliable: ");
            //        prop.BedSpaces = int.Parse(Console.ReadLine());
            //        fields[2] = prop.BedSpaces.ToString();

            //        Console.WriteLine("");

            //        properties[i] = prop.ToString();
            //    }
            //}


            Property property = new Property("D06k32", 1500, 3);
            properties[0] = property.ToString();
            Property property2 = new Property("D06k67", 2500, 2);
            properties[1] = property2.ToString();
            Property property3 = new Property("D06k88", 800, 1);
            properties[2] = property3.ToString();
            Property commercialProperty4 = new CommercialProperty("D06k55", 4000, 0, "A");
            properties[3] = commercialProperty4.ToString();
            

            //The final printing everything out 

            //{HouseNum,-5}{Eircode,-10}{Rent,-10}{EligibleForGrant(),-15}{BedSpaces,-15}{GetPricePerBedSpace(),-15}{RateBand,-10}
            Console.WriteLine($"{"#",-5}{"Eircode",-10}{"Rent",-9} {"Eligible", -12} {"Bed Spaces",-13} {"Cost per bed",-10} {"Rates",-8}");
            for (int i = 0; i < properties.Length; i++) 
            {
                Console.WriteLine(properties[i]);
            }

            Console.ReadKey();
        }
    }
}
