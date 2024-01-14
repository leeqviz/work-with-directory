using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWork
{
    class WorkWithDir
    {
        public WorkWithDir() {}

        public void WordSearch(string dir, string word)
        {
            if (Directory.Exists(dir))
            {
                string[] directions = Directory.GetDirectories(dir);
                foreach (string s in directions)
                {
                    WordSearch(s, word);
                }
                string[] files = Directory.GetFiles(dir);
                foreach (string s in files)
                {
                    Console.WriteLine($"Найден файл: {s}\nТекущий каталог: {dir}");
                    string[] file = File.ReadAllLines(s);
                    foreach (string str in file)
                    {
                        str.Split(' ');
                        if (str == word)
                            Console.WriteLine($"Файл {s} содержит указанное слово!");
                        else
                            Console.WriteLine($"Слово {word} не найдено!");
                    }
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Директория по указанному пути не найдена!");
        }

        public void FileSearch(string dir, string mask)
        {
            if (Directory.Exists(dir))
            {
                string[] directions = Directory.GetDirectories(dir);
                foreach (string s in directions)
                {
                    FileSearch(s, mask);
                }
                string[] files = Directory.GetFiles(dir, mask);
                foreach (string s in files)
                {
                    Console.WriteLine($"Найден файл: {s}\nТекущий каталог: {dir}");
                }
            }
            else
                Console.WriteLine("Директория по указанному пути не найдена!");
        }

        public void DirectoryScan(string dir)
        {
            if(dir == "") dir = Directory.GetCurrentDirectory();
            if (Directory.Exists(dir))
            {
                string[] directions = Directory.GetDirectories(dir);
                foreach(string s in directions)
                {
                    Console.WriteLine($"Подкаталог: {s}");
                    DirectoryScan(s);
                }
                string[] files = Directory.GetFiles(dir);
                foreach (string s in files)
                {
                    Console.WriteLine($"Файл: {s}");
                }
                Console.WriteLine();
            } else
                Console.WriteLine("Директория по указанному пути не найдена!");
        }
    }
}
