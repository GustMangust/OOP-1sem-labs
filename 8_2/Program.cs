using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _8_2
{
    class CollisionException:Exception
    {
        public CollisionException()
        {
            Console.WriteLine($"Студент оказлся почти самым тупым, есть такой же. Что делать, хер знает");
        }
    }
    class Abiturient 
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int[] Marks = new int[4];
        public override bool Equals(object obj)
        {
            int counter = 0;
            Abiturient abit = obj as Abiturient;
            for(int i = 0; i < Marks.Length; i++) 
            {
                if(Marks[i] == abit.Marks[i]) 
                {
                    counter++;
                }
            }
            if (counter == 4) 
            {
                return true;
            }
            return false;
        }
        public int Sum() 
        {
            int sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += Marks[i];
            }
            return sum;
        }
    }
    class Fit 
    {
        public List<Abiturient> list = new List<Abiturient>(5);
        public const int countStudent = 5;
        public void Add(Abiturient abit) 
        {
            list.Add(abit);
        }
        public void Delete(Abiturient abit) 
        {
            list.Remove(abit);
        }
        public static Fit operator --(Fit fit) 
        {
            int min=10000;
            Abiturient badStudent = new Abiturient();

            foreach(Abiturient t in fit.list) 
            {
                if (t.Sum() <= min) 
                {
                    min = t.Sum();
                    badStudent = t;
                    Console.WriteLine($"{min}");
                }
            }
            Console.WriteLine(badStudent.Name);
            fit.list.Remove(badStudent);
            return fit;
        }
        public void AddExtend(Abiturient abit) 
        {
            if(list.Count == 5) 
            {
                foreach(Abiturient t in list) 
                {
                    if (abit.Sum() > t.Sum())
                    {
                        int min = 10000;
                        Abiturient badStudent = new Abiturient();
                        foreach (Abiturient b in list)
                        {

                            if (b.Sum() <= min)
                            {
                                min = b.Sum();
                                badStudent = b;
                            }
                        }
                        Console.WriteLine(badStudent.Name);
                        list.Remove(badStudent);
                        Console.WriteLine("FUCK YOU");
                        Add(abit);
                        break;
                    }
                    else if (abit.Sum() == t.Sum())
                    {
                        throw new CollisionException();
                    }
                    else
                    {
                        Console.WriteLine("Этот студент дэбил");
                    }
                }
            }
            else 
            {
                Add(abit);
            }
        }
    }
    static class Program 
    { 
        public static double Average(this Fit fit) 
        {
            double aver = 0;
            foreach(Abiturient t in fit.list) 
            {
                aver = aver + ((double)t.Sum()/4);
            }
            return aver/fit.list.Count;
        }
        static void Main(string[] args)
        {
            Abiturient abit1 = new Abiturient {Name = "1" };
            Abiturient abit2 = new Abiturient { Name = "2" };
            Abiturient abit3 = new Abiturient { Name = "3" };
            Abiturient abit4 = new Abiturient { Name = "4" };
            Abiturient abit5 = new Abiturient { Name = "5" };
            Abiturient abit6 = new Abiturient { Name = "6" };
            Abiturient abit7 = new Abiturient { Name = "7" };
            int a = 5;
            for(int i = 0; i < abit1.Marks.Length; i++) 
            {
                abit1.Marks[i] = 15+a;
                a += 4;
            }
            a = 5;
            for(int i = 0; i < abit2.Marks.Length; i++) 
            {
                abit2.Marks[i] = 15+a;
                a += 1;
            }
            a = 5;
            for (int i = 0; i < abit3.Marks.Length; i++) 
            {
                abit3.Marks[i] = 15+a;
                a += 2;
            }
            a = 5;
            for (int i = 0; i < abit4.Marks.Length; i++) 
            {
                abit4.Marks[i] = 15+a;
                a += 3;
            }
            a = 5;
            for (int i = 0; i < abit5.Marks.Length; i++) 
            {
                abit5.Marks[i] = 15+a;
                a += 5;
            }
            a = 5;
            for (int i = 0; i < abit6.Marks.Length; i++) 
            {
                abit6.Marks[i] = 15+a;
                a += 6;
            }
            a = 5;
            for (int i = 0; i < abit7.Marks.Length; i++) 
            {
                abit7.Marks[i] = 15+a;
                a += 1;
            }
            Fit fit = new Fit();
            fit.Add(abit1);
            Console.WriteLine(abit1.Sum());
            fit.Add(abit2);
            fit.Add(abit3);
            fit.Add(abit4);
            fit.Add(abit5);
            //fit.AddExtend(abit7);
            Console.WriteLine(fit.Average());
        }
    }
}
