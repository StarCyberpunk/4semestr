using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class Hash<T>
    {
        public int key { get; }
        public T value;
        public Hash(int k, T v)
        {
            key = k;
            value = v;
        }
        public override string ToString()
        {
            return String.Format("({0},{1}) ", key, value);
        }
    }
}
