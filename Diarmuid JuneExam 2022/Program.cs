using System.ComponentModel;

namespace Diarmuid_JuneExam_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Property> properties = new List<Property>();
            Property property = new Property("D06k32", 1500, 3);
            properties.Add(property);
            Property property2 = new Property("D06k67", 2500, 2);
            properties.Add(property2);
            Property property3 = new Property("D06k88", 800, 1);
            properties.Add(property3);
            //Property commercialProperty4 = new CommercialProperty("D06k55", 4000, 0, "A");
            //properties.Add(commercialProperty4);
            Property property4 = new Property("D06k55", 4000, 0);
            properties.Add(property4);



            for (int i = 0; i < properties.Count; i++)
            {
                Console.WriteLine(properties[i]);
            }
        }
    }
}

