namespace OCREmulator
{
    partial class InCircuitProgramer
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.button_uploadHex = new System.Windows.Forms.Button();
            this.TextBox_Source = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button_initialise = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_uploadBreaks = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_continue = new System.Windows.Forms.Button();
            this.comboBox_ComPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_S7 = new System.Windows.Forms.TextBox();
            this.textBox_Z = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_S6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_S5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_S4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_S3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_S2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_S1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_S0 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_ProgramStatus = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DiscardNull = true;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(13, 405);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 53);
            this.textBox1.TabIndex = 0;
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(13, 359);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 5;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(94, 360);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(177, 22);
            this.textBox_send.TabIndex = 6;
            // 
            // button_uploadHex
            // 
            this.button_uploadHex.Enabled = false;
            this.button_uploadHex.Location = new System.Drawing.Point(20, 30);
            this.button_uploadHex.Name = "button_uploadHex";
            this.button_uploadHex.Size = new System.Drawing.Size(84, 58);
            this.button_uploadHex.TabIndex = 7;
            this.button_uploadHex.Text = "Program Micro";
            this.button_uploadHex.UseVisualStyleBackColor = true;
            this.button_uploadHex.Click += new System.EventHandler(this.button_uploadHex_Click);
            // 
            // TextBox_Source
            // 
            this.TextBox_Source.Location = new System.Drawing.Point(6, 26);
            this.TextBox_Source.Multiline = true;
            this.TextBox_Source.Name = "TextBox_Source";
            this.TextBox_Source.ReadOnly = true;
            this.TextBox_Source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Source.Size = new System.Drawing.Size(258, 330);
            this.TextBox_Source.TabIndex = 8;
            this.TextBox_Source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_Source_MouseClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(92, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 17);
            this.label19.TabIndex = 48;
            this.label19.Text = "Source Code";
            // 
            // button_initialise
            // 
            this.button_initialise.Location = new System.Drawing.Point(199, 28);
            this.button_initialise.Name = "button_initialise";
            this.button_initialise.Size = new System.Drawing.Size(72, 25);
            this.button_initialise.TabIndex = 49;
            this.button_initialise.Text = "Initialize";
            this.button_initialise.UseVisualStyleBackColor = true;
            this.button_initialise.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(293, 23);
            this.progressBar1.TabIndex = 50;
            // 
            // button_uploadBreaks
            // 
            this.button_uploadBreaks.Enabled = false;
            this.button_uploadBreaks.Location = new System.Drawing.Point(229, 29);
            this.button_uploadBreaks.Name = "button_uploadBreaks";
            this.button_uploadBreaks.Size = new System.Drawing.Size(84, 59);
            this.button_uploadBreaks.TabIndex = 51;
            this.button_uploadBreaks.Text = "Load Break Point";
            this.button_uploadBreaks.UseVisualStyleBackColor = true;
            this.button_uploadBreaks.Click += new System.EventHandler(this.button_uploadBreaks_Click);
            // 
            // button_Start
            // 
            this.button_Start.Enabled = false;
            this.button_Start.Location = new System.Drawing.Point(124, 30);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(84, 59);
            this.button_Start.TabIndex = 52;
            this.button_Start.Text = "Run from Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_continue
            // 
            this.button_continue.Enabled = false;
            this.button_continue.Location = new System.Drawing.Point(15, 169);
            this.button_continue.Name = "button_continue";
            this.button_continue.Size = new System.Drawing.Size(84, 60);
            this.button_continue.TabIndex = 53;
            this.button_continue.Text = "Continue from Break";
            this.button_continue.UseVisualStyleBackColor = true;
            this.button_continue.Click += new System.EventHandler(this.button_continue_Click);
            // 
            // comboBox_ComPorts
            // 
            this.comboBox_ComPorts.FormattingEnabled = true;
            this.comboBox_ComPorts.Location = new System.Drawing.Point(83, 29);
            this.comboBox_ComPorts.Name = "comboBox_ComPorts";
            this.comboBox_ComPorts.Size = new System.Drawing.Size(88, 24);
            this.comboBox_ComPorts.TabIndex = 54;
            this.comboBox_ComPorts.SelectedIndexChanged += new System.EventHandler(this.comboBox_ComPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Serial Port";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_ComPorts);
            this.panel1.Controls.Add(this.button_initialise);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button_send);
            this.panel1.Controls.Add(this.textBox_send);
            this.panel1.Location = new System.Drawing.Point(22, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 465);
            this.panel1.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Status Replies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Serial Interface";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Test Message";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.TextBox_Source);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Location = new System.Drawing.Point(342, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 465);
            this.panel2.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.textBox_ProgramStatus);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.button_uploadHex);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button_Start);
            this.panel3.Controls.Add(this.button_uploadBreaks);
            this.panel3.Location = new System.Drawing.Point(632, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 465);
            this.panel3.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "MicroProcessor Control";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(215, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 72;
            this.label9.Text = "Zflag";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 70;
            this.label8.Text = "S7";
            // 
            // textBox_S7
            // 
            this.textBox_S7.Location = new System.Drawing.Point(153, 132);
            this.textBox_S7.Name = "textBox_S7";
            this.textBox_S7.Size = new System.Drawing.Size(45, 22);
            this.textBox_S7.TabIndex = 69;
            this.textBox_S7.Text = "0";
            // 
            // textBox_Z
            // 
            this.textBox_Z.Location = new System.Drawing.Point(265, 52);
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.Size = new System.Drawing.Size(26, 22);
            this.textBox_Z.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 68;
            this.label7.Text = "S6";
            // 
            // textBox_S6
            // 
            this.textBox_S6.Location = new System.Drawing.Point(154, 105);
            this.textBox_S6.Name = "textBox_S6";
            this.textBox_S6.Size = new System.Drawing.Size(45, 22);
            this.textBox_S6.TabIndex = 67;
            this.textBox_S6.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 66;
            this.label6.Text = "S5";
            // 
            // textBox_S5
            // 
            this.textBox_S5.Location = new System.Drawing.Point(153, 75);
            this.textBox_S5.Name = "textBox_S5";
            this.textBox_S5.Size = new System.Drawing.Size(45, 22);
            this.textBox_S5.TabIndex = 65;
            this.textBox_S5.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(113, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 64;
            this.label10.Text = "S4";
            // 
            // textBox_S4
            // 
            this.textBox_S4.Location = new System.Drawing.Point(154, 49);
            this.textBox_S4.Name = "textBox_S4";
            this.textBox_S4.Size = new System.Drawing.Size(45, 22);
            this.textBox_S4.TabIndex = 63;
            this.textBox_S4.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 62;
            this.label11.Text = "S3";
            // 
            // textBox_S3
            // 
            this.textBox_S3.Location = new System.Drawing.Point(41, 132);
            this.textBox_S3.Name = "textBox_S3";
            this.textBox_S3.Size = new System.Drawing.Size(45, 22);
            this.textBox_S3.TabIndex = 61;
            this.textBox_S3.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = "S2";
            // 
            // textBox_S2
            // 
            this.textBox_S2.Location = new System.Drawing.Point(41, 105);
            this.textBox_S2.Name = "textBox_S2";
            this.textBox_S2.Size = new System.Drawing.Size(45, 22);
            this.textBox_S2.TabIndex = 59;
            this.textBox_S2.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 17);
            this.label13.TabIndex = 58;
            this.label13.Text = "S1";
            // 
            // textBox_S1
            // 
            this.textBox_S1.Location = new System.Drawing.Point(41, 77);
            this.textBox_S1.Name = "textBox_S1";
            this.textBox_S1.Size = new System.Drawing.Size(45, 22);
            this.textBox_S1.TabIndex = 57;
            this.textBox_S1.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 17);
            this.label14.TabIndex = 56;
            this.label14.Text = "S0";
            // 
            // textBox_S0
            // 
            this.textBox_S0.Location = new System.Drawing.Point(41, 49);
            this.textBox_S0.Name = "textBox_S0";
            this.textBox_S0.Size = new System.Drawing.Size(45, 22);
            this.textBox_S0.TabIndex = 55;
            this.textBox_S0.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 17);
            this.label15.TabIndex = 73;
            this.label15.Text = "At Break Point";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 374);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(258, 84);
            this.textBox2.TabIndex = 59;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.textBox_S5);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.textBox_S0);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.button_continue);
            this.panel4.Controls.Add(this.textBox_S1);
            this.panel4.Controls.Add(this.textBox_S7);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.textBox_Z);
            this.panel4.Controls.Add(this.textBox_S2);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.textBox_S6);
            this.panel4.Controls.Add(this.textBox_S3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.textBox_S4);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(20, 198);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(303, 249);
            this.panel4.TabIndex = 59;
            // 
            // textBox_ProgramStatus
            // 
            this.textBox_ProgramStatus.Location = new System.Drawing.Point(20, 124);
            this.textBox_ProgramStatus.Name = "textBox_ProgramStatus";
            this.textBox_ProgramStatus.Size = new System.Drawing.Size(293, 22);
            this.textBox_ProgramStatus.TabIndex = 60;
            // 
            // InCircuitProgramer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 529);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "InCircuitProgramer";
            this.Text = "In Circuit Programer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InCircuitProgramer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Button button_uploadHex;
        private System.Windows.Forms.TextBox TextBox_Source;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_initialise;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_uploadBreaks;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_continue;
        private System.Windows.Forms.ComboBox comboBox_ComPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_S7;
        private System.Windows.Forms.TextBox textBox_Z;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_S6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_S5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_S4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_S3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_S2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_S1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_S0;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_ProgramStatus;
    }
}