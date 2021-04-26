using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Lab8
{
    interface ISet<T>
    {
        public void add(ref Set<T> a, T elem);
        public void delete(ref Set<T> a, int num);
        public void Elements(Set<T> a);
    }
    [Serializable]
    public class Set<T> : ISet<T> where T: notnull
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
        public T[] elements;
        public Set(int length)
        {
            elements = new T[length];

        }
        public void add(ref Set<T> a,T elem)
        {
            for(int i = 0; i < a.elements.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(a.elements[i],default)) 
                {
                    a.elements[i] = elem;
                    break;
                }
            }
        }
        public void delete(ref Set<T> a,int num)
        {
            a.elements[num] = default;
        }
        public void Elements(Set<T> obj)
        {
            for (int i = 0; i < obj.elements.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(obj.elements[i], default))
                { 
                    Console.Write(obj.elements[i] + " ");
                }
            }
            Console.WriteLine();
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set<string> set = new Set<string>(5);
            set.add(ref set,"Ivan");
            set.add(ref set,"Stepan");
            set.add(ref set,"Sasha");
            set.Elements(set);
            set.delete(ref set, 2);
            set.Elements(set);
            Set<int> set1 = new Set<int>(5);
            set1.add(ref set1, 2);
            set1.add(ref set1, 3);
            set1.add(ref set1, 4);
            set1.Elements(set1);
            set1.delete(ref set1, 2);
            set1.Elements(set1);


            Set<Human> set3 = new Set<Human>(5);
            Human tom = new Human("Tom",50,"Adams",'m');
            Human tom1 = new Human("Tom1",50,"Adams1",'f');

            set3.add(ref set3, tom);
            set3.add(ref set3, tom1);
            set3.Elements(set3);
            set3.delete(ref set3,1);
            set3.Elements(set3);

        }
    }

}
