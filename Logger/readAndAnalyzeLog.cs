using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    class readAndAnalyzeLog
    {

        static int count = 0;
        public void Main(string filePath)
        {
            //filePath = "C:\\Users\\mohamud.gedi\\Desktop\\Servers.txt";
            //List<string> read = File.ReadAllLines(filePath).ToList();

            //Console.WriteLine(read[0]);

            read(filePath);

        }

        public void read(string filePath)
        {
            File.Copy(filePath, "C:\\Users\\mohamud.gedi\\Desktop\\TEST" + count + ".txt", true);
            //List<string> read = new List<string>();

            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.
            //StreamReader file = new StreamReader(filePath);
            //while ((line = file.ReadLine()) != null)
            //{
            //    read.Add(line);
            //    counter++;
            //}

            //file.Close();

            //Console.WriteLine(read[0]);

            count++;
        }
    }
}
