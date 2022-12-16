using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                Console.Write("Введите строку: ");
                line = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    Console.Write("\n");
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
                Console.WriteLine("В строке нет слов\n");
                return;
            }

            FileStream f = new FileStream("file_so_slovami", FileMode.Create);
            BinaryWriter mem = new BinaryWriter(f);
            for (int i = 0; i < lineAr.Length; ++i)
            {
                    mem.Write(lineAr[i] + " ");
            }
            mem.Close();

            Console.Write($"\nСлова, которые начинаются и заканчиваются одной буквой: ");

            f = new FileStream("file_so_slovami", FileMode.Open);
            BinaryReader mim = new BinaryReader(f, Encoding.GetEncoding(1251));

            for (int i = 0; i < lineAr.Length; ++i)
            {
                if (lineAr[i][0] == lineAr[i][lineAr[i].Length - 1])
                    Console.Write(lineAr[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
