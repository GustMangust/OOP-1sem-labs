using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    [Serializable]
    public abstract class Creature
    {
        public string name { get; set; }
        public int weight { get; set; }
        public abstract void move();
        public abstract void stop();
        public abstract void cry();
    }
    [Serializable]
    public class Human : Creature
    {
        public char sex { get; set; }
        public string surname { get; set; }
        [NonSerialized]
        public string faculty;
        public Human(string _name, int _weight, string _surname, char _sex)
        {
            name = _name;
            weight = _weight;
            sex = _sex;
            surname = _surname;
        }
        public Human(string _name, int _weight, string _surname, char _sex,string _faculty)
        {
            name = _name;
            weight = _weight;
            sex = _sex;
            surname = _surname;
            faculty = _faculty;
        }
        public Human() 
        {
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
    class Program
    {
        static void Main(string[] args)
        {

            //задание 1
            //а
            Human man = new Human("Jack", 50, "Wilshere", 'm');
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("1а.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, man);

                Console.WriteLine("Объект сериализован BINARY");
            }
            using (FileStream fs = new FileStream("1а.dat", FileMode.OpenOrCreate))
            {
                Human newPerson = (Human)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.name} Фамилия: {newPerson.surname}");
            }
            //b
            /*
            SoapFormatter formatter1 = new SoapFormatter();

            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, man);

                Console.WriteLine("Объект сериализован SOAP");
            }
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                Human newPerson = (Human)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.name}Фамилия: {newPerson.surname}");

            }*/
            //c
            Human man1 = new Human("Jack1", 50, "Wilshere1", 'm',"FIT");
            string json = JsonSerializer.Serialize<Human>(man1);
            Console.WriteLine("Объект сериализован JSON");
            Console.WriteLine(json);
            Human newPerson1 = JsonSerializer.Deserialize<Human>(json);
            Console.WriteLine("Объект десериализован");
            Console.WriteLine($"Имя: {newPerson1.name} Фамилия: {newPerson1.surname}");
            //d
            XmlSerializer formatter2 = new XmlSerializer(typeof(Human));
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, man);

                Console.WriteLine("Объект сериализован XML");
            }
            // десериализация
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Human newPerson2 = (Human)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson2.name} Возраст: {newPerson2.surname}");
            }
            //Задание 2
            List<Human> list = new List<Human>();
            Human man4 = new Human("Jack4", 50, "Wilshere4", 'm');
            list.Add(man);
            list.Add(man1);
            list.Add(man4);
            BinaryFormatter formatter4 = new BinaryFormatter();
            using (FileStream fs = new FileStream("2.dat", FileMode.OpenOrCreate))
            {
                formatter4.Serialize(fs, list);

                Console.WriteLine("Объект List сериализован BINARY");
            }
            using (FileStream fs = new FileStream("2.dat", FileMode.OpenOrCreate))
            {
                List<Human> newList = (List<Human>)formatter4.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{newList}");
            }
            //Задание 3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Git\Labs\OOP\Lab14\XML.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            childnodes = xRoot.SelectNodes("user");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            XmlNode childnode = xRoot.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);

            //Задание 4
            XDocument xdoc = new XDocument();
            XElement iphone6 = new XElement("phone");
            XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
            XElement iphoneCompanyElem = new XElement("company", "Apple");
            XElement iphonePriceElem = new XElement("price", "40000");
            iphone6.Add(iphoneNameAttr);
            iphone6.Add(iphoneCompanyElem);
            iphone6.Add(iphonePriceElem);

            XElement galaxys5 = new XElement("phone");
            XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            XElement galaxysCompanyElem = new XElement("company", "Samsung");
            XElement galaxysPriceElem = new XElement("price", "33000");
            galaxys5.Add(galaxysNameAttr);
            galaxys5.Add(galaxysCompanyElem);
            galaxys5.Add(galaxysPriceElem);
            XElement phones = new XElement("phones");
            phones.Add(iphone6);
            phones.Add(galaxys5);
            xdoc.Add(phones);
            xdoc.Save("phones.xml");

            XDocument xdoc1 = XDocument.Load("phones.xml");
            foreach (XElement phoneElement in xdoc1.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}
