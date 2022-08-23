
namespace SQLGame101
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ComList = new System.Windows.Forms.ListBox();
            this.ConnectionGroup = new System.Windows.Forms.GroupBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.ComTb = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.TestLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundButton4 = new SQLGame101.RoundButton();
            this.roundButton2 = new SQLGame101.RoundButton();
            this.roundButton3 = new SQLGame101.RoundButton();
            this.button1 = new System.Windows.Forms.Button();
            this.roundButton1 = new SQLGame101.RoundButton();
            this.ConnectionGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(13, 22);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ComList
            // 
            this.ComList.FormattingEnabled = true;
            this.ComList.ItemHeight = 12;
            this.ComList.Location = new System.Drawing.Point(6, 21);
            this.ComList.Name = "ComList";
            this.ComList.Size = new System.Drawing.Size(254, 256);
            this.ComList.TabIndex = 3;
            // 
            // ConnectionGroup
            // 
            this.ConnectionGroup.Controls.Add(this.StatusLabel);
            this.ConnectionGroup.Controls.Add(this.DisconnectBtn);
            this.ConnectionGroup.Controls.Add(this.StartBtn);
            this.ConnectionGroup.Controls.Add(this.ComTb);
            this.ConnectionGroup.Controls.Add(this.ComList);
            this.ConnectionGroup.Location = new System.Drawing.Point(13, 51);
            this.ConnectionGroup.Name = "ConnectionGroup";
            this.ConnectionGroup.Size = new System.Drawing.Size(266, 387);
            this.ConnectionGroup.TabIndex = 4;
            this.ConnectionGroup.TabStop = false;
            this.ConnectionGroup.Text = "Connection";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(7, 311);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(32, 12);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Status";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Location = new System.Drawing.Point(7, 358);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(253, 23);
            this.DisconnectBtn.TabIndex = 6;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(7, 329);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(253, 23);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ComTb
            // 
            this.ComTb.Location = new System.Drawing.Point(6, 286);
            this.ComTb.Name = "ComTb";
            this.ComTb.Size = new System.Drawing.Size(253, 22);
            this.ComTb.TabIndex = 4;
            this.ComTb.Text = "COM5";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // TestLabel
            // 
            this.TestLabel.AutoSize = true;
            this.TestLabel.Location = new System.Drawing.Point(285, 420);
            this.TestLabel.Name = "TestLabel";
            this.TestLabel.Size = new System.Drawing.Size(32, 12);
            this.TestLabel.TabIndex = 5;
            this.TestLabel.Text = "TEST";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roundButton4);
            this.panel1.Controls.Add(this.roundButton2);
            this.panel1.Controls.Add(this.roundButton3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 18);
            this.panel1.TabIndex = 6;
            // 
            // roundButton4
            // 
            this.roundButton4.BackColor = System.Drawing.Color.Red;
            this.roundButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton4.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.roundButton4.ForeColor = System.Drawing.Color.Brown;
            this.roundButton4.Location = new System.Drawing.Point(0, 3);
            this.roundButton4.Name = "roundButton4";
            this.roundButton4.Size = new System.Drawing.Size(13, 13);
            this.roundButton4.TabIndex = 10;
            this.roundButton4.UseVisualStyleBackColor = false;
            this.roundButton4.Click += new System.EventHandler(this.roundButton4_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.Yellow;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.roundButton2.Location = new System.Drawing.Point(19, 3);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(13, 13);
            this.roundButton2.TabIndex = 9;
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // roundButton3
            // 
            this.roundButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.roundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton3.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.roundButton3.Location = new System.Drawing.Point(38, 3);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.Size = new System.Drawing.Size(13, 13);
            this.roundButton3.TabIndex = 10;
            this.roundButton3.UseVisualStyleBackColor = false;
            this.roundButton3.Click += new System.EventHandler(this.roundButton3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // roundButton1
            // 
            this.roundButton1.Location = new System.Drawing.Point(421, 409);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(24, 23);
            this.roundButton1.TabIndex = 8;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TestLabel);
            this.Controls.Add(this.ConnectionGroup);
            this.Controls.Add(this.BackBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ConnectionGroup.ResumeLayout(false);
            this.ConnectionGroup.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.ListBox ComList;
        private System.Windows.Forms.GroupBox ConnectionGroup;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox ComTb;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label TestLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private RoundButton roundButton1;
        private RoundButton roundButton2;
        private RoundButton roundButton4;
        private RoundButton roundButton3;
    }
}