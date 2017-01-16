using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    class logAnalysisDatabase
    {
        public void Main(string[] logDataAnalysis, string titleOfLocalLogFile, string localDirectory)
        {
            string pathToLogDataFile = createPathToLogDataFile(localDirectory, titleOfLocalLogFile);

            createAndWriteToLogDataFile(pathToLogDataFile, logDataAnalysis);

            Console.WriteLine(pathToLogDataFile);
        }

        public string createPathToLogDataFile(string localDirectory, string titleOfLocalLogFile)
        {
            string pathToLogDataFile = localDirectory +"LOG_DATA.txt";

            return pathToLogDataFile;
        }

        public void createAndWriteToLogDataFile(string pathToLogDataFile, string[] logDataAnalysis)
        {
            File.AppendAllLines(pathToLogDataFile, logDataAnalysis);
        }

    }
}
