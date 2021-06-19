using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class NodeTree<T> 
    {
        public int key;
        public T Value;
        public NodeTree<T> Parent;
        public NodeTree<T> Right,Left;
        
        public NodeTree(int k,T v,NodeTree<T> pr = null, NodeTree<T> R = null, NodeTree<T> L = null)
        {
            key = k;
            Value = v;
            Parent = pr;
            Right = R;
            Left = L;
        }
        public override string ToString()
        {
            string ret = string.Format("(Key ={0} Value={1})", key, Value);
            if (Parent != null) ret = ret + string.Format("Parent key={0} ", Parent.key);
            if (Left != null) ret = ret + string.Format("Left key={0} ", Left.key);
            if (Right != null) ret = ret + string.Format("Right key={0} ", Right.key);
            return ret;
        }
    }
}
