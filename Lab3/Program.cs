using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab3
{
    public partial class Student
    {
        public static int amount;
        public int id { get; }
        public string surname { get; set; } = "Petrov";
        public string name { get; set; } = "Oleksiy";
        public string otch { get; set; } = "Ivanovich";
        private int _year;
        public int year 
        {
            get 
            {
                return _year;
            }
            set 
            {
                if(value > 1900 && value < 2010) 
                { 
                    _year = value;
                }
                else { Console.WriteLine("Please, enter correct information"); }
            }
        }
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
        static Student() 
        {
            amount = 0;
            Console.WriteLine("Статический конструктор вызван");
        }
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
        public Student(string surname,string name,string otch, int kurs, string faculty, int group) 
        {
            this.surname = surname;
            this.name = name;
            this.otch = otch;
            this.kurs = kurs;
            this.faculty = faculty;
            this.group = group;
            id = GetHashCode();
            amount++;
        }
        public static Student Construktor(string surname, string name)
        {
            return new Student(surname,  name);
        }
        public int group { get; set; }
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
                if (a.group == gr)
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
            int iBC = u16LE.GetByteCount(surname) * rand.Next(0,50000);
            
            return iBC;
        }
        public override string ToString()
        {
            return "Student: " + name + " " + surname + " " + faculty;
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                var stud = Student.Construktor("Vasilevich", "Sergey");
                var stud1 = Student.Construktor("Ivanov", "Dmitry");
                var stud2 = Student.Construktor("Ivanov", "Dmitry");
                Student[] studarray = new Student[8];
                Student stud3 = new Student("Vasilevich", "Sergey", "Aleksandrovic", 1, "FIT", 8);
                Student stud4 = new Student("Ivanov", "Dmitry", "Sergeevich", 1, "FIT", 9);
                Student stud5 = new Student("1", "2", "3", 1, "HTIT", 11);
                Student stud6 = new Student("4", "5", "6", 1, "PIM", 12);
                Student stud7 = new Student("Surname", "Name", "Otch", 1, "LH", 13);
                Student stud8 = new Student("Surname1", "Name1", "Otch1", 1, "LH", 13);
                Student stud9 = new Student("Surname2", "Name2", "Otch2", 1, "LH", 13);
                Student stud10 = new Student("Surname3", "Name3", "Otch3", 1, "LH", 13);

                studarray[0] = stud3;
                studarray[1] = stud4;
                studarray[2] = stud5;
                studarray[3] = stud6;
                studarray[4] = stud7;
                studarray[5] = stud8;
                studarray[6] = stud9;
                studarray[7] = stud10;
                stud3.year = 2001;
                stud3.month = 10;
                stud3.day = 7;
                Console.WriteLine("Работа ту стринг");
                Console.WriteLine(stud3.ToString());
                string fac;
                Console.WriteLine("Input faculty");
                fac = Console.ReadLine();
                Student.Fac(fac, studarray);
                int gr;
                Console.WriteLine("Input Group");
                gr = Convert.ToInt32(Console.ReadLine());
                Student.Spis(gr, studarray);



                
                Console.WriteLine($"Нахождение возраста третьего студента. Год рождения {stud3.year}");

                Console.WriteLine(stud3.Age(stud3.year));
                var studanon = new { surname = "Surname3", name = "Name3", otch = "Otch3" };
                Console.WriteLine("Aнонимный тип" + "\n" + studanon.GetType());
                Console.WriteLine("Количество студентов: " + Student.amount);
                Console.WriteLine(stud.id);
                Console.WriteLine(stud1.id);
                Console.WriteLine(stud2.id);
                Console.WriteLine(stud3.id);

            }
        }
}
