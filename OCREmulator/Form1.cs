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
    public partial class Form1 : Form
    {
        public processor micro = new processor();
        public bool run = false;
        public string Processor_Type;
        public bool Has_External_Emulator = false;
        public int Hex_Output_start = 0x500;
        public string[] hexcode = new string[255];

        [System.Runtime.InteropServices.DllImport("K8055D.dll")]
        private static extern int OpenDevice(int CardAddress);
        [System.Runtime.InteropServices.DllImport("K8055D.dll")]
        private static extern void WriteAllDigital(int Data);
        [System.Runtime.InteropServices.DllImport("K8055D.dll")]
        private static extern void CloseDevice();
        [System.Runtime.InteropServices.DllImport("K8055D.dll")]
        private static extern int ReadAllDigital();

        public Form1()
        {
            InitializeComponent();
            listBox_ProcessorType.SelectedIndex = 0;
            if (OpenDevice(0) == -1)
            {
                Has_External_Emulator = false;
                checkBox_ExtEmulator.Enabled = false;
                checkBox_ExtEmulator.Checked = false;
            }
            else
            {
                checkBox_ExtEmulator.Enabled = true;
                checkBox_ExtEmulator.Checked = false;
                Has_External_Emulator = true;
            }
            CloseDevice();
            label_version.Text = "Version " + Application.ProductVersion;

        }

        protected void Button_Parse_Click()
        {
            //parse text
            string s = ProgramText.Text;//get text
            string s2 = ""; int asm_no = 0; string s3 = "";
            string line = ""; string s1 = ""; int n = 0;
            string label = ""; int Rd = 0; int Rs = 0; string data = ""; string op = "";
            int i = 0;
            micro.asmcodelines = 0;
            micro.maxcodelines = 0; micro.maxlabels = 0;
            while (s.Length > 0)
            {
                line = s; i = s.IndexOf((char)0x0d);
                if (i >= 0)
                {
                    //multi line.. so split it..
                    line = s.Substring(0, i); s = s.Substring(i + 2);
                }
                else s = "";
                label = ""; op = "";
                s1 = line;//preserve orig line
                if (!DecodeLine(ref s1, ref label, ref op, ref Rs, ref Rd, ref data))
                {//we have an error...
                    TextBox_Info.Text = s1 + "at line " + n.ToString() + "   :" + line; return;
                }
                s1 = line; asm_no = 0;
                ProcessLine_ToAssembler(s1, ref s2, ref s3, ref asm_no);
                if (label == "TABLE")
                {
                    micro.table = micro.maxcodelines;
                }
                if (label != "")
                {
                    micro.labels[micro.maxlabels] = label;
                    micro.labelvalues[micro.maxlabels] = micro.maxcodelines;
                    micro.labelvalues_code[micro.maxlabels] = micro.asmcodelines;
                    micro.maxlabels++;
                }
                if ((op == "BYTE") || (op == "EQUB"))//emulator only
                {
                    micro.memory[micro.maxcodelines] = data;
                    micro.maxcodelines++;
                    op = "";
                }
                if (op != "")
                {
                    micro.memory[micro.maxcodelines] = line;
                    micro.maxcodelines++;
                    micro.asmcodelines += asm_no;
                }
                n++;
            }
            Reset(); Reset();
            UpdateView(true);

        }
        protected void UpdateView(bool fullupdate)
        {
            TextBox t1; string s;
            Control[] cont = new Control[5];
            System.Drawing.Color black = System.Drawing.Color.Black;
            System.Drawing.Color red = System.Drawing.Color.Red;
            if (fullupdate)
            {
                for (int i = 0; i < 8; i++)
                {
                    s = System.Convert.ToString(micro.GetR(i), 16);
                    cont = this.Controls.Find("textBox_S" + i.ToString(), true);
                    t1 = (TextBox)cont[0];
                    t1.ForeColor = black;
                    if (t1.Text != s) t1.ForeColor = red;
                    t1.Text = s;
                }
            }
            s = System.Convert.ToString(micro.outport, 16);
         
            //TextBoxOut.ForeColor = black;
            //if (TextBoxOut.Text != s) TextBoxOut.ForeColor = red;
            //TextBoxOut.Text = s;

            int j = 7; int x = 0; int v = micro.outport;
            System.Windows.Forms.CheckBox b = new System.Windows.Forms.CheckBox();
            while (j >= 0)
            {
                x = v - (1 << j);
                cont = this.Controls.Find("checkBox_Q" + j.ToString(), true);
                b = (System.Windows.Forms.CheckBox)cont[0];
                b.Checked = (x >= 0) ? true : false;
                v = (x >= 0) ? x : v;
                j--;
            }
            v = micro.outport;
            if (Has_External_Emulator && checkBox_ExtEmulator.Checked)
            {
                int d1 = OpenDevice(0);
                WriteAllDigital(v);
                CloseDevice();
                
            }
            textBox_OutputPort.Text = v.ToString("X2");
            //Clock_Out.Text = (((double)micro.clock) / 1000).ToString();
            if (fullupdate)
            {
                textBox_Z.ForeColor = black;
                s = micro.CurrentZ.ToString();
                if (textBox_Z.Text != s) textBox_Z.ForeColor = red;
                textBox_Z.Text = s;
            }
        }


        protected bool ProcessLine_ToAssembler(string input,ref string line,ref string hexline,ref int no_lines)
        {
            string nl = Environment.NewLine;
            char t1 = (char)0x09; string t = ""; t += t1;
            line = line.ToUpper();
            string label = ""; int i = 0;
            string op = "";
            string data = ""; int Rs = 0; int Rd = 0;
            if (!DecodeLine(ref input, ref label, ref op, ref Rs, ref Rd, ref data))
            {
                return false;
            }
            line = "";
            if (op == "BLANK") return true;
            if (op == "") return true;
            if (label == "TABLE")
            {line += t + "ORG 0x400" + t + nl + label + nl + t; }
            else { line += label + (char)0x09; }



            switch (op)
            {
                case "":
                    line += "nop"+nl;
                    hexline += 0000; no_lines+= 1;
                    break;
                case "MOVI":
                    line += "movlw " + t + "0x" + data + nl;
                    line += t + "movwf" + t + "R" + Rd.ToString() + nl;
                    if (data.Length == 1) data = "0" + data;
                    hexline += "30" + data;// movlw
                    hexline += "00"+(Rd + 0xA0).ToString("X");//movwf
                    no_lines+= 2;
                    break;
                case "MOV":
                    line += "movf" + t + "R" + Rs.ToString() + ",0 " + nl;//ie to W
                    line += t + "movwf" + t + "R" + Rd.ToString() + nl;
                    if (data.Length == 1) data = "0" + data;
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    hexline += "00" + (Rd + 0xA0).ToString("X");//movwf
                    no_lines+= 2;
                    break;
                case "ADD":
                    line += "movf" + t + "R" + Rs.ToString() + ",0 " + nl;
                    line += t + "addwf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    hexline += "07" + (Rd + 0xA0).ToString("X");//addwf
                    no_lines+= 2;
                    break;
                case "SUB":
                    line += "movf" + t + "R" + Rs.ToString() + ",0 " + nl;
                    line += t + "subwf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    hexline += "02" + (Rd + 0xA0).ToString("X");//subwf to F
                    no_lines+= 2;
                    break;
                case "AND":
                    line += "movf" + t + "R" + Rs.ToString() + ",0 " + nl;
                    line += t + "andwf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    hexline += "05" + (Rd + 0xA0).ToString("X");//subwf to F                   
                    no_lines+= 2;
                    break;
                case "EOR":
                    line += "movf" + t + "R" + Rs.ToString() + ",0 " + nl;
                    line += t + "xorwf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    hexline += "06" + (Rd + 0xA0).ToString("X");//subwf to F
                    no_lines+= 2;
                    break;
                case "INC":
                    line += "incf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "0A" + (Rd + 0xA0).ToString("X");//incf to F
                    no_lines+= 1;
                    break;
                case "DEC":
                    line += "decf" + t + "R" + Rd.ToString() + ",1 " + nl;
                    hexline += "03" + (Rd + 0xA0).ToString("X");//decf to F
                    no_lines+= 1;
                    break;
                case "IN":
                    //read from portB
                    line += "movf" + t + "PORTB,0" + nl;
                    line += t + "movwf" + t + "R" + Rd.ToString() + nl;
                    hexline += "0806";//movf to W
                    hexline += "00" + (Rd + 0xA0).ToString("X");//movwf
                    no_lines+= 2;

                    break;
                case "OUT":
                    line += "movf" + t + "R" + Rs.ToString() + ",0" + nl;
                    line += t + "movwf" + t + "PORTC" + nl;
                    //tricky here cos bits 0-5 can go to port C, but b6/7 to Port A bits 4/5
                    
                    //asm code....
                    //  movf    Rs,W
                    hexline += "08" + (Rs + 0x20).ToString("X");//movf to W
                    //  movwf   PORTC   dont think this messes up serial...
                    hexline += "0087";
                    //  movwf   temp
                    hexline += "00AA" ;//temp1 is at 2A
                    //  rrf     temp1,1
                    hexline += "0CAA";
                    //  rrf     temp1,1    bit 7 - 5
                    hexline += "0CAA";
                    //  movlw   0x30
                    hexline += "3030";
                    //  andwf   temp1,0
                    hexline += "052A";
                    //  movwf   PORTA
                    hexline += "0085";
                    no_lines+= 8;

                    break;
                case "JP":
                    line += "goto" + t + data + nl;
                    i = 0x800 + FindLabel_asm(data) + Hex_Output_start;
                    hexline += "2" + i.ToString("X");//goto... 
                    no_lines+= 1;
                    break;
                case "JZ":
                    line += "btfsc" + t + "STATUS,2" + nl;
                    line += t + "goto" + t + data + nl;
                    hexline += "1903";// status = 3
                    i = 0x800 + FindLabel_asm(data) + Hex_Output_start;
                    hexline += "2" + i.ToString("X");//goto... 
                    no_lines += 2;
                    break;
                case "JNZ":
                    line += "btfss" + t + "STATUS,2" + nl;
                    line += t + "goto" + t + data + nl;
                    hexline += "1D03";// status = 3
                    i = 0x800 + FindLabel_asm(data) + Hex_Output_start;
                    hexline += "2" + i.ToString("X");//goto... 
                    no_lines += 2;
                    break;
                case "RCALL":
                    line += "call" + t + data + nl;
                    i = FindLabel_asm(data) + Hex_Output_start;
                    hexline += "2" + i.ToString("X");//goto... 
                    no_lines += 1;
                    break;
                case "RET":
                    line += "return" + nl;
                    hexline += "0008";//ret. 
                    no_lines += 1;
                    break;
                case "SHL":
                    //need to clear C first
                    line += "bcf" + t + "STATUS,0" + nl;
                    line += t + "rlf" + t + "R" + Rd.ToString() + ",1" + nl;
                    hexline += "1003";
                    hexline += "0D"+(Rs + 0xA0).ToString("X");
                    no_lines += 2;
                    break;
                case "SHR":
                    //need to clear C first
                    line += "bcf" + t + "STATUS,0" + nl;
                    line += t + "rrf" + t + "R" + Rd.ToString() + ",1" + nl;
                    hexline += "1003";
                    hexline += "0C" + (Rs + 0xA0).ToString("X");
                    no_lines += 2;
                    break;
                case "EQUB":
                    line += "db" + t + "0x00, 0x" + data + nl;
                    if (data.Length == 1) data = "0" + data;
                    hexline += "00" + data;
                    no_lines += 1;
                    break;
                case "BYTE":
                    line += "db" + t + "0x00, 0x" + data + nl;
                    if (data.Length == 1) data = "0" + data;
                    hexline += "00" + data;
                    no_lines += 1;
                    break;
                default:
                    break;
            }
            return true;
        }
        protected void Cross_Assemble()
        {
            int no_linescode = 0;
            if (micro.maxcodelines == 0) { TextBox_Info.Text = "No code!"; return; }
            Processor_Type = listBox_ProcessorType.SelectedItem.ToString();
            textBox_PICOutput.Text = "";
            string line = "";
            string s = "";
            string outputASM = "";
            string outputHEX = "";
            switch (Processor_Type)
            {
                case "16F73": textBox_PICOutput.Text = Resource1.setup_16F73;
                    break;

                case "16F876": textBox_PICOutput.Text = Resource1.setup_16F876;
                    break;

                default: textBox_PICOutput.Text = "Unknown Processor " + Processor_Type;
                    break;
            }

            s = ProgramText.Text;//get text
            string s1 = ""; int n = 0;
            int i = 0;
            //micro.maxcodelines = 0; micro.maxlabels = 0;
            while (s.Length > 0)
            {
                line = s; 
                i = s.IndexOf((char)0x0d);
                if (i >= 0)
                {
                    //multi line.. so split it..
                    line = s.Substring(0, i); 
                    s = s.Substring(i + 2);
                }
                else s = "";
                s1 = line;//preserve orig line
                outputHEX = ""; outputASM = "";
                if (!ProcessLine_ToAssembler(s1,ref outputASM, ref outputHEX, ref no_linescode))
                {//we have an error...
                    TextBox_Info.Text = s1 + "at line " + n.ToString() + "   :" + line; return;
                }
                //no error so add the code
                textBox_PICOutput.Text += outputASM;
                hexcode[n] = outputHEX;
                n++;
                //done one ocr line...
            }
            textBox_PICOutput.Text += "    END";
            textBox_PICOutput.Visible = true;

            return;
        }
        protected int FindLabel(string s)
        {
            for (int i = 0; i < micro.maxlabels; i++)
            {
                if (micro.labels[i] == s) return micro.labelvalues[i];
            }
            TextBox_Info.Text = "Error! Label " + s + " not found!";
            return -1;
        }
        protected int FindLabel_asm(string s)
        {
            for (int i = 0; i < micro.maxlabels; i++)
            {
                if (micro.labels[i] == s) return micro.labelvalues_code[i];
            }
            TextBox_Info.Text = "Error! Label " + s + " not found!";
            return -1;
        }

        protected void Reset()
        {
            micro.reset();

            TextBox_Info.Text = micro.memory[0];


        }
        protected bool GetRegister(ref string s, ref int r)
        {
            if (!s.StartsWith("S"))
            {
                s = "Register must be in format Sn";
                return false;
            }
            try
            {
                //fro tris try to parse 2 digits
                r = System.Convert.ToInt32(s.Substring(1, 1));
                try
                {
                    int temp = System.Convert.ToInt32(s.Substring(2, 1));
                    r = r * 10 + temp;
                }
                catch
                {
                }
            }
            catch (Exception e)
            {
                s = "Invalid Register number " + s[1]; return false;
            }
            if ((r < 0) || (r > 20))
            {
                s = "Invalid Register number " + s[1]; return false;
            }
            return true;
        }
        protected bool DecodeLine(ref string line, ref string label, ref string op, ref int Rs, ref int Rd, ref string data)
        {
            line = line.ToUpper();
            int n = 0, k = 0;
            char[] c1 = new char[2]; c1[0] = (char)0x09; c1[1] = ' ';
            //strip comments
            n = line.IndexOf(";");
            if (n != -1) { line = line.Substring(0, n); }
            n = line.IndexOfAny(c1);
            if (line.Length == 0)
            {
                //comment only
                op = ""; return true;//done!
            }
            if (n != 0)
            {
                //we have a label
                k = line.IndexOf(":");
                if (k < 1)
                {
                    //no colon so..
                    line = "Syntax Error:  labels must end with :"; return false;
                }
                label = line.Substring(0, k);
                line = line.Substring(k + 1);
            }
            line = line.Trim(c1);// strip the separators

            //now have opcode.....
            n = line.IndexOfAny(c1);//end of opcode
            if (n == -1) op = line;
            else
            {
                op = line.Substring(0, n);
                line = line.Substring(n + 1);
                line = line.Trim(c1);
                data = line;
            }

            switch (op)
            {
                case "":
                    break;
                case "MOVI":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    break;
                case "MOV":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "ADD":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "SUB":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "AND":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "EOR":
                    //todo... how to exor
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "INC":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                case "DEC":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                case "IN":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                case "OUT":
                    data = data.Substring(data.IndexOf(",") + 1);
                    if (!GetRegister(ref data, ref Rs)) { line = data; return false; }
                    data = "";
                    break;
                case "JP":
                    break;
                case "JZ":
                    break;
                case "JNZ":
                    break;
                case "RCALL":
                    break;
                case "RET":
                    break;
                case "SHL":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                case "SHR":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                //emulator only
                case "EQUB": break;
                case "BYTE": break;


                default:
                    line = "Invalid Op code" + op; return false; break;
            }
            return true;
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            Button_Parse_Click();
        }
        private void button_Step_Click_1(object sender, EventArgs e)
        {
            Step(true);
        }
        private void Step(bool updatedisplay)
        {


            //need to get the pc line of code........
            if (micro.maxcodelines == 0) { TextBox_Info.Text = "No code!"; return; }
            string line = micro.memory[micro.CurrentPC];
            string label = ""; int Rd = 0; int Rs = 0; string data = ""; string op = "";
            if (!DecodeLine(ref line, ref label, ref op, ref Rs, ref Rd, ref data))
            {
                TextBox_Info.Text = "No such line"; return;
            }
            int imm = 0;
            if ((data == "READTABLE") && (op == "RCALL")) { op = "READTABLE"; data = ""; }
            if ((data == "READADC") && (op == "RCALL")) { op = "READADC"; data = ""; }
            if ((data == "WAIT1MS") && (op == "RCALL")) { op = "WAIT1MS"; data = ""; }
            if (data != "")
            {
                if ((op == "JP") || (op == "JZ") || (op == "JNZ"))
                {
                    imm = FindLabel(data);//is it a label....
                }
                else
                {
                    try
                    {
                        imm = System.Convert.ToInt32(data, 16);
                    }
                    catch
                    {
                        imm = FindLabel(data);
                    }
                }
            }

            if (imm == -1) return;
            int d1 = (int)imm;
            try
            {
                double x = System.Convert.ToDouble(AnalogInput.Value);
                x=x / 100;
                micro.adc = (int)(255 * (x / 5));
            }
            catch
            {
                micro.adc = 0;
            }

            micro.inport = int.Parse(textBox_InputPort.Text,  System.Globalization.NumberStyles.AllowHexSpecifier);
            //try to see if we have the external hardware emulator there....
            if (Has_External_Emulator && checkBox_ExtEmulator.Checked)
            {
                OpenDevice(0);
                micro.inport = ReadAllDigital();
                CloseDevice();

            }

            if (!micro.execute(op, Rd, Rs, d1, ref line)) TextBox_Info.Text = "Error! " + line;
            UpdateView(updatedisplay);
            TextBox_Info.Text = micro.memory[micro.CurrentPC];
        }
        private int GetInputPort()
        {
            Control[] cont = new Control[5];
            int j = 7; int x = 0;
            System.Windows.Forms.CheckBox b = new System.Windows.Forms.CheckBox();
            while (j >= 0)
            {
                cont = this.Controls.Find("checkBox_b" + j.ToString(), true);
                b = (System.Windows.Forms.CheckBox)cont[0];
                x += (b.Checked) ? (1 << j) : 0;
                j--;
            }
            return x;

        }
        private void button_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "z:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.StreamReader mys = new System.IO.StreamReader(openFileDialog1.FileName);
                    {
                        ProgramText.Text = mys.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


        }
        private void button_Run_Click(object sender, EventArgs e)
        {
            run = true;
            while (run)
            {
                Step(false);
                Application.DoEvents();

            }
        }
        private void button_Break_Click(object sender, EventArgs e)
        {
            run = false;
        }
        private void AnalogInput_Scroll(object sender, EventArgs e)
        {
            double d = new double(); d = (double)AnalogInput.Value;
            d = d / 100;
            textBox_analogueInput.Text = d.ToString();
        }
        #region Input boxes
        private void textBox_InputPort_TextChanged(object sender, EventArgs e)
        {
            Control[] cont = new Control[5];
            try
            {
                //int v = System.Convert.ToInt16(textBox_InputPort.Text);
                int v = int.Parse(textBox_InputPort.Text, System.Globalization.NumberStyles.AllowHexSpecifier);

                int j = 7; int x = 0; 
                System.Windows.Forms.CheckBox b = new System.Windows.Forms.CheckBox();
                while (j >= 0)
                {
                    x = v - (1 << j);
                    cont = this.Controls.Find("checkBox_b" + j.ToString(), true);
                    b = (System.Windows.Forms.CheckBox)cont[0];
                    b.Checked = (x >= 0) ? true : false;
                    v = (x >= 0) ? x : v;
                    j--;
                }

            }
            catch
            {
            }
        }
        private void checkBox_b0_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b1_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b2_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b3_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b4_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b5_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b6_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        private void checkBox_b7_CheckedChanged(object sender, EventArgs e)
        {
            int v = GetInputPort(); textBox_InputPort.Text = v.ToString("X2");
        }
        #endregion
        private void button_ShowHelp_Click(object sender, EventArgs e)
        {
            EmulatorHelp h = new EmulatorHelp();
            
            h.ShowDialog();
        }
        private void button_CrossAssemble_Click(object sender, EventArgs e)
        {
            Cross_Assemble();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            micro.reset();
            TextBox_Info.Text = micro.memory[0];
            UpdateView(true);
        }
        private void button2_Click(object sender, EventArgs e)
        {        
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(saveFileDialog1.OpenFile());
                    sw1.Write(ProgramText.Text);
                    sw1.Close();
                }
            }
            catch
            {

            }
        }
        private void button_SaveASM_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "asm files (*.asm)|*.asm|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(saveFileDialog1.OpenFile());
                    sw1.Write(textBox_PICOutput.Text);
                    sw1.Close();
                }
            }
            catch
            {

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_test_Click(object sender, EventArgs e)
        {
            InCircuitProgramer f = new InCircuitProgramer();
            Cross_Assemble();//check it is done
            for (int i = 0; i < hexcode.Count(); i++)
            {
                f.hexcode[i] = hexcode[i];
                if (hexcode[i] == null) { f.max_lines = i; break; }
            }
            f.source = ProgramText.Text;
            f.Setup();
            f.ShowDialog();
        }
    }
    [Serializable]
    public class processor
    {
        private int pc = 0;
        public int CurrentPC
        {
            get
            {
                return pc;
            }
        }
        private byte[] r = new byte[20];
        private int[] stack = new int[8];
        private int sp = 0;
        private int Z;
        public int CurrentZ
        {
            get
            {
                return Z;
            }
        }
        public int table = -1;
        public int inport = 0;
        public int outport = 0;
        public int adc = 0;
        public string[] memory = new string[255 * 4];//ben's mod
        public int maxcodelines = 0;                //OCR codelines
        public int asmcodelines = 0;                // to remember how many lines of PIC code
        public string[] labels = new string[255];
        public int[] labelvalues = new int[255];
        public int[] labelvalues_code = new int[255];
        public int maxlabels = 0;
        public int clock = 0;

        public processor()
        {
            reset();
        }
        public int GetR(int i) { return r[i]; }
        public void reset()
        {
            pc = 0;
            outport = 0;
            for (int i = 0; i < 8; i++) r[i] = 0;
            clock = 0;
        }
        private void push(int d)
        {
            stack[sp] = d; sp++;
        }
        private int pull()
        {
            sp--; return stack[sp];
        }
        private void setZ(int Rd)
        {
            if (r[Rd] == 0) Z = 1; else Z = 0;
        }

        public bool execute(string op, int Rd, int Rs, int data, ref string error)//ben's mod
        {
            pc++; error = ""; clock++;
            switch (op)
            {
                case "": break;
                case "MOVI": r[Rd] = (byte)data; setZ(Rd); break;
                case "MOV": r[Rd] = r[Rs]; setZ(Rd); break;
                case "ADD": r[Rd] = (byte)(r[Rd] + r[Rs]); setZ(Rd); break;
                case "SUB": r[Rd] = (byte)(r[Rd] - r[Rs]); setZ(Rd); break;
                case "AND": r[Rd] = (byte)(r[Rd] & r[Rs]); setZ(Rd); break;
                case "EOR": r[Rd] = (byte)(r[Rd] ^ r[Rs]); setZ(Rd); break;
                case "SHL": r[Rd] = (byte)(r[Rd] << 1); setZ(Rd); break;
                case "SHR": r[Rd] = (byte)(r[Rd] >> 1); setZ(Rd); break;
                case "INC": r[Rd]++; setZ(Rd); break;
                case "DEC": r[Rd]--; setZ(Rd); break;
                case "JP": pc = data; break;
                case "JZ": if (Z == 1) pc = data; break;
                case "JNZ": if (Z == 0) pc = data; break;
                case "RCALL": push(pc); pc = data; break;
                case "RET": pc = pull(); break;
                case "IN": r[Rd] = (byte)inport; break;
                case "OUT": outport = r[Rs]; break;
                case "READTABLE":
                    if (table < 0) { error = "Error - Table not setup!"; return false; }
                    try
                    {
                        r[0] = (byte)System.Convert.ToInt16(memory[table + r[7]], 16);
                    }
                    catch
                    {
                        error = "Bad Lookup table value address:" + r[7].ToString() + "value:" + memory[r[7]].ToString(); return false;
                    }
                    break;

                case "READADC":
                    r[0] = (byte)adc;
                    break;
                case "WAIT1MS": clock += 999; break;

                default: error = "Unknown Op Code " + op; return false; break;
            }
            return true;
        }
    }
}
