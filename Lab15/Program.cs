using System;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine($"Задание 1");
            foreach (Process proc in Process.GetProcesses())
            {
                Console.WriteLine($"Запущенный процесс имеет {proc.Id} - ID, " +
                    $"{proc.ProcessName} - Имя, {proc.BasePriority} - Приоритет, " +
                    $"{proc.Responding} - текущее состояние"
                );
            }

            // Задание 2
            Console.WriteLine($"Задание 2");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName}, Директория: {domain.BaseDirectory}");
            Console.WriteLine($"Все сборки:");
            foreach (Assembly el in domain.GetAssemblies())
            {
                Console.WriteLine($"Имя сборки: {el.GetName().Name}");
            }
            //создание и настройка домена ( не поддерживается на ОС Windows)
            //Assembly[] assembly = domain.GetAssemblies();
            //AppDomain newDomain = AppDomain.CreateDomain("NewDomain");//создаем новый домен
            //newDomain.Load(assembly[1].GetName().Name);//получаем имя сборки
            //AppDomain.Unload(newDomain);

            // Задание 3

            Thread thread = new Thread(new ParameterizedThreadStart(PrintSimple));
            thread.Priority = ThreadPriority.Lowest;
            thread.Start(20);
            thread.Join();

            // Задание 4

            EvenCl ev = new EvenCl(20);
            Thread.Sleep(10);
            OddCl od = new OddCl(20);

            ev.Thread.Join();
            od.Thread.Join();

            NewEven ne = new NewEven(20);
            Thread.Sleep(10);
            NewOdd no = new NewOdd(20);
            ne.thr.Join();
            od.Thread.Join();

        }
        public static void PrintSimple(object N)
        {
            Thread t = Thread.CurrentThread;
            using (StreamWriter file = new StreamWriter("Simple.txt", false))
            {
                for (int i = 1; i <= (int)N; i++)
                {
                    if (i == 10)
                    {
                        //t.Suspend(); ( не поддерживается на ОС Windows)
                        Console.WriteLine($"Поток приостановлен на 3 секунды");
                        Thread.Sleep(3000);
                        //t.Resume();
                    }
                    file.WriteLine($"{i} - простое число {t.IsAlive} - жив? {t.Priority} - приоритет");
                    Console.WriteLine($"{i} - простое число {t.IsAlive} - жив? {t.Priority} - приоритет");
                    Thread.Sleep(300);
                }
            }
        }

        class OddCl
        {
            int N;
            public Thread Thread;
            public OddCl(int _N)
            {
                Thread = new Thread(this.OddFirst);
                N = _N;
                Thread.Start();
            }

            void OddFirst()
            {
                Mutexx.mtx.WaitOne();

                using (StreamWriter file = new StreamWriter("Numbers.txt", false))
                {
                    for (int i = 0; i < (int)N; i++)
                    {
                        if (i % 2 != 0)
                        {
                            //Thread.Sleep(100);
                            Console.WriteLine($"{i} - нечет");
                            file.WriteLine(i + "нечет");
                        }
                    }
                }
                Mutexx.mtx.ReleaseMutex();
            }


        }
        class EvenCl
        {
            int N;
            public Thread Thread;
            public EvenCl(int _N)
            {
                Thread = new Thread(this.EvenLast);
                N = _N;
                Thread.Start();
            }
            void EvenLast()
            {
                Mutexx.mtx.WaitOne();
                using (StreamWriter file = new StreamWriter("Numbers.txt", true))
                {
                    for (int i = 0; i < (int)N; i++)
                    {
                        if (i % 2 == 0)
                        {

                            Console.WriteLine($"{i} - чет");
                            file.WriteLine(i + "чет");
                        }
                    }
                }
                Mutexx.mtx.ReleaseMutex();
            }
        }
        static class Mutexx
        {
            public static Mutex mtx = new Mutex();
        }
        class NewOdd
        {
            int N;
            public Thread thr;

            public NewOdd(int _N)
            {
                thr = new Thread(this.Run);
                N = _N;
                thr.Start();
            }

            void Run()
            {
                int a = 1;
                while (a < N)
                {
                    Mutexx.mtx.WaitOne();
                    using (StreamWriter file = new StreamWriter("EvenOdd.txt", true))
                    {
                        if (a % 2 != 0)
                        {
                            file.WriteLine(a + " - нечет");
                        }
                    }
                    Mutexx.mtx.ReleaseMutex();
                    Thread.Sleep(200);
                    a++;
                }
            }
        }
        class NewEven
        {
            int N;
            public Thread thr;
            public NewEven(int _N)
            {
                thr = new Thread(this.Run);
                N = _N;
                thr.Start();
            }
            void Run()
            {
                int a = 1;
                while (a < N)
                {
                    Mutexx.mtx.WaitOne();
                    using (StreamWriter file = new StreamWriter("EvenOdd.txt", true))
                    {
                        if (a % 2 == 0)
                        {
                            file.WriteLine(a + " - чет");
                        }
                    }
                    Mutexx.mtx.ReleaseMutex();
                    Thread.Sleep(200);
                    a++;
                }
            }
        }
    }


}