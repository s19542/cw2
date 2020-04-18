using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        private static string pathForExceptions = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\log.txt";

        static void Main(string[] args)
        {

            string pathForData = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\dane.csv";


            Console.WriteLine("Please enter the path of: \n-source file,\n-result file, \n-format of data;");

            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length == 3)
            {

                if (new FileInfo(@data[0]).Exists)
                {

                    if (new FileInfo(@data[0]).Extension.Contains("csv"))
                    {
                      
                        ThrowException($"The file {data[0]} has incorrect extension!!!");
                        data[0] = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\dane.csv";
                    }

                }
                else
                {
                    ThrowException($"The file {data[0]} does not exist!!!");
                    data[0] = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\dane.csv";

                }

                if (!new FileInfo(@data[1]).Exists)
                {
                  
                    ThrowException($"The file {data[1]} does not exist!!!");
                    data[1] = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\result.xml";

                }

            }
            else
            {
              
                ThrowException("The number of arguments is incorrect!!!");
            }


            //Wczytywanie  z csv
            ReadFromFile(@data[0]);
           




        }
        static void Converter(string _scvData = "data.csv", string _wynik = "result.xml", string format = "xml")
        {

        }


        static async void ThrowException(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathForExceptions, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadFromFile(string pathForData)
        { 
            var fi = new FileInfo(pathForData);

            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    Console.WriteLine(line);
                }



            }

        } 
    }
}
