using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class DNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public DNode<T> Next { get; set; }
        public DNode<T> Previous { get; set; }
        public DNode()
        {
            Key = 0;
            Value = default(T);
            Next = null;
            Previous = null;
        }
        public DNode(int key, T value, DNode<T> next,DNode<T> prev)
        {
            Key = key;
            Value = value;
            Next = next;
            Previous = prev;
        }
        public DNode(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
            Previous = null;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", Key, Value);
        }
    }
}

