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

namespace ConsoleApp_9_2_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            FileStream f1 = new FileStream("file_so_strokami.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1, Encoding.GetEncoding(1251));

            FileStream f2 = new FileStream("new.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f2);

            while (!sr.EndOfStream)
            {
                var tmp = sr.ReadLine();

                if (tmp.Length != 0)
                {
                    if (tmp.Length % 2 == 0)
                    {
                        textBox1.Text += tmp + " Ч" + Environment.NewLine;
                    }
                    else
                    {
                        textBox1.Text += tmp + Environment.NewLine;
                    }
                }

                if (tmp.Length % 2 == 0)
                {
                    sw.WriteLine(tmp);
                }
            }
            sw.Close();
            textBox1.Text += Environment.NewLine + "\nСтроки четной длины переписаны в новый файл";
        }
    }
}
