using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _3_2
{
    class Location 
    {
        public int lat;
        public int longitude;
        public int speed;
    }
    class Taxi 
    {
        public string number;
        public Location location;
        public enum Status 
        {
            Busy,
            Free
        }
        public double Way(int x, int y)
        {
            return Math.Sqrt(Math.Pow((double)(location.lat - x), 2) + Math.Pow((double)(location.longitude - y), 2));
        }
    }
    class Park<T>:Taxi
    {
        public List<T> list = new List<T>();
        public void Add(T item) 
        {
            list.Add(item);
        }
        public void Delete(T item) 
        {
            list.Remove(item);
        }
        public void Clear() 
        {
            list.Clear();
        }
        public T Find(Predicate<T> predicate) 
        {
            foreach(T it in list) 
            {
                if (predicate(it)) 
                {
                    Console.WriteLine("Объект найден");
                    return it;
                }
            }
            return default(T);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<Taxi> taxiPred = delegate (Taxi x) { return x.location.speed > 30; };
            Park<Taxi> uber = new Park<Taxi>();
            Taxi taxi1 = new Taxi {number = "1234",location = new Location {lat = 25,longitude=100,speed=35 } };
            Taxi taxi2 = new Taxi {number = "5678",location = new Location {lat = 36,longitude=124,speed=30 } };
            Taxi taxi3 = new Taxi {number = "9123",location = new Location {lat = 47,longitude=147,speed=25 } };
            Taxi taxi4 = new Taxi {number = "4567",location = new Location {lat = 58,longitude=166,speed=70 } };
            uber.Add(taxi1);
            uber.Add(taxi2);
            uber.Add(taxi3);
            uber.Add(taxi4);
            int x =  Convert.ToInt32(Console.ReadLine());
            int y =  Convert.ToInt32(Console.ReadLine());
            var uber1 = from t in uber.list
                        orderby t.Way(x,y)
                        select t;
            foreach(Taxi t in uber1) 
            {
                Console.WriteLine(t.Way(x,y));
            }
            int counter = 0;
            foreach (Taxi t in uber1)
            {
                if(counter == 0) 
                {
                    Console.WriteLine(t.Way(x,y));
                    counter++;
                }
                
            }
        }
    }
}
