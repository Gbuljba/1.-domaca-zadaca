using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);

        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);

        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);

        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);

        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);

        /// <summary >
        /// Readonly property . Gets the number of items contained in the collection.
        /// </ summary >
        int Count { get; }

        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();

        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(int item);
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int numOfItems;

        public IntegerList()
        {
            _internalStorage = new int[4];
            numOfItems = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new int[initialSize];
            }
            else
            {
                _internalStorage = new int[4];
            }
            numOfItems = 0;
        }

        public void Add(int item)
        {
            if (numOfItems == _internalStorage.Length)
            {
                int[] temp = new int[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; ++i)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[numOfItems] = item;
            numOfItems++;
        }

        public bool RemoveAt(int index)
        {
            if (index >= numOfItems)
            {
                return false;
            }
            for (int i = index; i < numOfItems - 1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            numOfItems--;
            return true;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                return RemoveAt(index);
            }
            else
            {
                return false;
            }
        }

        public int GetElement(int index)
        {
            if (index < numOfItems)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            int index = -1;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i] == item)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return -1;
            }
            else
            {
                return index;
            }
        }

        public void Clear()
        {
            numOfItems = 0;
        }

        public bool Contains(int item)
        {
            bool found = false;
            for (int i = 0; i < numOfItems; ++i)
            {
                if (_internalStorage[i] == item)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public int Count
        {
            get
            {
                return numOfItems;
            }
        }
}

    class Program
    {
        static void Main(string[] args)
        {
            IntegerList lista = new IntegerList();
            ListExample(lista);
            Console.ReadLine();
        }

        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); // [2 ,3 ,4]
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100)); // false
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false
            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count); // 0
        }
    }
}
