
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
  public  class SNode<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public SNode<T> Next { get; set; }
        public SNode()
        {
            Key = 0;
            Value = default(T);
            Next = null;
        }
        public SNode(int key, T value, SNode<T> next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
        public SNode(int key, T value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})",Key,Value);         
        }
    }
   
    }


