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
        public void Main(string filePath, string localDirectory)
        {
            string localFilePath = copy(filePath, localDirectory);

            List<string> logData = read(localFilePath);

            string tileOfLogFile = titleOfLogFile(filePath);

            Console.WriteLine(tileOfLogFile + " " + countExceptions(logData));

            

        }

        public List<string> read(string localFilePath)
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

            return read;
        }

        public string copy(string filePath, string localDirectory)
        {
            string fileName = titleOfLogFile(filePath);
            string pathToCopyFileOverTo = localDirectory + fileName;

            File.Copy(filePath, pathToCopyFileOverTo, true);

            return pathToCopyFileOverTo;
        }

        public int countExceptions(List<string> localLogFile)
        {
            int count = 0;
            foreach(string item in localLogFile)
            {
                if(item.Contains("EXCEPTION="))
                {
                    count++;
                }
            }

            //Console.WriteLine(count);

            return count;
        }
        
        public string titleOfLogFile(string filePath)
        {
            return filePath.Split('\\').Last();
        } 
    }
}
