using System;


namespace AnagrammFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                Table tab = new Table(args[0], args[1]);
                tab.downloadToFile();
                Menu();
            }
            else
            {
                Menu();
            }
        }

        public static void Menu()
        {
            string req = "", f_name_1 = "", f_name_2 = "";
            do
            {
                Console.WriteLine("1. Ввести вх/вых файлы");
                Console.WriteLine("0. Выход");
                Console.Write(">> ");
                req = Console.ReadLine();

                switch (req)
                {
                    case "1":
                        Console.WriteLine("Введите путь к входному файлу >> ");
                        f_name_1 = Console.ReadLine();
                        Console.WriteLine("Введите путь к выходному файлу >> ");
                        f_name_2 = Console.ReadLine();
                        if (f_name_1.Length != 0 || f_name_2.Length != 0)
                        {
                            Table table = new Table(f_name_1, f_name_2);
                            table.downloadToFile();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Были введены неккоректные данные, повторите ввод");
                            break;
                        }
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Были введены неккоректные данные, повторите ввод");
                        break;
                }

            }
            while (req != "0");
        }
    }

}
