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
    public partial class Test_Traverser : Form
    {
        public SerialProgrammer.SerialProgrammer program1 = new SerialProgrammer.SerialProgrammer();
        public Test_Traverser()
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
                    textBox1.Text = s;
                    break;
                }
            }

        }
        private bool TestSerialReady()
        {
            byte[] byte1 = new byte[2];
            byte1[0] = 0x70; byte1[1] = 0;//msg to address b'011', cmd,0...b'01110000'
            string s1=serialPort1.ReadExisting();
            serialPort1.Write(byte1, 0, 1);
            string s = program1.WaitMessage();
            if (s!="") return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byte1 = new byte[2];
            byte1[0] = 0x70;byte1[1] = 0;//msg to address b'011', cmd,0...b'01110000'
            int i = (int)numericUpDown1.Value + 7 * 16;

            byte1[0]= (byte) i;
            serialPort1.ReadExisting();
            serialPort1.Write(byte1, 0, 1);
            
            string s = program1.WaitMessage();
            textBox1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] byte1 = new byte[2];
            byte1[0] = 0x70; byte1[1] = 0;//msg to address b'011', cmd,0...b'01110000'
            int i = 7 * 16;

            byte1[0] = (byte)i;
            serialPort1.ReadExisting();
            serialPort1.Write(byte1, 0, 1);

            string s = program1.WaitMessage();
            textBox1.Text = s;
        }
    }
}
