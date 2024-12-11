using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3
{
    public partial class Form1 : Form
    {
        const string FORMAT = "{0,-15}{1,7}{2,20}";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            //Console.WriteLine(FORMAT, "Name", "PID", "Titulo ventana principal"+"\n");
            textBox1.Text = String.Format(FORMAT, "Name", "PID", "Titulo ventana principal\r\n");
            Array.ForEach(processes, (p) =>
            {
                string name = p.ProcessName;
                //string id = p.Id.ToString();
                if (p.ProcessName.Length > 15)
                {
                    name = p.ProcessName.Substring(0, 15)+"...";
                }

                textBox1.Text += String.Format(FORMAT, name, p.Id, p.MainWindowTitle) + "\r\n";
            });

        }
    }
}
