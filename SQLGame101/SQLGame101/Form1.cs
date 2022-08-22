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