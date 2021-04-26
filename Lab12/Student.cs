using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab12
{
    public partial class Student
    {
        public static int amount;
        public int id { get; }
        public string surname { get; set; } = "Petrov";
        public string name { get; set; } = "Oleksiy";
        public string otch { get; set; } = "Ivanovich";
        private int _year;
        public int year { get; set; }

        private int _month;
        public int month
        {
            get
            {
                return _month;
            }
            set
            {
                if (value > 0 && value < 13)
                {
                    _month = value;
                }
                else { Console.WriteLine("Please, enter correct information"); }
            }
        }
        private int _day;
        public int day
        {
            get
            {
                return _day;
            }
            set
            {
                if (value > 0 && value < 32)
                {
                    _day = value;
                }
                else
                {
                    Console.WriteLine("Please, enter correct information");
                }
            }
        }
        private long _phone;
        public long phone
        {
            get
            {

                return _phone;
            }
            set
            {
                if (value <= 999999999999 && value >= 100000000000)
                {
                    _phone = value;
                }
                else
                {
                    Console.WriteLine("Please, enter correct information");
                }
            }
        }
        /*static Student()
        {
            amount = 0;
        }*/
        public Student()
        {
            id = GetHashCode();
            amount++;
        }
        private Student(string surname, string name)
        {
            this.surname = surname;
            this.name = name;
            id = GetHashCode();
            amount++;
        }
        public Student(string surname, int kurs, string faculty, int group, int age)
        {
            this.surname = surname;
            this.kurs = kurs;
            this.faculty = faculty;
            this.gruppa = group;
            this.year = age;
            id = GetHashCode();
            amount++;
        }
        public static Student Construktor(string surname, string name)
        {
            return new Student(surname, name);
        }
        public int gruppa { get; set; }
        public string faculty { get; set; }
        public int kurs { get; set; }
    }
    public partial class Student
    {
        public int Age(int year)
        {
            return 2020 - year;
        }
        public static void Fac(string faculty, Student[] studarray)
        {
            Console.WriteLine($"Список студентов \"{faculty}\"");
            foreach (Student a in studarray)
            {
                if (a.faculty == faculty)
                {
                    Console.Write(a.surname + " ");
                    Console.Write(a.name + " ");
                    Console.WriteLine(a.otch);
                }

            }
        }
        public static void Spis(int gr, Student[] studarray)
        {
            Console.WriteLine($"Список студентов \"{gr}\" группы");
            foreach (Student a in studarray)
            {
                if (a.gruppa == gr)
                {
                    Console.Write(a.surname + " ");
                    Console.Write(a.name + " ");
                    Console.WriteLine(a.otch);
                }

            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Student m = obj as Student;
            if (m as Student == null)
                return false;

            return m.name == this.name && m.surname == this.surname;
        }
        public override int GetHashCode()
        {
            Encoding u16LE = Encoding.Unicode;
            Random rand = new Random();
            int iBC = u16LE.GetByteCount(surname) * rand.Next(0, 50000);

            return iBC;
        }
        public override string ToString()
        {
            return "Student: " + name + " " + surname + " " + faculty;
        }
        public void A(string param) 
        {
            Console.WriteLine($"Вызван метод {param}") ;
        }
    }
}
