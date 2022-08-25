using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.IO;
using System.Web;

namespace GameConsole
{
    delegate void serialCallback(string val);
    public partial class Form1 : Form
    {
        string[] sqlQuerySum = new string[8];
        public Form1()
        {
            InitializeComponent();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

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
                        comboBox1.Items.Add(n);
                                                
                    }
                }
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    StatusLabel.Text = "Start read";
                    start_btn.Enabled = false;
                    stop_btn.Enabled = true;
                    StatusLabel.BackColor = Color.Chartreuse;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
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
            StatusLabel.Text = "Stoped";
            start_btn.Enabled = true;
            stop_btn.Enabled = false;
            StatusLabel.BackColor = Color.LightCoral;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string recvtext = serialPort1.ReadLine();
            setText(recvtext);
        }
        private string detectSyntax(int value)
        {
            if(value>=18 && value <= 29)
            {
                return "SELECT";
            }
            else if(value>=850 && value <= 978)
            {
                return "Users";
            }
            else if (value>=296 && value <= 338)
            {
                return "FROM";
            }
            else if (value>=50 && value <= 68)
            {
                return "WHERE";
            }
            else if (value>= 345 && value <= 408)
            {
                return "`username`";
            }
            else if (value>=420 && value <= 509)
            {
                return "=";
            }
            else if(value>=215 && value <= 279)
            {
                return "'admin'";
            }
            else if(value>=730 && value <= 847)
            {
                return "password";
            }
            return "";

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
                for (int i = 0; i < dataArr.Length; i++)
                {
                    var label = new Label();
                    var data = dataArr[i];


                    label.AutoSize = false;
                    label.BackColor = System.Drawing.Color.MediumPurple;
                    label.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    label.ForeColor = System.Drawing.Color.Cornsilk;
                    label.Location = new System.Drawing.Point(20 + i * 130, 100);
                    label.Name = $"label{i}";
                    label.Size = new System.Drawing.Size(130, 40);
                    label.TabIndex = 6;
                    if(data!=null)
                    {
                        label.Text = $"{detectSyntax(Convert.ToInt32(data))}";
                        //label.Text = $"{data}";
                        sqlQuerySum[i] = detectSyntax(Convert.ToInt32(data));
                    }
                    else
                    {
                        label.Text = $"{i} NaN";
                    }
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

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void make_btn_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = new DataTable();
                string tmp = "";
                for (int i = 0; i < 8; i++)
                {
                    tmp += $"{sqlQuerySum[i]} ";
                }
                textBox1.Text = tmp;
                string apiUrl = "http://sqcs.tw:8020/s/" + HttpUtility.UrlPathEncode(tmp);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                MessageBox.Show(apiUrl);
                // Set some reasonable limits on resources used by this request
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                // Set credentials to use for this request.
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                
                
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Sql Syntax Error!!!!!!!!");
                    return;
                }
                MessageBox.Show("Response stream received.");
                String responseString = readStream.ReadToEnd();

                using (DataTable table = new DataTable())
                {
                    table.Columns.Add("ID", typeof(String));
                    table.Columns.Add("UserName", typeof(String));
                    table.Columns.Add("Password", typeof(String));
                    table.Columns.Add("CreditNumber", typeof(String));


                    foreach(String row in responseString.Split('\n'))
                    {
                        String[] units = row.Split(',');
                        if (units.Length == 4)
                        {
                            table.Rows.Add(units[0], units[1], units[2], units[3]);
                        }
                        
                    }
                    dataGridView1.DataSource = table;
                }
                response.Close();
                readStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        
    }
}

