using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Logger
{
    class fileAccess
    {
        public bool doesDirectoryExist(string ip)
        {
            string alpha = ip;
            string alphaDirectory = @"\\" + alpha + "\\Cinemassive\\SystemManager\\Logs\\CineNetSystemManagement";

            try
            {
                bool returnValue;

                returnValue = new System.IO.DirectoryInfo(alphaDirectory).Exists;

                if (returnValue)
                    MessageBox.Show("Directory Exist");

                if (!returnValue)
                    MessageBox.Show("Directory does NOT EXIST");

                Console.WriteLine(returnValue);

                return returnValue;

            }
            catch (Exception) { }

            return false;
        }
    }
}
