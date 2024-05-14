namespace Vivians_MovieApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieReport();
            //Movie myMovie = new Movie();

            //myMovie.Title = "Godfather";
            //myMovie.Genre = "Crime";
            //myMovie.Length = 180;
            //myMovie.Score = 10;

            //Console.WriteLine(  myMovie.Title);

            //Console.WriteLine( myMovie.ToString());

            //Movie myMovie2 = new Movie("The mist", "horror", 78, 7);

            //Console.WriteLine(myMovie2.ToString());

            //Console.WriteLine(myMovie.LengthMessage());

            //Console.WriteLine(myMovie2.LengthMessage());

            //Movie myMovie3 = new Movie();
            //Console.WriteLine(myMovie3.ToString());
        }




        static void MovieReport()
        {
            // read all data from csv file, write to a report on the console, with the avergae score


            Movie aMove = new Movie();

            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("movies.csv", FileMode.Open, FileAccess.Read); ;        //avoid putting the file into the bin folder --- use paths instead ../../../hgjfdg.cs
                sr = new StreamReader(fs);

                // to read the first line in file
                string recordIn = sr.ReadLine(); //skip because it has headers
                recordIn = sr.ReadLine();
                string[] fields = null;// new string[3]; // use this array to store chopped up line from file

                int sum = 0;
                int count = 0;

                Console.WriteLine($"{"Movie Name",-50}{"Genre",-50}{"Movie Length",-15}{"Score",-15}");
                while (recordIn != null)
                {
                    fields = recordIn.Split(','); // split where there is a comma
                                                  //Console.WriteLine(fields.Length);
                    if (fields.Length == 4)  // check that there are 3 fields
                    {

                        aMove.Title = fields[0];
                        aMove.Genre = fields[1];

                        // for the score field in student file you will have to do some work
                        // to pick out the score
                        aMove.Length = int.Parse(fields[2]);
                        aMove.Score = int.Parse(fields[3]);



                        sum += aMove.Score; // must convert to a number if doinf arithmetic

                        count++;

                        // convert score to grade

                        Console.WriteLine($"{aMove.Title,-50}{aMove.Genre,-50}{aMove.Length,-15}{aMove.Score,-15}");
                    }



                    recordIn = sr.ReadLine(); // read next record
                } // end loop - at the eof

                int avg = sum / count;
                Console.WriteLine("Average score = {0}", avg);




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
