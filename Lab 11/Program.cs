using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab_11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //задание 1
            string[] a = {"June", "July", "August","December", "January","March","April","May","September","October","November","February" };
            var selectedMonths = from t in a
                                 where t.Length == 4
                                 select t;
            foreach (string s in selectedMonths)
                Console.WriteLine(s);
            Console.WriteLine();
            var selectedSpecMonths = from t in a
                                 where t == "June" || t == "July" || t == "August" || t == "December" || t == "January" || t == "February"
                                 select t;
            foreach (string s in selectedSpecMonths)
                Console.WriteLine(s);
            Console.WriteLine();
            var selectedMonthsOrdered = from t in a
                                        orderby t
                                        select t;
            foreach (string s in selectedMonthsOrdered)
                Console.WriteLine(s);
            Console.WriteLine();
            var selectedMonths2 = from t in a
                                  where t.Contains("u") && t.Length >=4
                                  select t;
            foreach (string s in selectedMonths2)
                Console.WriteLine(s);
            Console.WriteLine();

            //задание 2
            List<Student> b = new List<Student>();
            Student stud3 = new Student("Vasilevich", 1, "FIT", 8,18);
            Student stud4 = new Student("Ivanov",  1, "FIT", 9,19);
            Student stud5 = new Student("Petrov", 1, "HTIT", 11,19);
            Student stud6 = new Student("Kuznetsov", 1, "PIM", 12,20);
            Student stud7 = new Student("Petrov", 1, "LH", 13,18);
            Student stud8 = new Student("Sokolov", 1, "LH", 13,19);
            Student stud9 = new Student("Vasilev", 1, "HTIT", 12,17);
            Student stud2 = new Student("Vasilev", 1, "LH", 2,40);
            Student stud10 = new Student("Smirnov", 1, "LH", 12,18);
            b.Add(stud2);
            b.Add(stud3);
            b.Add(stud4);
            b.Add(stud5);
            b.Add(stud6);
            b.Add(stud7);
            b.Add(stud8);
            b.Add(stud9);
            b.Add(stud10);
            //задание 3
            var selectedStud1 = from t in b
                                  where t.faculty == "LH"
                                  orderby t.surname
                                  select t;
            foreach (Student s in selectedStud1)
                Console.WriteLine(s.surname);
            Console.WriteLine();
            var selectedStud2 = from t in b
                                where t.faculty == "LH" && t.gruppa  ==  12 
                                  select t;
            foreach (Student s in selectedStud2)
                Console.WriteLine(s.surname);
            Console.WriteLine();
            var selectedStud3 = from t in b
                                where t.year == b.Min(g => g.year)
                                select  t;
            foreach (Student s in selectedStud3)
                Console.WriteLine(s.surname);
            Console.WriteLine();
            var selectedStud4 = from t in b
                                where t.surname == "Vasilev"
                                select  t;
            var selectedStud4mod = selectedStud4.First();
            Console.WriteLine(selectedStud4mod);
            Console.WriteLine();

            var selectedStud5 = from t in b
                                where (t.faculty == "LH" || t.faculty == "HTIT" || t.faculty == "FIT" || t.faculty == "PIM") && b.Any()
                                orderby t.surname
                                group t by t.faculty;
            foreach (IGrouping<string, Student> g in selectedStud5)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.surname);
                Console.WriteLine();
            }


            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }
    }
}
