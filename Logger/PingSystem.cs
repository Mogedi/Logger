using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows;

namespace Logger
{
    class PingSystem
    {
        public bool pingVerification(string ip)
        {
            try
            {
                Ping pinger = new Ping();
                PingReply pingReply = pinger.Send(ip, 500);

                if (pingReply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Pinging works");
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid");
                return false;
            }

            MessageBox.Show("IP not working");
            return false;
        }
    }
}
