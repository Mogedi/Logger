using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Logger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            PingSystem testPing = new PingSystem();
            bool testPingBool = testPing.pingVerification(ipTextBox.Text);

            if (!testPingBool)
                return;

            string localLogDataFile = "C:\\Users\\" + Environment.UserName + "\\Logger\\" + ipTextBox.Text + "\\LOG_DATA.txt";

            if (File.Exists(localLogDataFile))
                File.Delete(localLogDataFile);

            fileAccess file = new fileAccess();

            file.Main(ipTextBox.Text);

            LogInfoRowContainer.Children.Clear();

            List<string> LogData = readLogDataFile(localLogDataFile);

            foreach(string item in LogData)
            {
                LogInfoRowCreator rowInstance = new LogInfoRowCreator(item);
                LogInfoRowContainer.Children.Add(rowInstance);
            }

        }

        private void enterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                logButton_Click(sender, e);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            LogInfoRowContainer.Children.Clear();
            fileAccess clearing = new fileAccess();
            clearing.clearLocalDirectory(ipTextBox.Text);
        }

        public List<string> readLogDataFile(string localLogDataFile)
        {
            

            List<string> read = new List<string>();

            int counter = 0;

            string line;

            if (File.Exists(localLogDataFile))
            {
                StreamReader file = new StreamReader(localLogDataFile);

                while ((line = file.ReadLine()) != null)
                {
                    read.Add(line);
                    counter++;
                }

                file.Close();

                return read;
            }



            return read;

            
        }
    }
}
