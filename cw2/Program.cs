using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
       

        static void Main(string[] args)
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "Data\\dane.csv");

           // string pathOfExeptionFile = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\dane.csv";
            Console.WriteLine("Please enter the path of: \n-source file,\n-result file, \n-format of data;");
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(data.Length);

           // string path = @"Data\dane.csv";
            Console.WriteLine("Hello World");

            //Wczytywanie 
            var fi = new FileInfo(path);
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
        static void Converter(string _scvData = "data.csv", string _wynik = "result.xml", string format = "xml")
        {

        }
    }
}
