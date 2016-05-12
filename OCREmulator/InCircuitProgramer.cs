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
    public partial class InCircuitProgramer : Form
    {
        public string[] hexcode = new string[255];//has 16F876 opcodes for OCR instructions
        public int max_lines = 0;
        public string[] PicCode = new string[255];//has 16F876 data read back
        public int[] BreakJumps = new int[255];
        public string source = "";
        public string[] source_1 = new string[255];//has ocr insrtuctions
        public int Code_start = 0x500;
        public int Code_break = 0x4f0;
        public bool breakset = false;

        public InCircuitProgramer()
        {
            InitializeComponent();
        }
        public void Setup()
        {
            char[] c1 = new char[1]; c1[0] = (char)0x0d;
            source_1 = source.Split(c1);
            int i = 0;
            foreach (string s in source_1)
            {
                if (s.Length > 0)
                {
                    source_1[i] = s.Substring(1, s.Length - 1);
                }
                i++;
            }
            i = 0;
            TextBox_Source.Text = source;
            string[] SerialPortEnums = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in SerialPortEnums) comboBox_ComPorts.Items.Add(s);
            comboBox_ComPorts.SelectedIndex = 0;
            serialPort1.ReceivedBytesThreshold = 17;//this is length of response from brak///
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            textBox1.Text = SendMessage("@@@@" + textBox_send.Text);
        }
        private int CountWordsinCode()
        {
            int no_words = 0;
            for (int i = 0; i < max_lines; i++)
            {
                no_words += hexcode[i].Length / 4;
            }
            return no_words;
        }
        private bool ProgramWord(int address, string data)
        {
            bool success = false; int tries = 0; string s = "";
            while ((!success) && (tries < 4))
            {
                s = SendMessage("@@@@R0" + address.ToString("X"));
                if (s == data)return true;
                s = SendMessage("@@@@W0" + address.ToString("X") + data);
                s = SendMessage("@@@@R0" + address.ToString("X"));
                if (s == data) success = true;
                tries++; 
            }
            return success;
        }
        private void button_uploadHex_Click(object sender, EventArgs e)
        {
            textBox_ProgramStatus.Text = "Starting Program sequence";
            ProgramPIC();
            textBox_ProgramStatus.Text = "Programming successful";
        }
        private void ReadCode()
        {
            string s = ""; 
            int n_words = CountWordsinCode();
            progressBar1.Maximum = 1 + n_words/16;progressBar1.Value = 0;
            int add = Code_start; int n = n_words; s = "";
            //going to use block read (r) for speed 
            while (n > 0)
            {
                s += SendMessage("@@@@r0" + add.ToString("X"));
                n-=16; add += 16;
                progressBar1.Value++;
            }
            for (int i = 0; i < max_lines; i++)
            {
                PicCode[i]= s.Substring(0, hexcode[i].Length);
                s = s.Substring(hexcode[i].Length, s.Length - hexcode[i].Length);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string s = "";
            s = "@@@@Z";
            textBox1.Text = SendMessage(s) + Environment.NewLine;
            s = "@@@@Z";
            textBox1.Text = SendMessage(s) + Environment.NewLine;
            if (!textBox1.Text.Contains("Ready"))
            {
                MessageBox.Show("Unable to communicate with PIC. Check the serial connection is in place and reset the PIC and try again."); return;
            }

            button_uploadHex.Enabled = true;
            button_uploadBreaks.Enabled = true;
            button_send.Enabled = true;
            button_Start.Enabled = true;
            button_continue.Enabled = true;

        }
        private string SendMessage(string s)
        {
            byte[] byte1 = new byte[2];
            byte1[0] = 0x0d; byte1[1] = 0;
            serialPort1.ReadExisting();
            serialPort1.Write(s); serialPort1.Write(byte1, 0, 2);

            return WaitMessage();
        }
        private string WaitMessage()
        {
            int x = 0;
            string r = "";
            serialPort1.ReadTimeout = 1000; x = 0;
            for (int n = 0; n < 5; n++)
            {
                x = 0;
                try
                {
                    x = serialPort1.ReadByte();
                }
                catch { }
                if (x == 0x3f) x = 0;//ignore these
                if (x < 0x20) x = 0;
                if (x > 0)
                {
                    if (x == 0x40)//terminator..
                    {
                        return r;
                    }
                    else
                    {
                        r += (char)x; n = 0;//more bytes to get...
                    }
                }
            }
            return r;
        }

        private void InCircuitProgramer_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void TextBox_Source_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;//set or clear a break point
            MouseButtons s1 = new MouseButtons();
            s1 = e.Button;
            float z=TextBox_Source.Font.GetHeight()+1;
            z = y / z;
            //which row...
            y = (int)(z);
            //going to add breakpoint at this row...
            if (y >= source_1.Count()) return;
            if (source_1[y].Contains((char)0x09 + "Break")) 
            {
                source_1[y] = source_1[y].Substring(0, source_1[y].IndexOf((char)0x09 + "Break"));
                breakset = false;
            }
            else
            {
                if (!breakset)
                {
                    source_1[y] = source_1[y] + (char)0x09 + "Break";
                    breakset = true;
                }
                else
                {
                    MessageBox.Show("You can only set one break point at a time... give me a break here!");
                    return;
                }
            }
            TextBox_Source.Text = "";
            //and in window
            for (int i = 0; i < source_1.Count(); i++)
            {
                TextBox_Source.Text += source_1[i] + Environment.NewLine;
            }


        }

        private bool ProgramPIC()
        {
            // going to read memory first to check            
            ReadCode();//get a copy of the current pic code....
            int add = Code_start; string s = ""; string s1 = "";
            progressBar1.Maximum = max_lines; progressBar1.Value = 0;
            for (int i = 0; i < max_lines; i++)
            {
                //for each line of source
                if (source_1[i].Contains((char)0x09 + "Break"))
                {
                    //going to put in a call 0x0001
                    //and copy this instruction to the scratch space for return...
                    s1 = "2001";    //call 0001 
                    if (!ProgramWord(add, s1)) { return false; }
                    add++;
                    s = hexcode[i].Substring(4, hexcode[i].Length - 4);
                    while (s.Length > 3)
                    {
                        s1 = s.Substring(0, 4);
                        s = s.Substring(4, s.Length - 4);
                        if (!ProgramWord(add, s1)) { return false; }
                        add++;
                    }
                    //now need to put this instruction +ret into somewhere...
                    //going to use 0x4f0 atm
                    int n1 = Code_break;
                    s = hexcode[i];
                    s1 = s.Substring(0, 4);
                    s = s.Substring(4, s.Length - 4);
                    if (!ProgramWord(n1, s1)) { return false; }
                    n1++;
                    //now ret
                    s1 = "0008";
                    if (!ProgramWord(n1, s1)) {  return false; }

                }
                else
                {
                    //words should be the same...
                    if (PicCode[i] != hexcode[i])
                    {
                        s = hexcode[i];
                        while (s.Length > 3)
                        {
                            s1 = s.Substring(0, 4);
                            s = s.Substring(4, s.Length - 4);
                            if (!ProgramWord(add, s1)) {  return false; }
                            add++;
                        }
                    }
                    else
                    {
                        add += hexcode[i].Length / 4;
                    }
                }
                progressBar1.Value++;
            }
            return true;
        }

        private void button_uploadBreaks_Click(object sender, EventArgs e)
        {
            //going to set breaks in the code...
            //will read through memory
            if (!ProgramPIC()) { MessageBox.Show("Failed to program pic"); return; }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            string s = SendMessage("@@@@J0500");
            ReadyForBreak(s);
        }

        private void ReadyForBreak(string s)
        {
            textBox_ProgramStatus.Text = "Running....";
            if (breakset)
            {
                s = WaitMessage();
                textBox1.Text = s;
                if (s.Length > 17)
                {
                    textBox_ProgramStatus.Text = "At break point";    
                    textBox_Z.Text = s.Substring(0, 2);
                    textBox_S0.Text = s.Substring(2, 2);
                    textBox_S1.Text = s.Substring(4, 2);
                    textBox_S2.Text = s.Substring(6, 2);
                    textBox_S3.Text = s.Substring(8, 2);
                    textBox_S4.Text = s.Substring(10, 2);
                    textBox_S5.Text = s.Substring(12, 2);
                    textBox_S6.Text = s.Substring(14, 2);
                    textBox_S7.Text = s.Substring(16, 2);
                }
 
            }
            else
            {
                textBox1.Text = s;
            }
        }
        private void button_continue_Click(object sender, EventArgs e)
        {
            string s = SendMessage("@@@@C");
            textBox1.Text = s;
            textBox1.Text += WaitMessage();
            textBox1.Text += WaitMessage();
            textBox1.Text += WaitMessage();

        }

        private void comboBox_ComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.PortName = comboBox_ComPorts.SelectedItem.ToString();
            serialPort1.Open();
        }

 



    }
}
