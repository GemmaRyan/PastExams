namespace Viv_Search_File_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReadOneRecordFromFile();
            //ReadManyRecordFromFile();
            //ReadCSVFile();
            // WriteTextToFile();

            SearchCSVFile();

            // CSV_FILL_ARRAY_WITH_DATA();

        }


        static void ReadOneRecordFromFile()
        {
            // set up - make connection
            FileStream fs = new FileStream("messages.txt", FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);

            // to read the first line in file

            string lineIn = sr.ReadLine();

            Console.WriteLine(lineIn);



            sr.Close();

        }

        static void ReadManyRecordFromFile()
        {

            try
            {
                FileStream fs = new FileStream("messagesX.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                // to read the first line in file
                string lineIn = sr.ReadLine(); // get first line
                while (lineIn != null)
                {
                    Console.WriteLine(lineIn); // process the line

                    lineIn = sr.ReadLine(); // get next line
                }
                Console.WriteLine("over");
                sr.Close();
            }
            catch (IOException myError)
            {
                Console.WriteLine($"Sorry there is a problem {myError.Message}");
            }

        }

        static void SearchCSVFile()
        {
            // read all data from csv file, write to a report on the console, with the avergae score


            int studScore = 0;
            string studNum = "";
            string studName = "";

            FileStream fs = null;
            StreamReader sr = null;

            string target;
            Console.WriteLine("enter stud number ");
            target = Console.ReadLine();

            bool found = false;

            try
            {
                fs = new FileStream("students.txt", FileMode.Open, FileAccess.Read); ;
                sr = new StreamReader(fs);


                // to read the first line in file
                string recordIn = sr.ReadLine();

                string[] fields = null;// new string[3]; // use this array to store chopped up line from file

                int sum = 0;
                int count = 0;


                while (recordIn != null && found == false)
                {
                    fields = recordIn.Split(','); // split where there is a comma
                                                  //Console.WriteLine(fields.Length);
                    if (fields.Length == 3)  // check that there are 3 fields
                    {

                        studNum = fields[0];
                        studName = fields[1];
                        studScore = int.Parse(fields[2]);

                        if (studNum == target)
                        {
                            Console.WriteLine($"{studNum,-15}{studName,-15}{studScore,-15}");
                            found = true;
                        }



                    }



                    recordIn = sr.ReadLine(); // read next record
                } // end loop - at the eof

                if (found == false)
                    Console.WriteLine("no match found");



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

        static void ReadCSVFile()
        {
            // read all data from csv file, write to a report on the console, with the avergae score


            int studScore = 0;
            string studNum = "";
            string studName = "";

            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream("students.txt", FileMode.Open, FileAccess.Read); ;
                sr = new StreamReader(fs);


                // to read the first line in file
                string recordIn = sr.ReadLine();

                string[] fields = null;// new string[3]; // use this array to store chopped up line from file

                int sum = 0;
                int count = 0;

                Console.WriteLine($"{"studNum",-15}{"studName",-15}{"studScore",-15}");
                while (recordIn != null)
                {
                    fields = recordIn.Split(','); // split where there is a comma
                                                  //Console.WriteLine(fields.Length);
                    if (fields.Length == 3)  // check that there are 3 fields
                    {

                        studNum = fields[0];
                        studName = fields[1];

                        // for the score field in student file you will have to do some work
                        // to pick out the score
                        studScore = int.Parse(fields[2]);


                        sum += studScore; // must convert to a number if doinf arithmetic

                        count++;

                        // convert score to grade

                        Console.WriteLine($"{studNum,-15}{studName,-15}{studScore,-15}");
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

        //        try
        //{
        //    using (StreamReader sr = new StreamReader(filePath))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string[] parts = line.Split(',');



        static void WriteTextToFile()
        {
            FileStream fs = new FileStream("messages2.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);


            sw.WriteLine("Hello, its monday");

            sw.WriteLine("I am at my favourite class");

            sw.WriteLine("With the best lecturer");

            sw.Close();

        }

        static void CSV_FILL_ARRAY_WITH_DATA()
        {
            string filePath = "students.txt";

            // Initialise arrays for the 5 known topics


            int totalScores = 0;
            int totalStudents = 0;
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine($"{"number",-15}{"Name",-15}{"Score",-15}");

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length == 3) // check num of fields/parts
                    {
                        string topic = parts[2];
                        int score = int.Parse(parts[2]);
                        totalScores += score;
                        totalStudents++;

                        Console.WriteLine($"{parts[0],-15}{parts[1],-15}{parts[2],-15}");

                    }
                }
                int overallAverage;
                // Calculate and print overall totals
                if (totalStudents > 0)
                    overallAverage = totalScores / totalStudents;
                else
                    overallAverage = 0;

                Console.WriteLine($"\nOverall Totals\t{totalStudents}\t\t\t{overallAverage}");
                // Printing the report




            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The file was not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: An I/O error occurred while reading the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }

        static void ReadCSVFile_OOP()                       //Class version
        {
            // read all data from csv file
            // create an array of student objects
            // print out the name of each student

            Student[] myStudents = new Student[10]; // assuming ten students, must be big enought to hold all records
            try
            {
                FileStream fs = new FileStream("students.txt", FileMode.Open, FileAccess.Read); ;
                StreamReader sr = new StreamReader(fs);


                // to read the first line in file
                string recordIn = sr.ReadLine();

                string[] fields = null;// new string[3]; // use this array to store chopped up line from file

                int sum = 0;
                int count = 0;

                while (recordIn != null)
                {
                    fields = recordIn.Split(','); // split where there is a comma
                                                  //Console.WriteLine(fields.Length);
                    if (fields.Length == 3)
                    {
                        myStudents[count] = new Student();
                        myStudents[count].StudNum = fields[0];
                        myStudents[count].StudName = fields[1];

                        // for the age field in student file you will have to do some work
                        // to pick out the age
                        myStudents[count].Score = int.Parse(fields[2]);


                        sum += int.Parse(fields[2]); // must convert to a number if doinf arithmetic

                        count++;
                    }
                    recordIn = sr.ReadLine(); // read next record
                }

                int avg = sum / count;
                Console.WriteLine("Average score = {0}", avg);
                sr.Close();

                // print out all students

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(myStudents[i].StudName);
                }

            }

            catch (IOException myError)
            {
                Console.WriteLine(myError.Message);

            }
            catch (Exception myError) // general exception which will be used if not exact match found
            {
                Console.WriteLine("there was a problem");
            }


        }
    }
}
