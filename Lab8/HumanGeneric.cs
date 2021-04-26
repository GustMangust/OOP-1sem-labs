using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab8
{
    abstract class Creature
    {
        public string name { get; set; }
        public int weight { get; set; }
        public abstract void move();
        public abstract void stop();
        public abstract void cry();
    }
    class Human : Creature
    {
        public char sex { get; set; }
        public string surname { get; set; }
        public Human(string _name, int _weight, string _surname, char _sex)
        {
            name = _name;
            weight = _weight;
            sex = _sex;
            surname = _surname;
        }
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
            return "Sex: " + sex + '\n' + "Name: " + name + '\n' + "Surname:" + surname + '\n' + "Weight:" + weight + "t " + '\n';
        }
    }
    class Transformer : Creature, ICar
    {
        public string car_model { get; set; }
        public Transformer(string _name, int _weight, string _car_model)
        {
            name = _name;
            weight = _weight;
            car_model = _car_model;
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
            return "Car model: " + car_model + '\n' + "Name: " + name + '\n' + "Weight:" + weight + "t " + '\n';
        }
    }
    abstract class Vehicle
    {
        public int max_speed { get; set; }
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

        public string brand { get; set; }
        public string form_factor { get; set; }
        public string type { get; set; }
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
            return "Brand: " + brand + '\n' + "Form-factor: " + form_factor + '\n' + "Type:" + type + '\n' + "Max speed:" + max_speed + '\n' + "Seats:" + seats + '\n' + "Weight:" + weight + "t " + '\n';
        }
    }
}
