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

            fileAccess doesDirectoryExist = new fileAccess();

            bool directoryExist = doesDirectoryExist.doesDirectoryExist(ipTextBox.Text);

            if (!directoryExist)
                return;

            MessageBox.Show("Yayy");
        }

        private void enterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                logButton_Click(sender, e);
        }
    }
}
