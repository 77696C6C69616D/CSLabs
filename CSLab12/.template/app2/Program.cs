using System;
using System.Collections.Generic;
using System.Collections;

namespace geiko.DZ_61
{
    class Program
    {
        public class ByteCollection : List<byte> { }

        class CharCollection : CollectionBase
        {
            public char this[int index]
            {
                get { return ((char)List[index]); }
                set { List[index] = value; }
            }

            public void Add(char value)
            {
                List.Add(value);
            }
        }

        static void Main(string[] args)
        {
            ByteCollection list1 = new ByteCollection();
            for (int i = 0; i < 9; i++)
            {
                list1.Add((byte)i);
            }
            foreach (byte i in list1)
            {
                Console.WriteLine(" {0} ", i);
            }
            Console.WriteLine();
            CharCollection list2 = new CharCollection();
            list2.Add('a');
            list2.Add('b');
            list2.Add('c');
            list2.Add('d');
            list2.Add('e');
            list2.Add('f');
            foreach (char i in list2)
            {
                Console.WriteLine(" {0} ", i);
            }
            Console.ReadKey();
        }
    }
}
