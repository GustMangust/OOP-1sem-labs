using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lab6
{
    class Army
    {
        public ArrayList list = new ArrayList();
        public void Add(object obj) 
        {
            list.Add(obj);
            Console.WriteLine("Объект " + obj + " добавлен в армию");
            Console.WriteLine();
        }
        public void Delete(object obj)
        {
            bool flag = false;
            for (int i = 0; i < list.Count; i++) 
            {
                if (ReferenceEquals(list[i], obj))
                {
                    list.RemoveAt(i);
                    Console.WriteLine(obj + " удалён из армии");
                    Console.WriteLine();
                    flag = true;
                    break;
                }
            }
            if (!flag) 
            {
                Console.WriteLine("Нет такого объекта");
                Console.WriteLine();
            }
        }
        public void Print()
        {
            Console.WriteLine("Cписок: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
    }
}
