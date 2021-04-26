using System;
using System.Linq;

namespace Lab9
{
    class Director
    {
        delegate void Func(ref int num);
        public static void Raise(object sender,EventArgs eventArgs) 
        {
            if(sender is Tokar) 
            {
                Tokar tokar = (Tokar)sender;
                if(tokar.Category >= 5) 
                {
                    Func function = (ref int x) => { x += 50;  Console.WriteLine("Повышен! Зарплата увеличена"); Console.WriteLine("Зарплата: " + tokar.Salary); };

                    function(ref tokar.Salary);
                }
                else 
                {
                    Console.WriteLine("Не в этот раз! Повышайте разряд!");
                }
            }
            if(sender is Student) 
            {
                Student student = (Student)sender;
                if(student.AverageScore >= 7)
                {
                    Func function = (ref int x) => { x += 20; Console.WriteLine("Молодец! Стипендия увеличена"); Console.WriteLine("Стипендия: " + student.Grant); };

                    function(ref student.Grant);
                    
                }
                else
                { 
                    Console.WriteLine("Не в этот раз! Учитесь лучше!");
                }
            }
        }
        public static void Penalty(object sender, EventArgs eventArgs)
        {
            if (sender is Tokar)
            {
                Tokar tokar = (Tokar)sender;
                if (tokar.Name == "Ivan")
                {
                    Console.WriteLine("Штраф! Мне не нравится ваше имя...");
                    tokar.Salary -= 50;
                    Console.WriteLine("Зарплата: " + tokar.Salary);
                }
                else
                {
                    Console.WriteLine($"Классное имя, {tokar.Name}!");
                }
            }
            if (sender is Student)
            {
                Student student = (Student)sender;
                if (student.AverageScore < 5)
                {
                    Console.WriteLine($"Нет у тебя больше стипендии, {student.Name}");
                    student.Grant = 0;
                    Console.WriteLine("Стипендия: "+student.Grant);
                }
                else
                {
                    Console.WriteLine($"Ты хорошо учишься, {student.Name}!");
                }

            }
        }

    }
    public class Tokar
    {
        public event EventHandler raise;
        public event EventHandler penalty;
        public string Name;
        public int Category;
        public int Salary;
        public Tokar(string name,int category,int salary) 
        {
            Name = name;
            Category = category;
            Salary = salary;
        }
        public void AskRaising() 
        {
            raise(this, new EventArgs { });
        }
        public void GetPenalty() 
        {
            penalty(this, new EventArgs { });
        }
    }
    public class Student
    {
        public event EventHandler raise;
        public event EventHandler penalty;
        public string Name;
        public int AverageScore;
        public int Grant;
        public Student(string name, int averageScore, int grant)
        {
            Name = name;
            AverageScore = averageScore;
            Grant = grant;
        }
        public void AskRaising()
        {
            raise(this, new EventArgs { });
        }
        public void GetPenalty()
        {
            penalty(this, new EventArgs { });
        }
    }
    class Program
    {
        delegate string StringMethods(string str);
        static void Main(string[] args)
        {
            Tokar tokar1 = new Tokar("Stepan", 5, 200);
            Student student1 = new Student("Misha", 7, 70);
            tokar1.raise += Director.Raise;
            student1.raise += Director.Raise;
            tokar1.AskRaising();
            student1.AskRaising();
            



            Tokar tokar2 = new Tokar("Ivan", 3, 200);
            Student student2 = new Student("Gena", 4, 70);
            tokar2.raise += Director.Raise;
            tokar2.penalty += Director.Penalty;
            student2.raise += Director.Raise;
            student2.penalty += Director.Penalty;
            tokar2.GetPenalty();
            student2.GetPenalty();

            string str = Console.ReadLine();
            StringMethods meth;
            meth = DeletePunctuationMarks;
            meth += DeleteChars;
            meth += AddChars;
            meth += ToUpperCase;
            meth += DeleteSpaces;
            meth(str);

        }
        public static string DeletePunctuationMarks(string str)
        {
            char[] pattern = new char[6] { '.', ',', ':', ';', '?', '!' };
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!pattern.Contains(strArray[i])) outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }

        public static string DeleteChars(string str)
        {
            Console.WriteLine($"Введите то кол-во символов которое вы хотите удалить");
            int numberOfChars = Int32.Parse(Console.ReadLine());
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length - numberOfChars; i++)
            {
                outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }

        public static string AddChars(string str)
        {
            Console.WriteLine($"Введите то кол-во символов которое вы хотите добавить к строке");
            int numberOfChars = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Введите символ");
            char insertChar = Char.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfChars; i++)
            {
                str += insertChar;
            }
            Console.WriteLine($"Результат: {str}");
            return str;
        }

        public static string ToUpperCase(string str)
        {
            Console.WriteLine($"Результат: {str.ToUpper()}");
            return str.ToUpper();
        }

        public static string DeleteSpaces(string str)
        {
            char pattern = ' ';
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != pattern) outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }
    }
}
