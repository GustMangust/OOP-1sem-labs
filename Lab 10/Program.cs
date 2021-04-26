using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Lab_10
{
    class Tovar: IOrderedDictionary
    {
        private ArrayList _tovar;
        public Tovar(int _amount) 
        {
            _tovar = new ArrayList(_amount);
        }
        public int IndexOfKey(object key)
        {
            for (int i = 0; i < _tovar.Count; i++)
            {
                if (((DictionaryEntry)_tovar[i]).Key == key)
                    return i;
            }

            // key not found, return -1.
            return -1;
        }
        public void Output() 
        {

                foreach (DictionaryEntry de in this)
                {
                    Console.WriteLine(de.Key);
                    Console.WriteLine(de.Value);
                }
        }
        public object this[object key]
        {
            get
            {
                return ((DictionaryEntry)_tovar[IndexOfKey(key)]).Value;
            }
            set
            {
                _tovar[IndexOfKey(key)] = new DictionaryEntry(key, value);
            }
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return new TovarEnum(_tovar);
        }

        public void Insert(int index, object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            _tovar.Insert(index, new DictionaryEntry(key, value));
        }

        public void RemoveAt(int index)
        {
            _tovar.RemoveAt(index);
        }

        public object this[int index]
        {
            get
            {
                return ((DictionaryEntry)_tovar[index]).Value;
            }
            set
            {
                object key = ((DictionaryEntry)_tovar[index]).Key;
                _tovar[index] = new DictionaryEntry(key, value);
            }
        }
        // IDictionary Members

        public void Add(object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            _tovar.Add(new DictionaryEntry(key, value));
        }

        public void Clear()
        {
            _tovar.Clear();
        }

        public bool Contains(object key)
        {
            if (IndexOfKey(key) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection Keys
        {
            get
            {
                ArrayList KeyCollection = new ArrayList(_tovar.Count);
                for (int i = 0; i < _tovar.Count; i++)
                {
                    KeyCollection.Add(((DictionaryEntry)_tovar[i]).Key);
                }
                return KeyCollection;
            }
        }

        public void Remove(object key)
        {
            _tovar.RemoveAt(IndexOfKey(key));
        }

        public ICollection Values
        {
            get
            {
                ArrayList ValueCollection = new ArrayList(_tovar.Count);
                for (int i = 0; i < _tovar.Count; i++)
                {
                    ValueCollection.Add(((DictionaryEntry)_tovar[i]).Value);
                }
                return ValueCollection;
            }
        }

        // ICollection Members

        public void CopyTo(Array array, int index)
        {
            _tovar.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return _tovar.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return _tovar.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return _tovar.SyncRoot;
            }
        }

        // IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TovarEnum(_tovar);
        }
    }
    public class TovarEnum : IDictionaryEnumerator
    {
        public ArrayList _tovar;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public TovarEnum(ArrayList list)
        {
            _tovar = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _tovar.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _tovar[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }

        public object Key
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_tovar[position]).Key;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object Value
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_tovar[position]).Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //задание 1
            Tovar tov = new Tovar(5);
            tov.Add("first", 1);
            tov.Add("second", 2);
            tov.Add("third", 3);

            tov.Remove("second");
            tov.IndexOfKey("third");

            tov.Output();

            //задание2
            List<int> a = new List<int>();
            List<char> c = new List<char>();
            Random rand = new Random();
            for(int j = 0; j < 5; j++) 
            {
                a.Add( rand.Next(0,30));
                c.Add((char)rand.Next(0x0410, 0x44F));
            }

            //а
            foreach (var item in a)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //b
            for (int i = 0; i < 3; i++)
            {
                a.RemoveAt(0);
            }
            for (int i = 0; i < 3; i++)
            {
                c.RemoveAt(0);
            }
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //c
            int[] b = {1,2,3,4,5};
            a.AddRange(b);
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            c.AddRange(c);
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //d
            ConcurrentBag<int> ab = new ConcurrentBag<int>();
            foreach (var item in a)
            {
                ab.Add(item);
            }
            //e
            foreach (var item in ab)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //d
            int x = a[0];
            Console.WriteLine(ab.Where<int>(x => a[0].Equals(x)).FirstOrDefault());

            //задание 3
            ObservableCollection<int> ints = new ObservableCollection<int>{1,2,3};

            ints.CollectionChanged += ints_CollectionChanged;

            ints.Add(5);
            ints.RemoveAt(1);
            ints[0] = 6;

            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
        }
        private static void ints_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    int newint = (int)e.NewItems[0];
                    Console.WriteLine($"Добавлен новый объект: {newint}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    int oldint = (int)e.OldItems[0];
                    Console.WriteLine($"Удален объект: {oldint}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    int replacedint = (int)e.OldItems[0];
                    int replacingint = (int)e.NewItems[0];
                    Console.WriteLine($"Объект {replacedint} заменен объектом {replacingint}");
                    break;
            }
        }
    }
}
