using System;
using System.Collections.Generic;
using TODOFile;

namespace ZTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ToDo> L1 = new List<ToDo>();
            string path = $"{Environment.CurrentDirectory}\\TODOLIST.json";
            TODOFILE file = new TODOFILE(path);

            L1 = file.ReadF();
            DoList P = new DoList(L1);
            P.GetInfo();
            Console.WriteLine("Выберите действие и введите нужную цифру:");
            void rep() 
            {
                string n = Console.ReadLine();
                switch (n)
                {   
                    case "1":
                        Console.Clear();
                        P.GetInfo();
                        P.All();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;

                    case "2":
                        Console.Clear();
                        P.GetInfo();
                        P.Delete();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;

                    case "3":
                        P.Create();
                        Console.Clear();
                        P.GetInfo();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;

                    case "4":
                        Console.Clear();
                        P.GetInfo();
                        P.SortL();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;

                    case "5":
                        Console.Clear();
                        P.GetInfo();
                        P.Find();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;

                    case "6":
                        Console.Clear();
                        P.GetInfo();
                        P.ToDo();
                        Console.WriteLine("Выберите действие и введите нужную цифру:");
                        rep();
                        break;
                    case "7":
                        P.Save();
                        break;
                 
                }
            }
            rep();

        }
    }
}
