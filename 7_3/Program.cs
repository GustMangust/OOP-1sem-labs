using System;
using System.Collections.Generic;
using System.Linq;

namespace _7_3
{
    class Button 
    {
        public string caption;
        public (int, int) startpoint;
        public int w;
        public int h;
    }
    public enum State 
    {
        check,
        uncheck
    }
    class CheckButton : Button 
    {
        public EventHandler click;
        public EventHandler resize;
        public State state = State.uncheck;
        private bool check = true;
        public override string ToString()
        {
            return $"Кнопка {caption} c коориднатами {startpoint.Item1}, {startpoint.Item2}";
        }
        public override bool Equals(object obj)
        {
            CheckButton b = obj as CheckButton;
            if (this.w == b.w && this.h == b.h && this.caption == b.caption)
            {
                return true;
            }
            else return false;
        }
        public void Check() 
        {
            if (check == true) 
            {
                Console.WriteLine("Checked!");
                state = State.check;
                check = false;
            }
            else 
            {
                Console.WriteLine("Unchecked!");
                state = State.uncheck;
                check = true;
            }
            if (this.click != null)
            {
                click(this, new EventArgs { });
            }
        }
        public void Zoom(int percent) 
        {
            this.w = this.w * percent / 100;
            this.h = this.h * percent / 100;
            if (this.resize != null) 
            {
                resize(this, new EventArgs { });
            }
        }
    }
    class User 
    {
        public void Click(object sender, EventArgs eventArgs) 
        {
            CheckButton but = sender as CheckButton;
            Console.WriteLine($"Нажата кнопка {but.caption}");
        }
        public void Resize(object sender, EventArgs eventArgs) 
        {
            CheckButton but = sender as CheckButton;
            Console.WriteLine($"Изменены размеры кнопки {but.caption}");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            CheckButton but1 = new CheckButton { caption = "but1", click = user.Click, w = 20, h = 30 };
            Button but6 = new Button { caption = "butttttton", w = 200, h = 30 };
            CheckButton but2 = new CheckButton { caption = "but2", click = user.Click, w = 10, h = 35 };
            CheckButton but3 = new CheckButton { caption = "but3", resize = user.Resize, w = 30, h = 20 };
            CheckButton but4 = new CheckButton { caption = "but4", resize = user.Resize, w = 25, h = 55 };
            CheckButton but5 = new CheckButton { caption = "but4", resize = user.Resize, w = 55, h = 55 };
            Console.WriteLine(but4.Equals(but5));
            but1.Check();
            but2.Zoom(50);
            but3.Check();
            but4.Zoom(30);
            LinkedList<CheckButton> list = new LinkedList<CheckButton>();
            list.AddFirst(but1);
            list.AddFirst(but2);
            list.AddFirst(but3);
            list.AddFirst(but4);
            var list1 = from t in list
                        where t.h*t.w == 600
                        select t;
            foreach(CheckButton t in list1) 
            {
                Console.WriteLine($"{t.caption}");
            }
            int count = (from t in list
                        where t.state == 0
                        select t).Count();
            Console.WriteLine(count);
        }
    }
}