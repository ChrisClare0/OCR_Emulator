namespace OCREmulator
{
    partial class Form1
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
            this.ProgramText = new System.Windows.Forms.TextBox();
            this.TextBox_Info = new System.Windows.Forms.TextBox();
            this.button_Read = new System.Windows.Forms.Button();
            this.textBox_S0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_S1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_S2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_S3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_S4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_S5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_S6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_S7 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_ExtEmulator = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_analogueInput = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_OutputPort = new System.Windows.Forms.TextBox();
            this.button_Break = new System.Windows.Forms.Button();
            this.AnalogInput = new System.Windows.Forms.TrackBar();
            this.button_Run = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_Q0 = new System.Windows.Forms.CheckBox();
            this.button_Step = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_Q1 = new System.Windows.Forms.CheckBox();
            this.checkBox_Q2 = new System.Windows.Forms.CheckBox();
            this.checkBox_Q3 = new System.Windows.Forms.CheckBox();
            this.checkBox_Q4 = new System.Windows.Forms.CheckBox();
            this.textBox_Z = new System.Windows.Forms.TextBox();
            this.checkBox_Q5 = new System.Windows.Forms.CheckBox();
            this.checkBox_Q6 = new System.Windows.Forms.CheckBox();
            this.checkBox_Q7 = new System.Windows.Forms.CheckBox();
            this.textBox_InputPort = new System.Windows.Forms.TextBox();
            this.checkBox_b0 = new System.Windows.Forms.CheckBox();
            this.checkBox_b1 = new System.Windows.Forms.CheckBox();
            this.checkBox_b2 = new System.Windows.Forms.CheckBox();
            this.checkBox_b3 = new System.Windows.Forms.CheckBox();
            this.checkBox_b4 = new System.Windows.Forms.CheckBox();
            this.checkBox_b5 = new System.Windows.Forms.CheckBox();
            this.checkBox_b6 = new System.Windows.Forms.CheckBox();
            this.checkBox_b7 = new System.Windows.Forms.CheckBox();
            this.button_LoadFile = new System.Windows.Forms.Button();
            this.button_ShowHelp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button_test = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_SaveASM = new System.Windows.Forms.Button();
            this.button_CrossAssemble = new System.Windows.Forms.Button();
            this.textBox_PICOutput = new System.Windows.Forms.TextBox();
            this.listBox_ProcessorType = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogInput)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramText
            // 
            this.ProgramText.AcceptsTab = true;
            this.ProgramText.Location = new System.Drawing.Point(6, 116);
            this.ProgramText.Multiline = true;
            this.ProgramText.Name = "ProgramText";
            this.ProgramText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgramText.Size = new System.Drawing.Size(258, 325);
            this.ProgramText.TabIndex = 0;
            // 
            // TextBox_Info
            // 
            this.TextBox_Info.Location = new System.Drawing.Point(6, 49);
            this.TextBox_Info.Name = "TextBox_Info";
            this.TextBox_Info.Size = new System.Drawing.Size(258, 22);
            this.TextBox_Info.TabIndex = 1;
            // 
            // button_Read
            // 
            this.button_Read.Location = new System.Drawing.Point(6, 80);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(258, 26);
            this.button_Read.TabIndex = 2;
            this.button_Read.Text = "Interpret source code";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // textBox_S0
            // 
            this.textBox_S0.Location = new System.Drawing.Point(42, 77);
            this.textBox_S0.Name = "textBox_S0";
            this.textBox_S0.Size = new System.Drawing.Size(45, 22);
            this.textBox_S0.TabIndex = 3;
            this.textBox_S0.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "S0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "S1";
            // 
            // textBox_S1
            // 
            this.textBox_S1.Location = new System.Drawing.Point(42, 116);
            this.textBox_S1.Name = "textBox_S1";
            this.textBox_S1.Size = new System.Drawing.Size(45, 22);
            this.textBox_S1.TabIndex = 5;
            this.textBox_S1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "S2";
            // 
            // textBox_S2
            // 
            this.textBox_S2.Location = new System.Drawing.Point(42, 155);
            this.textBox_S2.Name = "textBox_S2";
            this.textBox_S2.Size = new System.Drawing.Size(45, 22);
            this.textBox_S2.TabIndex = 7;
            this.textBox_S2.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "S3";
            // 
            // textBox_S3
            // 
            this.textBox_S3.Location = new System.Drawing.Point(42, 194);
            this.textBox_S3.Name = "textBox_S3";
            this.textBox_S3.Size = new System.Drawing.Size(45, 22);
            this.textBox_S3.TabIndex = 9;
            this.textBox_S3.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "S4";
            // 
            // textBox_S4
            // 
            this.textBox_S4.Location = new System.Drawing.Point(182, 77);
            this.textBox_S4.Name = "textBox_S4";
            this.textBox_S4.Size = new System.Drawing.Size(45, 22);
            this.textBox_S4.TabIndex = 11;
            this.textBox_S4.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "S5";
            // 
            // textBox_S5
            // 
            this.textBox_S5.Location = new System.Drawing.Point(182, 116);
            this.textBox_S5.Name = "textBox_S5";
            this.textBox_S5.Size = new System.Drawing.Size(45, 22);
            this.textBox_S5.TabIndex = 13;
            this.textBox_S5.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "S6";
            // 
            // textBox_S6
            // 
            this.textBox_S6.Location = new System.Drawing.Point(182, 155);
            this.textBox_S6.Name = "textBox_S6";
            this.textBox_S6.Size = new System.Drawing.Size(45, 22);
            this.textBox_S6.TabIndex = 15;
            this.textBox_S6.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "S7";
            // 
            // textBox_S7
            // 
            this.textBox_S7.Location = new System.Drawing.Point(182, 194);
            this.textBox_S7.Name = "textBox_S7";
            this.textBox_S7.Size = new System.Drawing.Size(45, 22);
            this.textBox_S7.TabIndex = 17;
            this.textBox_S7.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkBox_ExtEmulator);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBox_analogueInput);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox_OutputPort);
            this.panel1.Controls.Add(this.button_Break);
            this.panel1.Controls.Add(this.AnalogInput);
            this.panel1.Controls.Add(this.button_Run);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.checkBox_Q0);
            this.panel1.Controls.Add(this.button_Step);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.checkBox_Q1);
            this.panel1.Controls.Add(this.checkBox_Q2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.checkBox_Q3);
            this.panel1.Controls.Add(this.textBox_S7);
            this.panel1.Controls.Add(this.checkBox_Q4);
            this.panel1.Controls.Add(this.textBox_Z);
            this.panel1.Controls.Add(this.checkBox_Q5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.checkBox_Q6);
            this.panel1.Controls.Add(this.textBox_S6);
            this.panel1.Controls.Add(this.checkBox_Q7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_S5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_S4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_InputPort);
            this.panel1.Controls.Add(this.textBox_S3);
            this.panel1.Controls.Add(this.checkBox_b0);
            this.panel1.Controls.Add(this.checkBox_b1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox_b2);
            this.panel1.Controls.Add(this.textBox_S2);
            this.panel1.Controls.Add(this.checkBox_b3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox_b4);
            this.panel1.Controls.Add(this.textBox_S1);
            this.panel1.Controls.Add(this.checkBox_b5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox_b6);
            this.panel1.Controls.Add(this.textBox_S0);
            this.panel1.Controls.Add(this.checkBox_b7);
            this.panel1.Location = new System.Drawing.Point(5, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 506);
            this.panel1.TabIndex = 19;
            // 
            // checkBox_ExtEmulator
            // 
            this.checkBox_ExtEmulator.AutoSize = true;
            this.checkBox_ExtEmulator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_ExtEmulator.Location = new System.Drawing.Point(98, 235);
            this.checkBox_ExtEmulator.Name = "checkBox_ExtEmulator";
            this.checkBox_ExtEmulator.Size = new System.Drawing.Size(129, 21);
            this.checkBox_ExtEmulator.TabIndex = 48;
            this.checkBox_ExtEmulator.Text = "Ext Emulator On";
            this.checkBox_ExtEmulator.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 26);
            this.button1.TabIndex = 45;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 17);
            this.label14.TabIndex = 43;
            this.label14.Text = "Software Emulator";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(274, 447);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 42;
            this.label13.Text = "V";
            // 
            // textBox_analogueInput
            // 
            this.textBox_analogueInput.Location = new System.Drawing.Point(244, 444);
            this.textBox_analogueInput.Name = "textBox_analogueInput";
            this.textBox_analogueInput.Size = new System.Drawing.Size(33, 22);
            this.textBox_analogueInput.TabIndex = 45;
            this.textBox_analogueInput.Text = "00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 410);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 17);
            this.label12.TabIndex = 44;
            this.label12.Text = "Analogue Input";
            // 
            // textBox_OutputPort
            // 
            this.textBox_OutputPort.Location = new System.Drawing.Point(244, 377);
            this.textBox_OutputPort.Name = "textBox_OutputPort";
            this.textBox_OutputPort.ReadOnly = true;
            this.textBox_OutputPort.Size = new System.Drawing.Size(33, 22);
            this.textBox_OutputPort.TabIndex = 44;
            this.textBox_OutputPort.Text = "00";
            // 
            // button_Break
            // 
            this.button_Break.Location = new System.Drawing.Point(188, 31);
            this.button_Break.Name = "button_Break";
            this.button_Break.Size = new System.Drawing.Size(55, 26);
            this.button_Break.TabIndex = 42;
            this.button_Break.Text = "Break";
            this.button_Break.UseVisualStyleBackColor = true;
            this.button_Break.Click += new System.EventHandler(this.button_Break_Click);
            // 
            // AnalogInput
            // 
            this.AnalogInput.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AnalogInput.Location = new System.Drawing.Point(14, 444);
            this.AnalogInput.Maximum = 500;
            this.AnalogInput.Name = "AnalogInput";
            this.AnalogInput.Size = new System.Drawing.Size(224, 53);
            this.AnalogInput.TabIndex = 29;
            this.AnalogInput.TickFrequency = 100;
            this.AnalogInput.Scroll += new System.EventHandler(this.AnalogInput_Scroll);
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(135, 31);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(47, 26);
            this.button_Run.TabIndex = 41;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Output Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 42;
            this.label10.Text = "Input Port";
            // 
            // checkBox_Q0
            // 
            this.checkBox_Q0.AutoSize = true;
            this.checkBox_Q0.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q0.Enabled = false;
            this.checkBox_Q0.Location = new System.Drawing.Point(210, 364);
            this.checkBox_Q0.Name = "checkBox_Q0";
            this.checkBox_Q0.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q0.TabIndex = 37;
            this.checkBox_Q0.Text = "q0";
            this.checkBox_Q0.UseVisualStyleBackColor = true;
            // 
            // button_Step
            // 
            this.button_Step.Location = new System.Drawing.Point(79, 31);
            this.button_Step.Name = "button_Step";
            this.button_Step.Size = new System.Drawing.Size(47, 26);
            this.button_Step.TabIndex = 39;
            this.button_Step.Text = "Step";
            this.button_Step.UseVisualStyleBackColor = true;
            this.button_Step.Click += new System.EventHandler(this.button_Step_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "Zflag";
            // 
            // checkBox_Q1
            // 
            this.checkBox_Q1.AutoSize = true;
            this.checkBox_Q1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q1.Enabled = false;
            this.checkBox_Q1.Location = new System.Drawing.Point(182, 364);
            this.checkBox_Q1.Name = "checkBox_Q1";
            this.checkBox_Q1.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q1.TabIndex = 36;
            this.checkBox_Q1.Text = "q1";
            this.checkBox_Q1.UseVisualStyleBackColor = true;
            // 
            // checkBox_Q2
            // 
            this.checkBox_Q2.AutoSize = true;
            this.checkBox_Q2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q2.Enabled = false;
            this.checkBox_Q2.Location = new System.Drawing.Point(154, 364);
            this.checkBox_Q2.Name = "checkBox_Q2";
            this.checkBox_Q2.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q2.TabIndex = 35;
            this.checkBox_Q2.Text = "q2";
            this.checkBox_Q2.UseVisualStyleBackColor = true;
            // 
            // checkBox_Q3
            // 
            this.checkBox_Q3.AutoSize = true;
            this.checkBox_Q3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q3.Enabled = false;
            this.checkBox_Q3.Location = new System.Drawing.Point(126, 364);
            this.checkBox_Q3.Name = "checkBox_Q3";
            this.checkBox_Q3.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q3.TabIndex = 34;
            this.checkBox_Q3.Text = "q3";
            this.checkBox_Q3.UseVisualStyleBackColor = true;
            // 
            // checkBox_Q4
            // 
            this.checkBox_Q4.AutoSize = true;
            this.checkBox_Q4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q4.Enabled = false;
            this.checkBox_Q4.Location = new System.Drawing.Point(98, 364);
            this.checkBox_Q4.Name = "checkBox_Q4";
            this.checkBox_Q4.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q4.TabIndex = 33;
            this.checkBox_Q4.Text = "q4";
            this.checkBox_Q4.UseVisualStyleBackColor = true;
            // 
            // textBox_Z
            // 
            this.textBox_Z.Location = new System.Drawing.Point(61, 233);
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.Size = new System.Drawing.Size(26, 22);
            this.textBox_Z.TabIndex = 38;
            // 
            // checkBox_Q5
            // 
            this.checkBox_Q5.AutoSize = true;
            this.checkBox_Q5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q5.Enabled = false;
            this.checkBox_Q5.Location = new System.Drawing.Point(70, 364);
            this.checkBox_Q5.Name = "checkBox_Q5";
            this.checkBox_Q5.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q5.TabIndex = 32;
            this.checkBox_Q5.Text = "q5";
            this.checkBox_Q5.UseVisualStyleBackColor = true;
            // 
            // checkBox_Q6
            // 
            this.checkBox_Q6.AutoSize = true;
            this.checkBox_Q6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q6.Enabled = false;
            this.checkBox_Q6.Location = new System.Drawing.Point(42, 364);
            this.checkBox_Q6.Name = "checkBox_Q6";
            this.checkBox_Q6.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q6.TabIndex = 31;
            this.checkBox_Q6.Text = "q6";
            this.checkBox_Q6.UseVisualStyleBackColor = true;
            // 
            // checkBox_Q7
            // 
            this.checkBox_Q7.AutoSize = true;
            this.checkBox_Q7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_Q7.Enabled = false;
            this.checkBox_Q7.Location = new System.Drawing.Point(14, 364);
            this.checkBox_Q7.Name = "checkBox_Q7";
            this.checkBox_Q7.Size = new System.Drawing.Size(28, 35);
            this.checkBox_Q7.TabIndex = 30;
            this.checkBox_Q7.Text = "q7";
            this.checkBox_Q7.UseVisualStyleBackColor = true;
            // 
            // textBox_InputPort
            // 
            this.textBox_InputPort.Location = new System.Drawing.Point(244, 303);
            this.textBox_InputPort.MaxLength = 2;
            this.textBox_InputPort.Name = "textBox_InputPort";
            this.textBox_InputPort.Size = new System.Drawing.Size(33, 22);
            this.textBox_InputPort.TabIndex = 28;
            this.textBox_InputPort.Text = "00";
            this.textBox_InputPort.TextChanged += new System.EventHandler(this.textBox_InputPort_TextChanged);
            // 
            // checkBox_b0
            // 
            this.checkBox_b0.AutoSize = true;
            this.checkBox_b0.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b0.Location = new System.Drawing.Point(210, 290);
            this.checkBox_b0.Name = "checkBox_b0";
            this.checkBox_b0.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b0.TabIndex = 27;
            this.checkBox_b0.Text = "b0";
            this.checkBox_b0.UseVisualStyleBackColor = true;
            this.checkBox_b0.CheckedChanged += new System.EventHandler(this.checkBox_b0_CheckedChanged);
            // 
            // checkBox_b1
            // 
            this.checkBox_b1.AutoSize = true;
            this.checkBox_b1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b1.Location = new System.Drawing.Point(182, 290);
            this.checkBox_b1.Name = "checkBox_b1";
            this.checkBox_b1.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b1.TabIndex = 26;
            this.checkBox_b1.Text = "b1";
            this.checkBox_b1.UseVisualStyleBackColor = true;
            this.checkBox_b1.CheckedChanged += new System.EventHandler(this.checkBox_b1_CheckedChanged);
            // 
            // checkBox_b2
            // 
            this.checkBox_b2.AutoSize = true;
            this.checkBox_b2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b2.Location = new System.Drawing.Point(154, 290);
            this.checkBox_b2.Name = "checkBox_b2";
            this.checkBox_b2.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b2.TabIndex = 25;
            this.checkBox_b2.Text = "b2";
            this.checkBox_b2.UseVisualStyleBackColor = true;
            this.checkBox_b2.CheckedChanged += new System.EventHandler(this.checkBox_b2_CheckedChanged);
            // 
            // checkBox_b3
            // 
            this.checkBox_b3.AutoSize = true;
            this.checkBox_b3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b3.Location = new System.Drawing.Point(126, 290);
            this.checkBox_b3.Name = "checkBox_b3";
            this.checkBox_b3.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b3.TabIndex = 24;
            this.checkBox_b3.Text = "b3";
            this.checkBox_b3.UseVisualStyleBackColor = true;
            this.checkBox_b3.CheckedChanged += new System.EventHandler(this.checkBox_b3_CheckedChanged);
            // 
            // checkBox_b4
            // 
            this.checkBox_b4.AutoSize = true;
            this.checkBox_b4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b4.Location = new System.Drawing.Point(98, 290);
            this.checkBox_b4.Name = "checkBox_b4";
            this.checkBox_b4.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b4.TabIndex = 23;
            this.checkBox_b4.Text = "b4";
            this.checkBox_b4.UseVisualStyleBackColor = true;
            this.checkBox_b4.CheckedChanged += new System.EventHandler(this.checkBox_b4_CheckedChanged);
            // 
            // checkBox_b5
            // 
            this.checkBox_b5.AutoSize = true;
            this.checkBox_b5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b5.Location = new System.Drawing.Point(70, 290);
            this.checkBox_b5.Name = "checkBox_b5";
            this.checkBox_b5.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b5.TabIndex = 22;
            this.checkBox_b5.Text = "b5";
            this.checkBox_b5.UseVisualStyleBackColor = true;
            this.checkBox_b5.CheckedChanged += new System.EventHandler(this.checkBox_b5_CheckedChanged);
            // 
            // checkBox_b6
            // 
            this.checkBox_b6.AutoSize = true;
            this.checkBox_b6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b6.Location = new System.Drawing.Point(42, 290);
            this.checkBox_b6.Name = "checkBox_b6";
            this.checkBox_b6.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b6.TabIndex = 21;
            this.checkBox_b6.Text = "b6";
            this.checkBox_b6.UseVisualStyleBackColor = true;
            this.checkBox_b6.CheckedChanged += new System.EventHandler(this.checkBox_b6_CheckedChanged);
            // 
            // checkBox_b7
            // 
            this.checkBox_b7.AutoSize = true;
            this.checkBox_b7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox_b7.Location = new System.Drawing.Point(14, 290);
            this.checkBox_b7.Name = "checkBox_b7";
            this.checkBox_b7.Size = new System.Drawing.Size(28, 35);
            this.checkBox_b7.TabIndex = 20;
            this.checkBox_b7.Text = "b7";
            this.checkBox_b7.UseVisualStyleBackColor = true;
            this.checkBox_b7.CheckedChanged += new System.EventHandler(this.checkBox_b7_CheckedChanged);
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Location = new System.Drawing.Point(6, 447);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(76, 26);
            this.button_LoadFile.TabIndex = 40;
            this.button_LoadFile.Text = "LoadFile";
            this.button_LoadFile.UseVisualStyleBackColor = true;
            this.button_LoadFile.Click += new System.EventHandler(this.button_LoadFile_Click);
            // 
            // button_ShowHelp
            // 
            this.button_ShowHelp.Location = new System.Drawing.Point(97, 447);
            this.button_ShowHelp.Name = "button_ShowHelp";
            this.button_ShowHelp.Size = new System.Drawing.Size(76, 26);
            this.button_ShowHelp.TabIndex = 43;
            this.button_ShowHelp.Text = "Help";
            this.button_ShowHelp.UseVisualStyleBackColor = true;
            this.button_ShowHelp.Click += new System.EventHandler(this.button_ShowHelp_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.ProgramText);
            this.panel2.Controls.Add(this.button_ShowHelp);
            this.panel2.Controls.Add(this.button_Read);
            this.panel2.Controls.Add(this.button_LoadFile);
            this.panel2.Controls.Add(this.TextBox_Info);
            this.panel2.Location = new System.Drawing.Point(323, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 506);
            this.panel2.TabIndex = 44;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(76, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(131, 17);
            this.label19.TabIndex = 47;
            this.label19.Text = "Source Code Editor";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 26);
            this.button2.TabIndex = 45;
            this.button2.Text = "SaveFile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 44;
            this.label15.Text = "Status:";
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(247, 80);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(171, 26);
            this.button_test.TabIndex = 46;
            this.button_test.Text = "In Circuit Programmer";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button_test);
            this.panel3.Controls.Add(this.button_SaveASM);
            this.panel3.Controls.Add(this.button_CrossAssemble);
            this.panel3.Controls.Add(this.textBox_PICOutput);
            this.panel3.Controls.Add(this.listBox_ProcessorType);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(620, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(438, 506);
            this.panel3.TabIndex = 45;
            // 
            // button_SaveASM
            // 
            this.button_SaveASM.Location = new System.Drawing.Point(155, 80);
            this.button_SaveASM.Name = "button_SaveASM";
            this.button_SaveASM.Size = new System.Drawing.Size(76, 26);
            this.button_SaveASM.TabIndex = 46;
            this.button_SaveASM.Text = "SaveFile";
            this.button_SaveASM.UseVisualStyleBackColor = true;
            this.button_SaveASM.Click += new System.EventHandler(this.button_SaveASM_Click);
            // 
            // button_CrossAssemble
            // 
            this.button_CrossAssemble.Location = new System.Drawing.Point(6, 80);
            this.button_CrossAssemble.Name = "button_CrossAssemble";
            this.button_CrossAssemble.Size = new System.Drawing.Size(133, 26);
            this.button_CrossAssemble.TabIndex = 48;
            this.button_CrossAssemble.Text = "Cross Assemble";
            this.button_CrossAssemble.UseVisualStyleBackColor = true;
            this.button_CrossAssemble.Click += new System.EventHandler(this.button_CrossAssemble_Click);
            // 
            // textBox_PICOutput
            // 
            this.textBox_PICOutput.Location = new System.Drawing.Point(3, 116);
            this.textBox_PICOutput.Multiline = true;
            this.textBox_PICOutput.Name = "textBox_PICOutput";
            this.textBox_PICOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_PICOutput.Size = new System.Drawing.Size(428, 325);
            this.textBox_PICOutput.TabIndex = 47;
            // 
            // listBox_ProcessorType
            // 
            this.listBox_ProcessorType.FormattingEnabled = true;
            this.listBox_ProcessorType.ItemHeight = 16;
            this.listBox_ProcessorType.Items.AddRange(new object[] {
            "16F73",
            "16F876"});
            this.listBox_ProcessorType.Location = new System.Drawing.Point(59, 31);
            this.listBox_ProcessorType.Name = "listBox_ProcessorType";
            this.listBox_ProcessorType.Size = new System.Drawing.Size(96, 36);
            this.listBox_ProcessorType.Sorted = true;
            this.listBox_ProcessorType.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 17);
            this.label17.TabIndex = 45;
            this.label17.Text = "Target";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(278, 17);
            this.label16.TabIndex = 44;
            this.label16.Text = "Cross Assembler for MicroChip PIC devices";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 545);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(230, 17);
            this.label18.TabIndex = 46;
            this.label18.Text = "code and errors by CC - June 2012";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(905, 545);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(56, 17);
            this.label_version.TabIndex = 47;
            this.label_version.Text = "Version";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 571);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "DCGS OCR Emulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogInput)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProgramText;
        private System.Windows.Forms.TextBox TextBox_Info;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.TextBox textBox_S0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_S1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_S2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_S3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_S4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_S5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_S6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_S7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_b7;
        private System.Windows.Forms.CheckBox checkBox_b6;
        private System.Windows.Forms.CheckBox checkBox_b5;
        private System.Windows.Forms.CheckBox checkBox_b4;
        private System.Windows.Forms.CheckBox checkBox_b3;
        private System.Windows.Forms.CheckBox checkBox_b2;
        private System.Windows.Forms.CheckBox checkBox_b1;
        private System.Windows.Forms.CheckBox checkBox_b0;
        private System.Windows.Forms.TextBox textBox_InputPort;
        private System.Windows.Forms.TrackBar AnalogInput;
        private System.Windows.Forms.CheckBox checkBox_Q0;
        private System.Windows.Forms.CheckBox checkBox_Q1;
        private System.Windows.Forms.CheckBox checkBox_Q2;
        private System.Windows.Forms.CheckBox checkBox_Q3;
        private System.Windows.Forms.CheckBox checkBox_Q4;
        private System.Windows.Forms.CheckBox checkBox_Q5;
        private System.Windows.Forms.CheckBox checkBox_Q6;
        private System.Windows.Forms.CheckBox checkBox_Q7;
        private System.Windows.Forms.TextBox textBox_Z;
        private System.Windows.Forms.Button button_Step;
        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.TextBox textBox_analogueInput;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_OutputPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Button button_Break;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_ShowHelp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox listBox_ProcessorType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_CrossAssemble;
        private System.Windows.Forms.TextBox textBox_PICOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_ExtEmulator;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_SaveASM;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Label label19;
    }
}

