using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class ArmyController
    {
        public static void FindYearObj(Army army,int year) 
        {
            Human human = new Human();
            Transformer trans = new Transformer();
            Boolean flag = false;
            for(int i = 0; i < army.list.Count; i++) 
            {
                if (army.list[i].GetType() == human.GetType())
                {
                    human = (Human)army.list[i];
                    if(human.year == year) 
                    {
                        flag = true;
                        Console.WriteLine(human);
                    }
                }
                if (army.list[i].GetType() == trans.GetType())
                {
                    trans = (Transformer)army.list[i];
                    if (trans.year == year)
                    {
                        flag = true;
                        Console.WriteLine(trans);
                        Console.WriteLine();
                    }
                }
            }
            if (!flag) 
            {
                Console.WriteLine("Нет таких элементов");
                Console.WriteLine();
            }
        }
        public static void NameTrans(Army army,string name) 
        {
            Transformer trans = new Transformer();
            Boolean flag = false;
            for (int i = 0; i < army.list.Count; i++)
            {
                if (army.list[i].GetType() == trans.GetType())
                {
                    trans = (Transformer)army.list[i];
                    if (trans.name == name)
                    {
                        flag = true;
                        Console.WriteLine(trans);
                        Console.WriteLine();
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Нет таких элементов");
                Console.WriteLine();
            }
        }
        public static void AmountUnits(Army army) 
        {
            Console.WriteLine(army.list.Count);
            Console.WriteLine();
        }
    }
}
