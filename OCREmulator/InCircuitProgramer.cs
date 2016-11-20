using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerialProgrammer;

namespace OCREmulator
{
    public partial class InCircuitProgramer : Form
    {
        public SerialProgrammer.SerialProgrammer program1 = new SerialProgrammer.SerialProgrammer();
        public InCircuitProgramer()
        {

            InitializeComponent();
            string[] SerialPortEnums = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in SerialPortEnums) comboBox_ComPorts.Items.Add(s);
            //program1.serialPort1 = serialPort1;
            //for(int i=0; i<comboBox_ComPorts.Items.Count;i++)
            //{
              //  comboBox_ComPorts.SelectedIndex = i;
               // if (TestSerialReady()) break;
            //}


        }
        public void Setup()
        {
            string s = "";
            program1.serialPort1 = serialPort1;
            serialPort1.BaudRate = 9600;
            //serialPort1.BaudRate = 19200;   does work at this speed
            for (int i = 0; i < comboBox_ComPorts.Items.Count; i++)
            {
                comboBox_ComPorts.SelectedIndex = i;
                if (TestSerialReady())
                {
                    textBox1.Text = "Com Port "+comboBox_ComPorts.Items[i].ToString() +" responded";
                    break;
                }
                //if (!program1.GenerateMC(ref s,false))
                {
                    textBox1.Text = s;
                }
            }
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            textBox1.Text = program1.SendMessage("@@@@" + textBox_send.Text);
        }
        private void button_uploadHex_Click(object sender, EventArgs e)
        {
            textBox_ProgramStatus.Text = "Starting Program sequence"; Update();
            progressBar1.Value = 0;
            if (program1.ProgramPIC(UpdateProgress)) textBox_ProgramStatus.Text = "Programming successful";
            else
            {
                textBox1.Text = textBox_ProgramStatus.Text;
                textBox_ProgramStatus.Text = "Programming Failed";
            }
        }



        private bool TestSerialReady()
        {

            if (program1.SendMessage("@@@@Z").Contains("Ready")) return true;
            return false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = program1.SendMessage("@@@@Z") + Environment.NewLine;
            if (!textBox1.Text.Contains("Ready"))
            {//trt again
                textBox1.Text = program1.SendMessage("@@@@Z") + Environment.NewLine;
                if (!textBox1.Text.Contains("Ready"))
                {
                    MessageBox.Show("Unable to communicate with PIC. Check the serial connection is in place and reset the PIC and try again."); return;
                }
            }

            button_uploadHex.Enabled = true;
            button_send.Enabled = true;
            button_Start.Enabled = true;

        }
        public void UpdateProgress(int max, int val, string text)
        {
            progressBar1.Maximum = max; progressBar1.Value = val;
            textBox_ProgramStatus.Text = text;
            Application.DoEvents();
        }
        private void InCircuitProgramer_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }
        private void button_Start_Click(object sender, EventArgs e)
        {
            //decide if we have to wait for breaks..... and if the PIC version is high enough
            if (program1.CodeHasBreaks())
            {
                string s = program1.SendMessage("@@@@V");  //response is Version 1.x
                                                           //PIC version needs to be >1.3














































































































































                s = s.Substring(8);
                double v = System.Convert.ToDouble(s);
                if (v < 1.3)
                {
                    MessageBox.Show("Code has Breaks, but PIC firmware version is <1.3 and needs to be upgraded to run break code","Error");
                    return;
                }
                BreakWindow b1 = new BreakWindow();
                b1.program1 = program1;
                b1.ShowDialog();
            }
            else
            {
                string s = program1.SendMessage("@@@@J0500");
            }
            
        }
        private void comboBox_ComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.PortName = comboBox_ComPorts.SelectedItem.ToString();
            serialPort1.Open();
        }
    }
}