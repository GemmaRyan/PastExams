/* This is Gemma's code
 * it doesnt work cuase onedrive fuck it up 
 * totally the only reason its not finished
 * 
 * I fucked around with it so just look at diarmuids code instead :) */











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

            try
            {
                fs = new FileStream("students.txt", FileMode.Open, FileAccess.Read); ;
                sr = new StreamReader(fs);


                // to read the first line in file
                string recordIn = sr.ReadLine();

                string[] fields = null;
                
                int cityNum;
                string cityName;
                int temperature;


            }

            catch (IOException myError)
            {
                Console.WriteLine(myError.Message);

            }
            catch (Exception myError) // general exception which will be used if not exact match found
            {
                Console.WriteLine("there was a problem");
            }
            finally
            {
                if (sr != null)
                    sr.Close();

            }


        }
    }
}
