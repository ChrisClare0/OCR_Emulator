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
    public partial class Form1 : Form
    {
        public processor micro = new processor();
        public bool run = false;
        public string Processor_Type;
        public bool Has_External_Emulator = false;
        public int Hex_Output_start = 0x500;
        public string[] hexcode = new string[255];
        private SerialProgrammer.SerialProgrammer serialP = new SerialProgrammer.SerialProgrammer();
        
        public Form1()
        {
            InitializeComponent();
            listBox_ProcessorType.SelectedIndex = 0;
            Has_External_Emulator = false;    
            ProgramText.AcceptsTab = true;


            label_version.Text = Application.ProductName + " Version = ";
            try
            {
                label_version.Text += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                label_version.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        protected void Button_Parse_Click()
        {
            string s = ProgramText.Text;//get text
            SerialProgrammer.SerialProgrammer serialP = new SerialProgrammer.SerialProgrammer();
            string line = ""; string s1 = ""; int n = 0;
            string label = ""; int Rd = 0; int Rs = 0; string data = ""; string op = "";
            int i = 0;

            micro.maxcodelines = 0; micro.maxlabels = 0;
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
                label = ""; op = "";
                s1 = line;//preserve orig line
                if (!serialP.DecodeLine(ref s1, ref label, ref op, ref Rs, ref Rd, ref data))
                {//we have an error...
                    TextBox_Info.Text = s1 + "at line " + n.ToString() + "   :" + line;
                    n = ProgramText.Text.IndexOf(line);
                    ProgramText.SelectionStart = n;
                    ProgramText.SelectionLength = line.Length;
                    ProgramText.Focus();
                    UpdateView(true);
                    return;
                }
                s1 = line;

                if (label == "TABLE")
                {
                    micro.table = micro.maxcodelines;
                }
                if (label != "")
                {
                    micro.labels[micro.maxlabels] = label;
                    micro.labelvalues[micro.maxlabels] = micro.maxcodelines;
                    micro.maxlabels++;
                }
                if ((op == "BYTE") || (op == "EQUB"))//emulator only
                {
                    micro.memory[micro.maxcodelines] = data;
                    //micro.maxcodelines++;
                    //op = "";
                }
                if (op != "")
                {
                    micro.memory[micro.maxcodelines] = line;
                    micro.maxcodelines++;
                }
                n++;
            }
            Reset(); Reset();
            TextBox_Info.Text = "Ready";
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

            textBox_OutputPort.Text = v.ToString("X2");
            //Clock_Out.Text = (((double)micro.clock) / 1000).ToString();
            if (fullupdate)
            {
                textBox_Z.ForeColor = black;
                s = micro.CurrentZ.ToString();
                if (textBox_Z.Text != s) textBox_Z.ForeColor = red;
                textBox_Z.Text = s;

                textBox_C.ForeColor = black;
                s = micro.CurrentC.ToString();
                if (textBox_C.Text != s) textBox_C.ForeColor = red;
                textBox_C.Text = s;


            }
        }
        protected void Cross_Assemble()
        {
            Button_Parse_Click();//check we have the OCR code in micro.memory
            if (micro.maxcodelines == 0) { TextBox_Info.Text = "No code!"; return; }
            Processor_Type = listBox_ProcessorType.SelectedItem.ToString();
            string s = "";

            switch (Processor_Type)
            {
                case "16F73": textBox_PICOutput.Text = Resource1.setup_16F73;break;
                case "16F876_NoSerial": textBox_PICOutput.Text = Resource1.setup_16F876;break;
                case "16F876A (+ Serial Support)": textBox_PICOutput.Text = "#define Use16F876A"+Resource1.setup_16F8xx; break;
                case "16F876 (+ Serial Support)": textBox_PICOutput.Text = "#define Use16F876" + Resource1.setup_16F8xx; break;
                case "16F886 (+ Serial Support)": textBox_PICOutput.Text = "#define Use16F886" + Resource1.setup_16F8xx; break;
                default: textBox_PICOutput.Text = "Unknown Processor " + Processor_Type; return;
            }

            SerialProgrammer.SerialProgrammer p1 = new SerialProgrammer.SerialProgrammer();
            for (int i = 0; i < micro.maxcodelines; i++) p1.OCRCode[i] = micro.memory[i];
            p1.max_OCRlines = micro.maxcodelines;
            if (!p1.GenerateMC(ref s, true ))
            {
                TextBox_Info.Text = "ERROR: " + s; 
                return;
            }//note for output is on PORTC
            for(int i =0; i<p1.max_ASMlines;i++){textBox_PICOutput.Text += p1.AssemblerCode[i]+Environment.NewLine;}
            textBox_PICOutput.Text += "    END" + Environment.NewLine; ;
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
            if ((r < 0) || (r > 200))
            {
                s = "Invalid Register number " + s[1]; return false;
            }
            return true;
        }
        protected bool DecodeLine_old(ref string line, ref string label, ref string op, ref int Rs, ref int Rd, ref string data)
        {
            line = line.ToUpper();
            if (line == "{") micro.InLineAssembler = true;
            if (line == "}") micro.InLineAssembler = false;
            if (micro.InLineAssembler) { op = ""; return true; }//done!
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
                case "JGT":
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
                case "RRF":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                case "RLF":
                    if (!GetRegister(ref data, ref Rd)) { line = data; return false; }
                    data = "";
                    break;
                //emulator only
                case "EQUB": break;
                case "BYTE": break;
                case "BREAK": break;
                case "TRISQ": break;//added as ext to tristate output port,,,S0 has bit mask  0 for out
                case "EQUS": break;


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
            if (!serialP.DecodeLine(ref line, ref label, ref op, ref Rs, ref Rd, ref data))
            {
                TextBox_Info.Text = "No such line"; return;
            }
            if (serialP.InLineAssembler)
            {
                UpdateView(updatedisplay);
                micro.CurrentPC++;
                TextBox_Info.Text = micro.memory[micro.CurrentPC];
                return;
            }
            int imm = 0;
            if ((data == "READTABLE") && (op == "RCALL")) { op = "READTABLE"; data = ""; }
            if ((data == "READADC") && (op == "RCALL")) { op = "READADC"; data = ""; }
            if ((data == "WAIT1MS") && (op == "RCALL")) { op = "WAIT1MS"; data = ""; }
            if ((data == "BREAK") && (op == "RCALL")) { op = "BREAK"; data = ""; }
            // following are exensions.....
            if ((data == "READEEPROM") && (op == "RCALL")) { op = "READEEPROM"; data = ""; }
            if ((data == "WRITEEEPROM") && (op == "RCALL")) { op = "WRITEEEPROM"; data = ""; }
            if ((data == "Setup_1602") && (op == "RCALL")) { op = "Setup_1602"; data = ""; }
            if ((data == "WriteCmd_1602") && (op == "RCALL")) { op = "WriteCmd_1602"; data = ""; }
            if ((data == "WriteData_1602") && (op == "RCALL")) { op = "WriteData_1602"; data = ""; }
            if (data != "")
            {
                if ((op == "JP") || (op == "JZ") || (op == "JNZ")||(op=="JGT")) //jgt is extension
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
                    ProgramText.Text = mys.ReadToEnd();
                    mys.Close();
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
            catch (Exception e1)
            {
                MessageBox.Show("File Save Error: " + e1.Message, "Save Error"); 
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
            catch (Exception e1)
            {
                MessageBox.Show("File Save Error: " + e1.Message, "Save Error");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_test_Click(object sender, EventArgs e)
        {
            
            //check the code parses
            Button_Parse_Click();
            //copy the current OCR code to the programmer...
            InCircuitProgramer f = new InCircuitProgramer();

            for (int i = 0; i < micro.maxcodelines; i++) f.program1.OCRCode[i] = micro.memory[i];
            f.program1.max_OCRlines = micro.maxcodelines;
            f.Setup();
            f.ShowDialog();
        }

        private void listBox_ProcessorType_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            set 
            {
                pc = value;
            }

        }
        private byte[] r = new byte[20];
        private int[] stack = new int[8];
        private int sp = 0;
        private int Z;
        private int C;
        private byte c_temp;
        public int CurrentZ
        {
            get
            {
                return Z;
            }
        }
        public int CurrentC
        {
            get
            {
                return C;
            }
        }
        public int table = -1;
        public int inport = 0;
        public int outport = 0;
        public int adc = 0;
        public string[] memory = new string[255 * 4];//ben's mod
        public int maxcodelines = 0;                //OCR codelines

        public string[] labels = new string[255];
        public int[] labelvalues = new int[255];
        public int maxlabels = 0;
        public int clock = 0;
        public bool InLineAssembler = false;

        public string[] eeprom_memory = new string[255]; //extension for Conor L

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

        public bool execute(string op, int Rd, int Rs, int data, ref string error)
        {
            string s = "";
            pc++; error = ""; clock++; 
            switch (op)
            {
                case "": break;
                case "MOVI": r[Rd] = (byte)data; setZ(Rd); break;
                case "MOV": r[Rd] = r[Rs]; setZ(Rd); break;
                case "ADD": r[Rd] = (byte)(r[Rd] + r[Rs]); setZ(Rd); break;
                case "SUB": if (r[Rs] > r[Rd]) C = 1; else C = 0; 
                    r[Rd] = (byte)(r[Rd] - r[Rs]);
                    setZ(Rd);  
                    break;
                case "AND": r[Rd] = (byte)(r[Rd] & r[Rs]); setZ(Rd); break;
                case "EOR": r[Rd] = (byte)(r[Rd] ^ r[Rs]); setZ(Rd); break;
                case "SHL": r[Rd] = (byte)(r[Rd] << 1); setZ(Rd); break;
                case "SHR": r[Rd] = (byte)(r[Rd] >> 1); setZ(Rd); break;
                case "RLF": c_temp = (byte)C;
                    if ((r[Rd] & (byte)0x80) == 0x80) C = (byte)1; else C = 0; 
                    r[Rd] = (byte)(r[Rd] << 1);
                    if (c_temp == 1) r[Rd]++;
                    break;
                case "RRF": c_temp = (byte)C;
                    C = r[Rd] & (byte)0x01; 
                    r[Rd] = (byte)(r[Rd] >> 1); 
                    if(c_temp == 1) r[Rd]=(byte)(r[Rd]+0x80);
                    break;
                case "INC": r[Rd]++; setZ(Rd); break;
                case "DEC": r[Rd]--; setZ(Rd); break;
                case "JP": pc = data; break;
                case "JZ": if (Z == 1) pc = data; break;
                case "JNZ": if (Z == 0) pc = data; break;
                case "JGT": if (C != 0) pc = data; break;
                case "RCALL": push(pc); pc = data; break;
                case "RET": pc = pull(); break;
                case "IN": r[Rd] = (byte)inport; break;
                case "OUT": outport = r[Rs]; break;
                case "READTABLE":
                    if (table < 0) { error = "Error - Table not setup!"; return false; }
                    try
                    {
                        s = memory[table + r[7]]; //will be label /t   BYTE /t   nn
                        int i = s.IndexOf("BYTE"); s = s.Substring(i + 4); i = 0;
                        while (s[i] < 33) i++;
                        r[0] = (byte)System.Convert.ToInt16(s.Substring(i), 16);
                    }
                    catch
                    {
                        error = "Bad Lookup table value address:" + r[7].ToString() + "value:" + s; return false;
                    }
                    break;

                case "READADC":
                    r[0] = (byte)adc;
                    break;
                case "WAIT1MS": clock += 999; break;
                case "BREAK": break;
                case "READEEPROM":
                    s = eeprom_memory[r[7]];
                    r[0] = (byte)System.Convert.ToInt16(s);
                    break;
                case "WRITEEEPROM":
                    eeprom_memory[r[7]] = r[0].ToString();
                    break;

                default: error = "Unknown Op Code " + op; return false; break;
            }
            return true;
        }
    }
}
