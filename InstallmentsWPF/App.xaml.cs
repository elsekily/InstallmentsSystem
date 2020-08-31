using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InstallmentsWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ProcessStartInfo process;
        public App()
        {
            Process.Start(@"D:\Work\Yaseen\Program\InstallmentsSystem.exe");
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            var p = Process.GetProcessesByName("InstallmentsSystem.exe");
            foreach (var item in p)
            {
                item.Kill();
            }

        }
    }
}
