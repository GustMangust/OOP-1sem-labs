using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{

    public class HumanException : Exception
    {
        public HumanException(string message)
            : base(message)
        { }
    }

    public class TransformerException : Exception
    {
        public TransformerException(string message, int weight)
            : base(message)
        {
            Console.WriteLine($"Вы указали вес в {weight} тонн");
        }
    }

    public class CarException : Exception
    {
        public CarException(string message, int max_speed)
            : base(message)
        {
            Console.WriteLine($"Вы указали максимальную скорость в {max_speed} км/ч");
        }
    }
}