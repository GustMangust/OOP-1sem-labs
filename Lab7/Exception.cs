using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CreatingClassException : Exception
    {
        private string message, field;
        public CreatingClassException(object obj)
        {
            field = "-";
            Source = obj.GetType().ToString();
            message = "На конструктор было подано null значение";
        }
        public CreatingClassException(object obj, Type fieldType)
        {
            field = fieldType.ToString();
            Source = obj.GetType().ToString();
            message = "На конструктор было подано неверное значение";
        }
        public string GetMessage => message;
        public string WhatData => field;
    }
    class OutofRangeException : Exception
    {
        private string message;
        private int usedindex, range;
        private long outvalue;
        public OutofRangeException(long value)
        {
            if (value > 0)
                outvalue = value - int.MaxValue;
            if (value < 0)
                outvalue = int.MinValue - value;
            usedindex = 0;
            range = 0;
            message = "Выход за пределы типа значения";
        }
        public OutofRangeException(int value, int arrlength)
        {
            usedindex = value;
            range = arrlength;
            outvalue = 0;
            message = "Выход за пределы размера массива";
        }
        public string GetMessage => message;
        public long OutValue => outvalue;
        public int OutRange
        {
            get
            {
                if (usedindex < 0)
                    return usedindex;
                return usedindex - range;
            }
        }
    }
    class ArithmeticException : Exception
    {
        private string message;
        public ArithmeticException()
        {
            message = "Арифметическая ошибка";
        }
        public string GetMessage => message;
    }
}