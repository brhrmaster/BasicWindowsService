using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Microsoft.Win32;

namespace WindowsServiceTutorial
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service has stopped at " + DateTime.Now);
        }

        public void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
        }

        private void WriteToFile(string message)
        {
            string CURRENT_DIR = AppDomain.CurrentDomain.BaseDirectory;
            string PATH = CURRENT_DIR + "\\Logs";

            string filePath = PATH + "\\ServiceLog_" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
            FileInfo file = new FileInfo(filePath);
            if (!Directory.Exists(PATH))
            {
                file.Directory.Create();
            }

            if (file.Exists)
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
