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
    public partial class Form1 : Form  //info de modulos
    {
        const string FORMAT = "{0,-20}{1,7}{2,25}";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            //Console.WriteLine(FORMAT, "Name", "PID", "Titulo ventana principal"+"\n");
            textBox1.Text = String.Format(FORMAT, "Name", "PID", "Titulo App\r\n");
            Array.ForEach(processes, (p) =>
            {
                string name = p.ProcessName;
                //string id = p.Id.ToString();
                if (name.Length > 15)
                {
                    name = p.ProcessName.Substring(0, 15) + "...";
                }
                String tituloVentana = p.MainWindowTitle;
                if (tituloVentana.Length > 15)
                {
                    tituloVentana = p.MainWindowTitle.Substring(0, 15) + "...";
                }


                textBox1.Text += String.Format(FORMAT, name, p.Id, p.MainWindowTitle) + "\r\n";
            });

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {

                Process process = Process.GetProcessById(Convert.ToInt32(txtbName.Text));
                ProcessThreadCollection thread = process.Threads;
                ProcessModuleCollection module = process.Modules;
                textBox1.Text = String.Format("Name: {0}\r\nTitulo ventana pricnipal: {4}\r\nPID: {1}\r\nSubprocesses: {2}\r\nInit: {3}\r\n",
     process.ProcessName, process.Id, process.Threads.Count, process.StartTime, process.MainWindowTitle);


                foreach (ProcessThread t in thread)
                {
                    textBox1.Text += String.Format("Thread ID: {0}\r\nInit: {1}\r\nPriority: {2}\r\nState: {3}",
                     t.Id, t.StartTime.ToShortTimeString(), t.PriorityLevel,
                    t.ThreadState);
                }
                foreach (ProcessModule m in module)
                {
                    textBox1.Text += String.Format("Nombre modulo: {0}\r\n",
                   m.ModuleName);
                }

            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                textBox1.Text = "Acceso denegado";
            }
            catch (System.ArgumentException exc)
            {
                textBox1.Text = exc.Message;
            }
            catch (System.FormatException exc)
            {
                textBox1.Text = exc.Message;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.GetProcessById(Convert.ToInt32(txtbName.Text));
                process.CloseMainWindow();
            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                textBox1.Text = "Acceso denegado";
            }
            catch (System.ArgumentException exc)
            {
                textBox1.Text = exc.Message;
            }
            catch (System.FormatException exc)
            {
                textBox1.Text = exc.Message;
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.GetProcessById(Convert.ToInt32(txtbName.Text));
                process.Kill();
            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                textBox1.Text = "Acceso denegado";
            }
            catch (System.ArgumentException exc)
            {
                textBox1.Text = exc.Message;
            }
            catch (System.FormatException exc)
            {
                textBox1.Text = "No se encuentra el proceso";
            }
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.Start(txtbName.Text);
            }
            catch (System.ComponentModel.Win32Exception exc)
            {
                textBox1.Text = "Acceso denegado";
            }
            catch (System.ArgumentException exc)
            {
                textBox1.Text = exc.Message;
            }
            catch (System.InvalidOperationException exc)
            {
                textBox1.Text = exc.Message;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Process[] process = Process.GetProcesses();
            Array.ForEach(process, (p) =>
            {
                if (p.ProcessName.StartsWith(txtbName.Text.Trim()))
                {
                    textBox1.Text += p.ProcessName + "\r\n";
                }
            });
        }
    }
}
