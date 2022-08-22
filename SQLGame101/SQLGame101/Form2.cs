using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;

namespace SQLGame101
{
    delegate void serialCallback(string val);
    public partial class Form2 : Form
    {
        bool kkr;
        public Form2()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
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
                        ComList.Items.Add(n);
                        ComTb.Text = n;
                    }
                }
            }
            kkr = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = ComTb.Text;
                    serialPort1.Open();
                    StatusLabel.Text = "start read";
                    StartBtn.Enabled = false;
                    DisconnectBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
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
            StatusLabel.Text = "stoped";
            StartBtn.Enabled = true;
            DisconnectBtn.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string recvtext = serialPort1.ReadLine();
            setText(recvtext);
        }
        private void setText(string val)
        {
            if (this.TestLabel.InvokeRequired)
            {
                serialCallback scb = new serialCallback(setText);
                this.Invoke(scb, new object[] { val });
            }
            else
            {
                var dataArr = val.Split(",".ToCharArray());
                TestLabel.Text = val;
                for(int i = 0; i < dataArr.Length; i ++)
                {
                    var label = new Label();
                    var data = dataArr[i];


                    label.AutoSize = false;
                    label.BackColor = System.Drawing.Color.MediumPurple;
                    label.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    label.ForeColor = System.Drawing.Color.Cornsilk;
                    label.Location = new System.Drawing.Point(312, 51 + i * 30);
                    label.Name = $"label{i}";
                    label.Size = new System.Drawing.Size(300, 16);
                    label.TabIndex = 6;
                    label.Text = $"Data{i} : {data}";
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    
                    var find = this.Controls.Find($"label{i}", false).FirstOrDefault();
                    if (find != null)
                    {
                        this.Controls.Remove(find);
                    }
                    this.Controls.Add(label);
                    
                }
            }
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            if(kkr == false)
            {
                this.WindowState = FormWindowState.Maximized;
                kkr = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                kkr = false;
            }
        }
    }
}
