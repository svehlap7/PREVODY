using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG_PREVODY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int BinToDec(string number)
        {
            int p = 0;
            int lenght = number.Length;
            int power = 1;
            for (int x = lenght - 1; x >= 0; x--)
            {
                int c = number[x] - '0';
                p += c * power;
                power *= 2;
            }
            return p;
        }

        private string DecToBin(int number)
        {
            string s = "";
            while (number != 0)
            {
                int p = number % 2;
                s = p + s;
                number = number / 2;
            }

            return s;
        }
        public int HexToDec(string hex)
        {
            int dec = 0;
            int power = 1;
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                char ch = hex[i];
                if (char.IsNumber(ch))
                {
                    dec += (ch - 48) * power;
                    power *= 16;
                }
                else
                {
                    dec += (ch - 55) * power;
                    power *= 16;
                }
            }
            return dec;
        }

        public string DecToHex(int dec)
        {
            string hex = "";
            while (dec > 0)
            {
                int p = dec % 16;
                dec /= 16;
                if (p > 9)
                {
                    hex = (char)(p - 10 + 'A') + hex;
                }
                else
                {
                    hex = p + hex;
                }
            }
            return hex;
        }

        private string HexToBin(string number)
        {
            string slovo = "";
            for (int a = 0; a < number.Length; a++)
            {
                switch (number[a])
                {
                    case '0':
                        slovo += "0000";
                        break;
                    case '1':
                        slovo += "0001";
                        break;
                    case '2':
                        slovo += "0010";
                        break;
                    case '3':
                        slovo += "0011";
                        break;
                    case '4':
                        slovo += "0100";
                        break;
                    case '5':
                        slovo += "0101";
                        break;
                    case '6':
                        slovo += "0110";
                        break;
                    case '7':
                        slovo += "0111";
                        break;
                    case '8':
                        slovo += "1000";
                        break;
                    case '9':
                        slovo += "1001";
                        break;
                    case 'A':
                        slovo += "1010";
                        break;
                    case 'B':
                        slovo += "1011";
                        break;
                    case 'C':
                        slovo += "1100";
                        break;
                    case 'D':
                        slovo += "1101";
                        break;
                    case 'E':
                        slovo += "1110";
                        break;
                    case 'F':
                        slovo += "1111";
                        break;
                }
            }
            int x = 0;
            while (slovo[x] == '0')
            {
                slovo = slovo.Remove(0, 1);
            }
            return slovo;
        }

        private string BinToHex(string number)
        {
            string hex = "";
            int lenght = number.Length % 4;
            switch (lenght)
            {
                case 1: number = "000" + number; break;
                case 2: number = "00" + number; break;
                case 3: number = "0" + number; break;
            }

            lenght = number.Length / 4;
            for (int p = 0; p < lenght; p++)
            {
                string bin = number.Substring(0, 4);
                number = number.Remove(0, 4);
                switch (bin)
                {
                    case "0000":
                        hex += '0';
                        break;
                    case "0001":
                        hex += '1';
                        break;
                    case "0010":
                        hex += '2';
                        break;
                    case "0011":
                        hex += '3';
                        break;
                    case "0100":
                        hex += '4';
                        break;
                    case "0101":
                        hex += '5';
                        break;
                    case "0110":
                        hex += '6';
                        break;
                    case "0111":
                        hex += '7';
                        break;
                    case "1000":
                        hex += '8';
                        break;
                    case "1001":
                        hex += '9';
                        break;
                    case "1010":
                        hex += 'A';
                        break;
                    case "1011":
                        hex += 'B';
                        break;
                    case "1100":
                        hex += 'C';
                        break;
                    case "1101":
                        hex += 'D';
                        break;
                    case "1110":
                        hex += 'E';
                        break;
                    case "1111":
                        hex += 'F';
                        break;
                }
            }
            return hex;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '1' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9' && e.KeyChar < 'A' || e.KeyChar > 'F' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string bin = textBox1.Text;
            if (bin != "")
            {
                int dec = BinToDec(bin);
                string hex = BinToHex(bin);
                textBox2.Text = hex;
                textBox3.Text = dec.ToString();
            }
            else
            {
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string hex = textBox2.Text;
            if (hex != "")
            {
                string bin = HexToBin(hex);
                int dec = HexToDec(hex);
                textBox1.Text = bin;
                textBox3.Text = dec.ToString();
            }
            else
            {
                textBox1.Clear();
                textBox3.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string DECi = textBox3.Text;
            if (DECi != "")
            {
                int cislo = Convert.ToInt32(textBox3.Text);
                textBox1.Text = DecToBin(cislo);
                textBox2.Text = DecToHex(cislo);
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
