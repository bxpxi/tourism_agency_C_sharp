using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network.client;
using UI;

namespace Clientt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            var server = new ServiceObjectProxy("127.0.0.1", 15000);
            server.ExceptionThrown += (e) => MessageBox.Show(e.InnerException.Message, "Server Error");

            Application.Run(new FlightsWindow(server));
        }
    }
}