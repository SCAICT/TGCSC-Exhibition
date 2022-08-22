using System;
using System.Management;
using System.Linq;
using System.IO.Ports;
using System.Data;
using System.Windows.Forms;

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
                    serialPort1.PortName = textBox1.Text;
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
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Manufacturer!=NULL AND Manufacturer like 'Arduino%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                //var portList = portnames.Select(n => portnames.SingleOrDefault(s => n.Contains(s))).ToList();
                var tmp = string.Join(",", ports.ToArray());
                foreach (string n in portnames)
                {
                    if (tmp.Contains(n))
                    {
                        listBox1.Items.Add(n);
                        textBox1.Text = n;
                    }
                }
            }



        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
            
        }
    }


}


/**            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%Arduino%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                var portList = ports.Select(n => portnames.FirstOrDefault(s => n.Contains(s))).ToList();
                foreach (string s in portList)
                {
                    if (s != null)
                    {
                        listBox1.Items.Add(s);
                        textBox1.Text = s;
                    }
                }

            }
**/