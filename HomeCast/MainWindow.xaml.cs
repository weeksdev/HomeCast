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
using MahApps.Metro.Controls;

namespace HomeCast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        System.Threading.Thread serverThread;
        SmallServer.Server server;
        private void startBtnClick(object sender, RoutedEventArgs e)
        {
            if (serverThread == null)
            {
                this.startBtn.IsEnabled = false;
                //this.stopBtn.IsEnabled = true;
                if (server == null)
                {
                    server = new SmallServer.Server();

                    server.Prefixes.Add("http://localhost:" + this.portFld.Text + "/");
                }

                serverThread = new System.Threading.Thread(delegate()
                {
                    server.Start();
                });
                serverThread.Start();
            }
            else
            {
                System.Windows.MessageBox.Show("Server is already running...");
            }
        }
    }
}
