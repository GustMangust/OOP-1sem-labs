using System;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void VVOD()
        {
            bool a = true;
            byte b = Convert.ToByte(Console.ReadLine());
            sbyte c = Convert.ToSByte(Console.ReadLine());
            char d = Convert.ToChar(Console.ReadLine());
            decimal e = Convert.ToDecimal(Console.ReadLine());
            double f = Convert.ToDouble(Console.ReadLine());
            float g = Convert.ToSingle(Console.ReadLine());
            int h = Convert.ToInt32(Console.ReadLine());
            uint i = Convert.ToUInt32(Console.ReadLine());
            long j = Convert.ToInt64(Console.ReadLine());
            ulong k = Convert.ToUInt64(Console.ReadLine());
            short l = Convert.ToInt16(Console.ReadLine());
            ushort m = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(h);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(k);
            Console.WriteLine(l);
            Console.WriteLine(m);
            Console.ReadKey();
        }
       static void CONVERT()
        {
            int a = 123123412;
            long al = a;
            byte b = 125;
            short bs = b;
            int c = 45665;
            ushort aaa = b;
            uint aaaaaa = b;
            float jhhghgjjc = 1.5f;
            double hdhgfg = jhhghgjjc;
            Console.ReadKey();

        }
        static void UNPACK_PACK()
        {
            //UNPACK
            object a = 1.5f;
            float b = (float)a;
            //PACK
            ushort j = 156;
            object fgfdh = j;
            Console.ReadKey();
        }
        static void UNBELIEVABLE()
        {
            var fg = "OOP is the best";
            string fd = "Yes";
            Console.WriteLine(fg + fd);
            Console.ReadKey();
        }
        static void NOLABLE()
        {
            int? z1 = null;
            Nullable<int> z2 = null;
            Console.ReadKey();
        }
        static void VAR()
        {
            var fd = 6;
            //fd = "ERROROROROROROROOROROR";
            //fd = Convert.ToInt32("ERROROROROROROROOROROR");
            Console.ReadKey();
        }
        static void STRONG()
        {
            char j = 'a';
            int a = 7;
            int b = 8;
            char dfsh = 'k';
            if (j == dfsh) Console.WriteLine("YEEEEEEEEEEEE");
            else Console.WriteLine("NOOOOOOOOOOOOO");
            string lg = "yes";
            string lk = "no";
            string lk1 = "nos";
            string apple = "its revolution";
            string apple1;

            Console.WriteLine("KONKAT: " + lg + lk);

            lk1 = String.Copy(lk);
            Console.WriteLine("COPY: " + lg);

            string sub = apple.Substring(0, 3);
            Console.WriteLine("SUBSTRING:"+sub);

            string[] appleSplit = apple.Split(" ");
            Console.WriteLine("SPLIT: " + appleSplit[1] + appleSplit[0]);

            apple1 = lk1.Insert(1," ");
            Console.WriteLine("INSERT: " + apple1);
            
            apple = apple.Remove(0, 6);
            Console.WriteLine("REMOVE: " + apple);

            string aaa = $"apple{a*b}";
            Console.WriteLine("INTERPOLATE: " + aaa);

            string nulev = null;
            Console.WriteLine(String.IsNullOrEmpty(nulev));
            ///////////////////////////////////////////////


            StringBuilder builder = new StringBuilder();
            builder.Append("I love OOP");
            builder.Remove(0, 2);
            Console.WriteLine(builder);
            builder.Insert(0, "You ");
            builder.Insert(builder.Length, " very well");
            Console.WriteLine(builder);
            Console.ReadKey();

        }
        static void arr() 
        {
            int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
            foreach (int i in a) Console.WriteLine($"Array: {i}");
            string[] b = { "abc", "def","ghi","jkl" };
            Console.WriteLine("Dlina: "+b.Length);
            foreach (string i in b) Console.WriteLine($"Array str: {i}");
            int t = Convert.ToInt32(Console.ReadLine());
            int t1 = Convert.ToInt32(Console.ReadLine());
            var t2 = b[t];
            b[t] = b[t1];
            b[t1] = t2;

            int[][] c = new int[3][];
            c[0] = new int[2];
            c[1] = new int[3];
            c[2] = new int[4];
            for (int i = 0; i < 2; i++)
            {
                c[0][i] = i;
                Console.Write("{0}\t", c[0][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                c[1][i] = i;
                Console.Write("{0}\t", c[1][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                c[2][i] = i;
                Console.Write("{0}\t", c[2][i]);
            }

            Console.WriteLine();


            var g = new int[5];
            var p = "new str";
        }
        static void kor() 
        {
            (int a, string b, char c, string d, ulong e) a = (5, "sss", 's', "sss", 155644);
            Console.WriteLine(a);
            Console.WriteLine(a.Item2);
            Console.WriteLine(a.Item5);
            Console.WriteLine(a.Item3);
            //UNPACK
            Console.WriteLine(a.a);
            Console.WriteLine(a.b);
        }
        static (int,int,int,char) fun(int[] a ,string b) 
        {
            int max = a.Max<int>();
            int min = a.Min<int>();
            int sum = a.Sum();
            (int, int, int, char) kor = (max, min, sum, b[0]);
            Console.WriteLine(kor);
            return kor;
        }
        static void check() 
        {
            checked 
            {
                int a = 2147483647;
                Console.WriteLine(a + 1);
            }
        }
        static void uncheck() 
        {
            unchecked
            {
                int a = 2147483647;
 
                Console.WriteLine(a+1);
            }
        }
        static void Main(string[] args)
        {
            //VVOD();
            //CONVERT();
            //UNPACK_PACK();
            //UNBELIEVABLE();
            //NOLABLE();
            //VAR();
            //STRONG();
            //arr();
            //kor();
            int[] arr = { 2, 1, 4, 5, 3 };
            //fun(arr,"abcdefg");
            //check();
            //uncheck();
        }
    }
}
