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

        private void Form1_Load(object sender, EventArgs e)
        {




        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            this.Hide();
            form.Show();
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Manufacturer!=NULL AND Manufacturer like '%Arduino'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                var portList = portnames.Select(n => portnames.SingleOrDefault(s => n.Contains(s))).ToList();
                var tmp = string.Join(",", ports.ToArray());
                foreach (string n in portnames)
                {
                    if (tmp.Contains(n))
                    {
                        comboBox1.Items.Add(n);
                        
                        serialPort1.PortName = n;
                    }
                }
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
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