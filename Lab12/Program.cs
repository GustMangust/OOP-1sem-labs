using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks.Dataflow;

namespace Lab12
{
    static class Reflector
    {
        public static void WriteInFile(Type type) 
        {
            string writePath = @"D:\Git\Labs\OOP\Lab12\lab.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                var assembly = type.Assembly;
                var construkt = type.GetConstructors();
                var methods = type.GetMethods();
                var fields = type.GetFields();
                var prop = type.GetProperties();
                var interfaces = type.GetInterfaces();
                sw.WriteLine(assembly);
                sw.WriteLine(construkt.Length);
                foreach (var item in methods)
                {
                    sw.Write(item.Name+" ");
                }
                sw.WriteLine();
                foreach (var item in fields)
                {
                    sw.Write(item.Name+" ");
                }
                sw.WriteLine();
                foreach (var item in prop)
                {
                    sw.Write(item.Name+" ");
                }
                sw.WriteLine();
                foreach (var item in interfaces)
                {
                    sw.Write(item.Name+" ");
                }
                sw.WriteLine();

            }
        }
        public static void GetMethodByParam(Type type, string param) 
        {
            var paramType = Type.GetType(param);
            var request = type.GetMethods().Where(i=>i.GetParameters().Any(item=>item.ParameterType == paramType));
            foreach (var item in request)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void CallMethod(object inputClass, string methodName) // вызывает некоторый метод класса, при этом значения для его параметров необходимо прочитать из текстового файла
        {
            var type = inputClass.GetType();
            var method = type.GetMethod(methodName);
            var parameterInformation = method.GetParameters();
            object[] paramFromFile = new object[1];

            using (StreamReader stream = new StreamReader(@"D:\Git\Labs\OOP\Lab12\s.txt"))
            {
                paramFromFile[0] = Int32.Parse(stream.ReadLine());
            }

            if (parameterInformation.Length == 1) // если у нас в функция принимает один параметр
            {
                method.Invoke(inputClass, paramFromFile);  // вызывем найденный у inputClass метод и передаем ему значение

            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Student stud = new Student();
            Reflector.WriteInFile(stud.GetType());
            Reflector.GetMethodByParam(stud.GetType(), "System.Int32");
            Reflector.CallMethod(stud, "Spis");
        }
    }
    
}
