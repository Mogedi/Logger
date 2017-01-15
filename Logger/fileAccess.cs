using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Logger
{
    class fileAccess
    {

        public void Main(string ip)
        {
            List<string> listOfDirectories = getListOfDirectories(ip);

            createDirectory(ip);


            foreach (string directory in listOfDirectories)
            {
                bool directoryVerification = doesDirectoryExist(directory);

                if (!directoryVerification)
                    return;

                //MessageBox.Show("FileAccess.Main: directory verification passed");

                string filePath = getLatestFileInEachDirectory(ip, directory);

                Console.WriteLine(filePath);

                readAndAnalyzeLog readAnalyze = new readAndAnalyzeLog();

                readAnalyze.Main(filePath);

            }

        }

        public List<string> getListOfDirectories(string ip)
        {
            List<string> alphaDirectory = new List<string>();
            string[] paths = { "\\Cinemassive\\SystemManager\\Logs\\CineNetSystemManagement\\", "\\Cinemassive\\AlphaControlService\\Logs\\AlphaControlService\\" };

            foreach(string item in paths)
            {
                alphaDirectory.Add("\\\\" + ip + item);
            }
            return alphaDirectory;
        }

        public bool doesDirectoryExist(string directory)
        {
            try
            {
                bool returnValue;

                returnValue = new DirectoryInfo(directory).Exists;

                if (returnValue)
                   // MessageBox.Show("FileAccess.doesDirectoryExist: Directory Exist");

                if (!returnValue)
                   // MessageBox.Show("FileAccess.doesDirectoryExist: Directory does NOT EXIST");

                Console.WriteLine(returnValue);

                return returnValue;

            }
            catch (Exception) { }

            return false;
        }

        public string getLatestFileInEachDirectory(string ip, string directory)
        {
            DirectoryInfo alphaDirectory = new DirectoryInfo(directory);
            DirectoryInfo nameOfFileDirectory = alphaDirectory.GetDirectories().OrderByDescending(f => f.LastWriteTime).First();

            string PathToFileDirectory = directory.ToString() + '\\' + nameOfFileDirectory.ToString();

            Console.WriteLine(PathToFileDirectory);

            DirectoryInfo filePath = new DirectoryInfo(PathToFileDirectory);
            FileInfo nameOfFile = filePath.GetFiles().OrderByDescending(f => f.LastWriteTime).First();

            string PathToFile = filePath.ToString() + '\\' + nameOfFile.ToString();

            return PathToFile;
        }

        public void createDirectory(string ip)
        {
            string path = "C:\\Users\\" + Environment.UserName + "\\Logger\\" + ip + "\\";

            bool directoryExist = Directory.Exists(path);

            if (!directoryExist)
            {
                Directory.CreateDirectory(path);
            }
        }

        public void clearDirectory(string ip)
        {
            string path = "C:\\Users\\" + Environment.UserName + "\\Logger\\" + ip + "\\";

            bool directoryExist = Directory.Exists(path);

            if (directoryExist)
            {
                Directory.Delete(path, true);
            }
        }
    }
}
