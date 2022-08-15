using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SQLGame101
{

    public partial class Form1 : Form
    {
        delegate void serialCallback(string val);

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    label1.Text = "start read";
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label1.Text = "stoped";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string recvtext = serialPort1.ReadLine();
            setText(recvtext);
        }
        private void setText(string val)
        {
            if (this.textBox2.InvokeRequired)
            {
                serialCallback scb = new serialCallback(setText);
                this.Invoke(scb, new object[] { val });
            }
            else
            {
                textBox2.Text = val;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                var portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                foreach (string s in portList)
                {
                    listBox1.Items.Add(s);
                }
            }

        }
    }


}
