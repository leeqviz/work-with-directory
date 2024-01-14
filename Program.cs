using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DWork
{
    class Program
    {
        public static List<Computer> list = new List<Computer>();

        public static void Main()
        {
            UserInterface();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void UserInterface()
        {
            WorkWithDir wwd = new WorkWithDir();
            bool flag = false;
            while (!flag)
            {
                Console.Clear();
                Console.WriteLine("Получить содержимое каталога - 1\n" +
                    "Поиск файлов по маске - 2\n" +
                    "Поиск содержимого файлов - 3\n" +
                    "Сериализация - 4\n" +
                    "Завершить работу программы - 0");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            bool flag1 = false;
                            while (!flag1)
                            {
                                Console.Clear();
                                Console.WriteLine("Получить содержимое искомой директории - 1\n" +
                                    "Получить содержимое текущей директории - 2\n" +
                                    "Выход из данного меню - 0");
                                string direction = Console.ReadLine();
                                switch (direction)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Введите абсолютный путь...");
                                            string dir = Console.ReadLine();
                                            //wwd.DirectoryScan("C:\\Users\\Govnuck\\Desktop\\eclipse-workspace\\osisp_lb2_tcp");
                                            wwd.DirectoryScan(dir);
                                            Console.ReadKey();
                                            break;
                                        }
                                    case "2":
                                        {
                                            wwd.DirectoryScan("");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case "0":
                                        {
                                            flag1 = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Введены не верные значения! Нажмите любую клавишу и повторите попытку...");
                                            Console.ReadKey();
                                            break;
                                        }
                                }
                            }
                            //Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            /*Console.WriteLine("Введите абсолютный путь к директории...");
                            string dir = Console.ReadLine();
                            Console.WriteLine("Введите маску искомых файлов...");
                            string mask = Console.ReadLine();
                            wwd.FileSearch(dir, mask);*/
                            wwd.FileSearch("C:\\Users\\Govnuck\\Desktop\\eclipse-workspace\\osisp_lb2_tcp", "*.java");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            /*Console.WriteLine("Введите абсолютный путь к директории...");
                            string dir = Console.ReadLine();
                            Console.WriteLine("Введите искомое слово...");
                            string word = Console.ReadLine();
                            wwd.WordSearch(dir, word);*/
                            wwd.WordSearch("C:\\Users\\Govnuck\\Desktop\\osispSharp\\test", "gtntn");
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            SerializationUserInterface();
                            break;
                        }
                    case "0":
                        {
                            flag = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введены не верные значения! Нажмите любую клавишу и повторите попытку...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
            
        }

        public static void SerializationUserInterface()
        {
            bool flag = false;
            while (!flag)
            {
                BinaryFormatter bf = new BinaryFormatter();
                Console.Clear();
                Console.WriteLine("Добавить элемент в список - 1\n" +
                    "Удалить элемент из списка - 2\n" +
                    "Вывести содержимое списка - 3\n" +
                    "Сохранить список в файл - 4\n" +
                    "Загрузить содержимое файла - 5\n" +
                    "Выход из данного меню - 0");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            CreateObj();
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите индекс элемента, который вы хотите удалить...");
                            try
                            {
                                string input = Console.ReadLine();
                                int index = Convert.ToInt32(input);
                                list.RemoveAt(index);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine($"Ошибка - {ex}");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            foreach (Computer cmp in list)
                            {
                                cmp.Display();
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            FileStream fs = new FileStream("serial.dat", FileMode.OpenOrCreate);
                            
                            bf.Serialize(fs, list);
                            Console.WriteLine("Объект сериализован!");
                            
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            FileStream fs = new FileStream("serial.dat", FileMode.OpenOrCreate);
                            
                            List<Computer> slist = (List<Computer>)bf.Deserialize(fs);

                            Console.WriteLine("Объект десериализован!");
                            foreach (Computer cmp in slist)
                            {
                                cmp.Display();
                            }
                            
                            Console.ReadKey();
                            break;
                        }
                    case "0":
                        {
                            flag = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введены не верные значения! Нажмите любую клавишу и повторите попытку...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }

        public static void CreateObj()
        {
            Console.WriteLine("Введите: CPU RAM GPU storage motherboard: ");
            try
            {
                string input = Console.ReadLine();
                string[] str = input.Split(' ');
                string cpu = str[0];
                string ram = str[1];
                string gpu = str[2];
                string storage = str[3];
                string motherboard = str[4];
                Computer tempCmp = new Computer(cpu, ram, gpu, storage, motherboard);
                list.Add(tempCmp);   
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка - {ex}");
            }
        }
    }
}
