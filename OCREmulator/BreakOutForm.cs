using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCREmulator
{
    public partial class BreakOutForm : Form
    {
        public SerialProgrammer.SerialProgrammer program1 = new SerialProgrammer.SerialProgrammer();
        public BreakOutForm()
        {
            InitializeComponent();
            program1.serialPort1 = serialPort1;
            serialPort1.BaudRate = 9600;
            string[] SerialPortEnums = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in SerialPortEnums)
            {
                serialPort1.Close();
                serialPort1.PortName = s;
                serialPort1.Open();
                if (TestSerialReady())
                {
                    break;
                }
            }
            timer1.Enabled = false;

        }

        private bool TestSerialReady()
        {

            if (program1.SendMessage("@@@@Z").Contains("Ready")) return true;
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// so send to the device??
            /// if Matches string release
            /// 
            string s1 = textBox1.Text;
            if (s1 == "alpha")
            {
                string s = program1.SendMessage("@@@@Z") + Environment.NewLine;
                if (!s.Contains("Ready"))
                {//try again
                    s = program1.SendMessage("@@@@Z") + Environment.NewLine;
                    if (!s.Contains("Ready"))
                    {
                        MessageBox.Show("Unable to communicate with PIC. Check the serial connection is in place and reset the PIC and try again."); return;
                    }
                }
                //so now send message
                s = program1.SendMessage("@@@@Y");
                textBox2.Text = "Success!!!";
            }
            else
            {
                textBox2.Text = "Wrong Code";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var Sound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav"))
            {
                Sound.Play(); // can also use soundPlayer.PlaySync()
            }
        }
    }
}
