using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection.Emit;
using System.Linq;

namespace _8_1
{
    class Item 
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Price { get; set; }
    }
    class Shop: IEnumerable
    {
        public event EventHandler sale;
        public Queue<Item> items = new Queue<Item>();
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public void Add(Item item) 
        {
            items.Enqueue(item);
            if(items.Count > 4) 
            {
                sale(item,new EventArgs{ });
            }
        }
        public void Delete() 
        {
            items.Dequeue();
        }
        public void Clear() 
        {
            items.Clear();
        }
        public override string ToString()
        {
            return $"Очередь с количеством элементов = {items.Count}";
        }
        public override int GetHashCode()
        {
            return items.Count * 27 + 34;
        }
        public static Shop operator +(Shop a, Item b) 
        {
            a.Add(b);
            return a;
        }
        public static Shop operator -(Shop a)
        {
            a.items.Dequeue();
            return a;
        }
    }
    class Manager 
    {
        public static void Sale(Object sender,EventArgs eventArgs) 
        {
            Item item = (Item)sender;
            item.Price /= 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Item item1 = new Item { Price = 10, Name = "1" };
            Item item2 = new Item { Price = 20, Name = "1" };
            Item item3 = new Item { Price = 30, Name = "2" };
            Item item4 = new Item { Price = 40, Name = "3" };
            Item item5 = new Item { Price = 50, Name = "4" };
            shop.sale += Manager.Sale;
            shop.Add(item1);
            shop.Add(item2);
            shop.Add(item3);
            shop.Add(item4);
            int linq = (from t in shop.items
                       where t.Name == "1"
                       select t.Price).Sum();
            Console.WriteLine(linq);
            Console.WriteLine(shop.ToString());
            Console.WriteLine(shop.GetHashCode());
            Console.WriteLine(shop.GetEnumerator()); 
            shop = shop + item5;
            Console.WriteLine(shop.GetHashCode());
            //shop = -shop;
            Console.WriteLine(shop.GetHashCode());
            foreach(Item it in shop.items) 
            {
                Console.WriteLine(it.Price);
            }

        }
    }
}
