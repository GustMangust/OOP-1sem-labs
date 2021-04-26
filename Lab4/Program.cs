using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace Lab4
{
    public static class ExtensionClass 
    {
        public static void CommaAdd(this string str) 
        {
            string[] arr = str.Split(" ");
            for(int i = 0; i < arr.Length; i++) 
            {
                Console.Write(arr[i]+", ");
                int[,,] x = new int[2,3,4] { { {1,2,3,4},{1,2,3,4},{1,2,3,4} } , { {1,2,3,4},{1,2,3,4},{1,2,3,4} } };
            }
            Console.WriteLine();
        }
        public static Set check(this Set c)
        {
            int counter = 0;
            for (int i = 0; i < c.elements.Length; i++)
            {
                for (int k = 0; k < c.elements.Length; k++)
                {
                    if (c.elements[i] == c.elements[k])
                    {
                        counter++;
                    }
                }
                if (counter != 1)
                {
                    c.elements[i] = 0;
                }
                counter = 0;
            }
            return c;
        }
    }
    public class Set
    {
        public class Owner
        {
            private static int id;
            private static string name;
            private static string company;
            static Owner() 
            {
                id = 1;
                name = "Dmitry";
                company = "FIT";
            }
            public override string ToString() 
            {
                return "Owner: id - " + id + ", name - " + name + ", company - " + company;
            }
        }
        public class Date
        {
            private static int day;
            private static int month;
            private static int year;
            static Date()
            {
                day = 7;
                month = 10;
                year = 2020;
            }
            public override string ToString()
            {
                return "Date: day - " + day + ", month - " + month + ", year  - " + year;
            }
        }
        public int ind { get; } = 0;
        public int[] elements;
        public Set(int length)
        {
            elements = new int[length];
            
        }
            
        public static Set operator +(Set a, int num)
        {
            for (int i = 0; i < a.elements.Length; i++)
            {
                if (a.elements[i] == 0)
                {
                    a.elements[i] = num;
                    break;
                }
            }
            return a.check();
        }
        public static Set operator +(Set a, Set b)
        {
            Set c = new Set(a.elements.Length + b.elements.Length);
            int counter = 0;
            bool IsHere = false;
            for (int i = 0; i < a.elements.Length; i++)
            {
                if (a.elements[i] != 0)
                {
                    c.elements[counter] = a.elements[i];
                    counter++;
                }
            }
            for (int i = 0; i < b.elements.Length; i++)
            {
                if (b.elements[i] != 0)
                {
                    c.elements[counter] = b.elements[i];
                    counter++;
                }
            }

            return c.check();

        }
        public static Set operator *(Set a, Set b)
        {
            Set c;
            if (a.elements.Length < b.elements.Length)
            {
                c = new Set(a.elements.Length);

            }
            else
            {
                c = new Set(b.elements.Length);
            }
            int counter = 0;
            for (int i = 0; i < a.elements.Length; i++)
            {
                for (int k = 0; k < b.elements.Length; k++)
                {
                    if (a.elements[i] == b.elements[k] && a.elements[i] != 0)
                    {
                        c.elements[counter] = a.elements[i];
                        counter++;

                    }
                }
            }
            return c.check();
        }
        public static explicit operator int(Set a)
        {
            int counter = 0;
            for (int i = 0; i < a.elements.Length; i++)
            {
                if (a.elements[i] != 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static bool operator false(Set obj)
        {
            if (StatisticOperation.Amount(obj) < 3)
                return true;
            return false;
        }
        public static bool operator true(Set obj)
        {
            if (StatisticOperation.Amount(obj) > 2)
                return true;
            return false;
        }
    }
    public static class StatisticOperation
    {
        public static int Amount(Set obj)
        {
            int amount = 0;
            for (int i = 0; i < obj.elements.Length; i++)
            {
                if (obj.elements[i] != 0)
                {
                    amount++;
                }
            }
            return amount;
        }
        public static void Elements(Set obj)
        {
            for (int i = 0; i < obj.elements.Length; i++)
            {
                if (obj.elements[i] != 0)
                {
                    Console.Write(obj.elements[i]+ " ");
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //добавление элементов плюсом
            Set set = new Set(5);
            set = set + 2;
            set = set + 2;
            set = set + 5;
            set = set + 5;
            set = set + 6;
            
            Set set1 = new Set(5);
            set1 = set1 + 5;
            set1 = set1 + 6;
            set1 = set1 + 4;
            set1 = set1 + 4;
            
            //пересечение
            Set set2 = set * set1;
            StatisticOperation.Elements(set2);
            Console.WriteLine(StatisticOperation.Amount(set2));
            
            //объединение
            Set set3 = set + set1;
            StatisticOperation.Elements(set3);
            //false и true
            if (set3) 
            {
                Console.WriteLine(">2");
            }else Console.WriteLine("<3");


            Set set4 = new Set(5);
            set4 = set4 + 1;
            set4 = set4 + 3;
            set4 = set4 + 3;
            set4 = set4 + 4;
            StatisticOperation.Elements(set4);
            //int
            Console.WriteLine("Int()-количество элементов: "+(int)set4);

            Set.Owner owner = new Set.Owner();
            Console.WriteLine(owner.ToString());
            Set.Date date = new Set.Date();
            Console.WriteLine(date.ToString());


            "I LOVE OOP VERY MUCH".CommaAdd();
        }
    }
    
}
