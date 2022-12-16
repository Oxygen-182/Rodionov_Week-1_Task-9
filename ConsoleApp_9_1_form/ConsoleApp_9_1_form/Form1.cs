using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp_9_1_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            string line = string.Empty;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                line = textBox1.Text;

                if (!string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
            }

            foreach (char c in line)
                if (char.IsPunctuation(c) || char.IsNumber(c)) sb.Append(" ");
                else sb.Append(c);

            string[] lineAr = sb.ToString().Split(' ');

            long count = 0;
            foreach (string s in lineAr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                textBox2.Text += Environment.NewLine + "В строке нет слов";
                return;
            }

            FileStream f = new FileStream("file_so_slovami.txt", FileMode.Create);
            StreamWriter mem = new StreamWriter(f);
            for (int i = 0; i < lineAr.Length; ++i)
            {
                mem.Write(lineAr[i] + " ");
            }
            mem.Close();

            f = new FileStream("file_so_slovami.txt", FileMode.Open);
            StreamReader mim = new StreamReader(f, Encoding.GetEncoding(1251));

            for (int i = 0; i < lineAr.Length; ++i)
            {
                if (lineAr[i][0] == lineAr[i][lineAr[i].Length - 1])
                    textBox2.Text += (lineAr[i] + " ");
            }
        }
    }
}
