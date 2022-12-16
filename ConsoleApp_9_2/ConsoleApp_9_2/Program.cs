using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f1 = new FileStream("file_so_strokami.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1, Encoding.GetEncoding(1251));

            FileStream f2 = new FileStream("new.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f2);

            Console.WriteLine("Содержимое файла file_so_strokami.txt (четные строки помечены буквой Ч):\n");
            while (!sr.EndOfStream)
            {
                var tmp = sr.ReadLine();

                if(tmp.Length != 0)
                {
                    if (tmp.Length % 2 == 0)
                    {
                        Console.WriteLine(tmp + " Ч");
                    }
                    else
                    {
                        Console.WriteLine(tmp);
                    }
                }

                if (tmp.Length % 2 == 0)
                {
                    sw.WriteLine(tmp);
                }
            }
            sw.Close();
            Console.WriteLine("\nСтроки четной длины переписаны в новый файл");
        }
    }
}
