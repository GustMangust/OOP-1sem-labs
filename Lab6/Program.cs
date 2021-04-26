using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Lab6
{   
    enum Brends
    {
        one = 1,
        two,
        three,
        four,
        five,
        six,
        seven
    }
    struct Boys 
    {
        public string name;
        public int age;
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
    abstract partial class Creature
    {
        public string name { get; set; }
        

        public int year { get; set; }
    }
    class Human : Creature
    {
        
        public char sex { get; set; }
        private string surname;
        public string Surname {
            get 
            {
                return surname;
            }
            set 
            {
                if(value.Length >=25 || value.Length < 2) 
                {
                    throw new HumanException("Длина фамилии может быть в пределах от 2 до 25 символов");
                }
                else 
                {
                    surname = value;
                }
            }
        }
        public Human(string _name, string _surname, char _sex,int _year)
        {
            name = _name;
            sex = _sex;
            surname = _surname;
            year = _year;
        }
        public Human() { }
        public override void move()
        {
            Console.WriteLine("Human moves");
        }
        public override void stop()
        {
            Console.WriteLine("Human stopes");
        }
        public override void cry()
        {
            Console.WriteLine("Human cries");
        }
        public override string ToString()
        {
            return name +" "+surname;
        }
    }
    class Transformer : Creature, ICar
    {
        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value> 100 || value <= 0)
                {
                    throw new TransformerException("Масса должна быть меньше либо равна 100 и больше 0", value);
                }
                else
                {
                    weight = value;
                }
            }

        }
        public string car_model { get; set; }
        public Transformer() { }
        public Transformer(string _name, int _weight, string _car_model,int _year)
        {
            name = _name;
            Weight = _weight;
            car_model = _car_model;
            year = _year;
        }
        public override void move()
        {
            Console.WriteLine("Transformer moves");
        }
        public override void stop()
        {
            Console.WriteLine("Transformer stopes");
        }
        public override void cry()
        {
            Console.WriteLine("Transformer cries");
        }
        void ICar.move()
        {
            Console.WriteLine("Transformer moves");
        }
        void ICar.stop()
        {
            Console.WriteLine("Transformer stopes");
        }
        public void open_door()
        {
            Console.WriteLine("Transformer opens door");
        }
        public override string ToString()
        {
            return name;
        }
    }
    abstract class Vehicle
    {
        public int seats { get; set; }
        public int weight { get; set; }
        public abstract void move();
    }
    interface ICar
    {
        void move();
        void stop();
        void open_door();
    }

    class Car : Vehicle, ICar
    {
        private int max_speed;
        public int Max_speed 
        {
            get 
            {
                return max_speed;
            }
            set 
            {
                if(value >= 400 || value <= 0) 
                {
                    throw new CarException("Максимальная скорость должна быть от 1 до 400 км/ч", value);
                }
                else 
                {
                    max_speed = value;
                }
            } 
        }
        public string brand { get; set; }
        public string form_factor { get; set; }
        public string type { get; set; }
        public Car()
        {
        }
        public Car(string _brand, string _form_factor, string _type, int _max_speed, int _seats, int _weight)
        {
            type = _type;
            brand = _brand;
            form_factor = _form_factor;
            max_speed = _max_speed;
            seats = _seats;
            weight = _weight;
        }
        public override void move()
        {
            Console.WriteLine("Car moves(abstract)");
        }
        void ICar.move()
        {
            Console.WriteLine("Car moves(interface)");
        }
        public void stop()
        {
            Console.WriteLine("Сar stopes");
        }
        public void open_door()
        {
            Console.WriteLine("Car opens door");
        }
        public override string ToString()
        {
            return brand;
        }
    }
    sealed class Engine
    {
        public string type { get; set; }
        public int capacity { get; set; }
        public int power { get; set; }
        public Engine(string _type, int _capacity, int _power)
        {
            type = _type;
            capacity = _capacity;
            power = _power;
        }
        public override string ToString()
        {
            return "Type: " + type + '\n' + "Capacity: " + capacity + "liters" + '\n' + "Power: " + type + " horsepower" + '\n';
        }
    }
    class Printer
    {
        public void iAmPrinting(ICar obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                try{Transformer trans = new Transformer {Weight=-5};}
                catch(TransformerException ex) {Console.WriteLine("Error: "+ex.Message);}
                try { Human hum = new Human { Surname = "a" }; }
                catch (HumanException ex) { Console.WriteLine("Error: " + ex.Message); }
                try { Car car = new Car {Max_speed = -3 }; }
                catch (CarException ex) { Console.WriteLine("Error: " + ex.Message); }
                try { int x = 0; int c = 10 / x; } catch (DivideByZeroException ex) { Console.WriteLine("Error: " + ex.Message); }
                int[] y = new int[10];
                y[15] = 2;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine($"Place of error: {ex.InnerException}");
                Console.WriteLine($"{ex.StackTrace}");
            }
            catch
            {
                Console.WriteLine($"Универсальный обработчик\n");
            }
            finally
            {
                int index;
                index = -40;
                Debug.Assert(index > -1, "Индекс массива должен быть больше или равен нулю!");
                Console.WriteLine($"Выполнение программы завершено!");
            }
        }
    }
}
