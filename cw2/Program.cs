using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using cw2.Models;

namespace cw2
{
    class Program
    {
        private static string pathForExceptions = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\log.txt";

        static void Main(string[] args)
        {

            string pathForData = @"C:\Users\Алиса\Desktop\cw2\cw2\Data\dane.csv";
            string pathForResultXML = @"C: \Users\Алиса\Desktop\cw2\cw2\Data\result.xml";
            string format = "xml";


            Console.WriteLine("Please enter the path of: \n-source file,\n-result file, \n-format of data;");

          /*  string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length == 3)
            {

                if (new FileInfo(@data[0]).Exists)
                {

                    if (new FileInfo(@data[0]).Extension.Contains("csv"))
                    {

                        ThrowException($"The file {data[0]} has incorrect extension!!!");
                        data[0] = pathForData;
                    }

                }
                else
                {
                    ThrowException($"The file {data[0]} does not exist!!!");
                    data[0] = pathForData;

                }

                if (!new FileInfo(@data[1]).Exists)
                {

                    ThrowException($"The file {data[1]} does not exist!!!");
                    data[1] = pathForResultXML;

                }

            }
            else
            {

                ThrowException("The number of arguments is incorrect!!!");
                data[0] = pathForData;
                data[1] = pathForResultXML;
                data[2] = format;
            }


            //Wczytywanie  z csv
            ReadFromFile(@data[0]);
            */

            FileStream writer = new FileStream(@"C:\Users\Алиса\Desktop\cw2\cw2\Data\data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            var list = new List<Student>
            {
                new Student
                {
                    Imie = "Jana",
                    Nazwisko = "Kowalski"
                }
            };
            serializer.Serialize(writer, list);












        }



        static async void ThrowException(string text)
        {
            try
            {
                using StreamWriter sw = new StreamWriter(pathForExceptions, false, System.Text.Encoding.Default);
                await sw.WriteLineAsync(text);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadFromFile(string pathForData)
        {
            var fi = new FileInfo(pathForData);

            using var stream = new StreamReader(fi.OpenRead());
            string line = null;
            int counter = 0;
            while ((line = stream.ReadLine()) != null)
            {
                counter++;
                Console.WriteLine(counter);
                string[] kolumny = line.Split(',');
                if (kolumny.Length != 9)
                {
                    ThrowException("Trhe wrong number of parametrs:\n" + line);
                }
                else
                {
                    Console.WriteLine(line + "\n");
                }

            }

        }
    }
}
