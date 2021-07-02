using System;
using System.Collections.Generic;
using System.Text;
using TODOFile;

namespace ZTest
{
    public class Do
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Priority { set; get; }
        public string Text { set; get; }
    }

    public class ToDo : Do
    {
        public string Done { set; get; } = "Не выполнено";
        public void Info()
        {
            Console.WriteLine($"{Id} - {Name} - {Priority} - {Text} - {Done}");
        }
    }

    public class DoList
    {
        List<ToDo> ToDoL = new List<ToDo>();
        public DoList(List<ToDo> L)
        {
            ToDoL = L;
        }
        public void Create()
        {   int count = 0;
            foreach (ToDo c in ToDoL)
            { count = count + 1; }
            ToDo n = new ToDo();
            n.Id = count+1;
            Console.WriteLine("Введите название:");
            n.Name = Console.ReadLine();
            Console.WriteLine("Введите приоритетность выполнения (Важно / Не важно):");
            string pr = Console.ReadLine();
            void PR()
            {
                if (pr == "Важно" || pr == "Не важно")
                    n.Priority = pr;
                else
                {
                    Console.WriteLine("Неверно введен приоретет. Введите 'Важно' или 'Не важно'");
                    pr = Console.ReadLine();
                    PR();
                }
            }
            PR();
            Console.WriteLine("Введите описание:");
            n.Text = Console.ReadLine();

            ToDoL.Add(n);
        }

        public void All()
        {
            Console.WriteLine("Весь список дел:");
            int count = 0;
            foreach (ToDo c in ToDoL)
            { c.Info();
                count++;
            }
            if (count == 0)
                Console.WriteLine("Список дел пуст");
        }

        public void Delete()
        {
            Console.WriteLine("Введите номер дела, которое хотите удалить: ");
            int a = int.Parse(Console.ReadLine());
            ToDoL.RemoveAt(a-1);
            int count = 0;
            foreach(ToDo b in ToDoL)
            {
                count++;
                b.Id = count;
            }
            if (count == 0)
            {
                Console.WriteLine("Дела с таким номером нет!");
            }
        }

        public void Find()
        {
            Console.WriteLine("Введите назание дела: ");
            string name = Console.ReadLine();
            int count = 0;
            foreach (ToDo c in ToDoL)
            {
                if (c.Name == name)
                {
                    c.Info();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Дела с таким названием нет!");
                Find();
            }

        }

        public void SortL()
        {
            List<ToDo> l1 = new List<ToDo>();
            foreach (ToDo a in ToDoL)
            {
                if (a.Priority == "Важно")
                    a.Info();
            }
            foreach (ToDo a in ToDoL)
            {
                if (a.Priority == "Не важно")
                    a.Info();
            }

        }

        public void ToDo()
        {
            Console.WriteLine("Введите номер выполненного дела: ");
            int Id = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (ToDo c in ToDoL)
            {
                if (c.Id == Id)
                {
                    c.Done = "ВЫПОЛНЕНО";
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Дела с таким номером нет!");
                ToDo();
            }
        }
        public void Save()
        {
            string path = $"{Environment.CurrentDirectory}\\TODOLIST.json";
            TODOFILE file = new TODOFILE(path);
            file.SaveF(ToDoL);
        }

        public void GetInfo()
        {
            Console.WriteLine("Список дел.");
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine("1 - Просмотреть список дел." + '\n' +
                "2 - Удалить." + '\n' + "3 - Добавить." + '\n' + "4 - Отсортировать по важности." + '\n' +
                "5 - Поиск по названию." + '\n' + "6 - Отметить выполнение." + '\n' +
                "7 - Сохранить изменения и закрыть программу.");
            Console.WriteLine("_______________________________________________________");
            
        }
    }


}
