using System;
using System.IO;
using System.Linq;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            //string file = "/users/jgrissom/downloads/data.txt";
            string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1")
            {
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                if (!(File.Exists(file)))
                {
                    Console.WriteLine("File does not exist. Go create it first.");
                    Console.WriteLine("Press Enter to Continue: ");
                    Console.ReadKey(false);
                    System.Environment.Exit(0);
                }
                else
                {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] arr = line.Split(',');
                        string[] arr2 = arr[1].Split('|');
                        string[] daysOfWeek = new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Tot", "Avg" };

                        for (int g = 0; g < 1; g++)
                        {
                            if (!arr[0].All(char.IsWhiteSpace))
                            {
                                decimal total = 0;
                                foreach (var item in arr2)
                                {
                                    total += Int32.Parse(item);
                                }
                                decimal avg = 0;
                                avg = total / arr2.Length;
                                string average = avg.ToString("f1");
                                DateTime parsedDate = DateTime.Parse(arr[g]);
                                Console.Write("Week of {0:d}\n", parsedDate.ToString("MMM dd, yyyy"));
                                Console.Write(" {0} {1} {2} {3} {4} {5} {6} {7} {8}\n", daysOfWeek);
                                Console.Write(" {0} {0} {0} {0} {0} {0} {0} {1} {1}\n", "--", "---");
                                Console.Write(" {0,2} {1,2} {2,2} {3,2} {4,2} {5,2} {6,2}", arr2);
                                Console.Write(" {0,3} {1,3}\n\n",total,average);

                            }
                        }
                    }
                }


                Console.WriteLine("Press Enter to Continue: ");
                Console.ReadKey(false);
                System.Environment.Exit(0);


            }
        }
    }
}
