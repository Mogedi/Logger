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

        //static int count = 0;
        public void Main(string filePath, string localDirectory)
        {
            //filePath = "C:\\Users\\mohamud.gedi\\Desktop\\Servers.txt";
            //List<string> read = File.ReadAllLines(filePath).ToList();

            //Console.WriteLine(read[0]);

            string localFilePath = copy(filePath, localDirectory);

            read(localFilePath);

        }

        public void read(string localFilePath)
        {
            List<string> read = new List<string>();

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(localFilePath);
            while ((line = file.ReadLine()) != null)
            {
                read.Add(line);
                counter++;
            }

            file.Close();

            Console.WriteLine(read[0]);
        }

        public string copy(string filePath, string localDirectory)
        {
            string fileName = filePath.Split('\\').Last();
            string pathToCopyFileOverTo = localDirectory + fileName;

            File.Copy(filePath, pathToCopyFileOverTo, true);

            return pathToCopyFileOverTo;
        }
    }
}
