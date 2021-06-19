using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    class DList<T> where T:IComparable
    {
        DNode<T> top;
        DNode<T> end;

        public int count { get; set; }
        public void AddTop(T data, int k)
        {
            DNode<T> dnode = new DNode<T>(k, data);
            DNode<T> tmp = top;
            dnode.Next = tmp;
            top = dnode;
            if (count == 0)
            {
                end = top;
                
               
            }
            else

                tmp.Previous = dnode;
            
            count++;
        }
        public void AddEnd(T data, int k)
        {
            DNode<T> dnode = new DNode<T>(k, data);
            DNode<T> tmp = end;
            dnode.Previous = tmp;
            end = dnode;
            if (count == 0)
            {
                top = end;
               
            }
            else
                tmp.Next = dnode;
            
            count++;
        }
        public void RemoveTop()
        {
            if (count > 0)
            {
                top = top.Next;
                top.Previous = null;
                count--;
            }
        }
        public void RemoveEnd()
        {
            if (count > 0)
            {
                if (count == 1)
                {
                    top = null;
                    count = 0;
                    return;
                }
                DNode<T> tmp = top;
               
                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next.Previous = null;
                tmp.Next = null;
                end=tmp;
                count--;
            }
        }
        public bool IsContainsByValue(T v)
        {
            DNode<T> tmp = top;
            while (tmp != null)
            {
                if (tmp.Value.Equals(v)) return true;
                tmp = tmp.Next;

            }
            return false;
        }
        public void View()
        {
            DNode<T> cur = top;
            while (cur != null)
            {
                Console.Write("{0}->", cur);
                cur = cur.Next;
            }
            Console.WriteLine();

        }
        public void ViewBack()
        {
            DNode<T> cur = end;
            while (cur != null)
            {
                Console.Write("<-{0}", cur);
                cur = cur.Previous;
            }
            Console.WriteLine();

        }
        public DNode<T> FindByValue(T val)
        {
            DNode<T> cur = top;
            while (cur != null)
            {
                if (cur.Value.Equals(val)) return cur;
                cur = cur.Next;
            }
            return null;
        }
        public DNode<T> FindByKey(int k)
        {
            DNode<T> cur = top;
            while (cur != null)
            {
                if (cur.Key.Equals(k)) return cur;
                cur = cur.Next;
            }
            return null;
        }
        public DNode<T> FindByIndex(int index)
        {
            int inSN = 0;
            DNode<T> cur = top;
           
            if (index < 0 || index > count) return null;
            while (cur != null)
            {

                
                if (inSN == index) return cur;
                cur = cur.Next;
                inSN++;

            }
            Console.WriteLine(inSN);
            return null;
        }
        public void InsertAfterValue(int k, T v,T N)
        {
            DNode<T> tmp = top;
            if (count == 0) { top = tmp; /*end = tmp;*/ }
            while (tmp != null)
            {
                if (tmp.Value.Equals(N))
                {
                    DNode<T> nn = new DNode<T>(k, v);

                    tmp.Next.Previous = nn;
                    nn.Next = tmp.Next;
                    tmp.Next = nn;
                    nn.Previous = tmp;
                    count++;
                }
                tmp = tmp.Next;
                
            }
        }
        public void InsertBeforeValue(int k, T v, T N)
        {
            DNode<T> tmp = top;
            if (count == 0) { top = tmp; end = tmp; }
            while (tmp != null)
            {
                if (tmp.Value.Equals(N))
                {
                    DNode<T> nn = new DNode<T>(k, v);

                    tmp.Previous.Next = nn;
                    nn.Previous = tmp.Previous;
                    tmp.Previous = nn;
                    nn.Next = tmp;
                    count++;
                }
                tmp = tmp.Next;
                
            }
        }
        public void RemoveByValue(T val)
        {
            DNode<T> cur = top;
            DNode<T> cur2 = end;
            if (cur.Value.Equals(val)) { RemoveTop(); return; }
            if (cur2.Value.Equals(val)) { RemoveEnd(); return; }
            while (cur.Next != null)
            {
                if (cur.Value.Equals(val))
                {
                    cur.Previous.Next = cur.Next;
                    cur.Next.Previous = cur.Previous;
                    break;
                }
                cur = cur.Next;
            }
        }
        public void RemoveByKey(int k)
        {
            DNode<T> cur = top;
            if (k == top.Key) { RemoveTop(); return; }
            if (end.Key == k) { RemoveEnd(); return; }
            while (cur.Next != null)
            {
                if (cur.Key == k)
                {
                    cur.Previous.Next = cur.Next;
                    cur.Next.Previous = cur.Previous;
                    break;
                }
                cur = cur.Next;
            }
        }
        public void RemoveByIndex(int index)
        {
            int inSN = 0;
            DNode<T> cur = top;
            if (index == 0) { RemoveTop(); return; }
            if ((count - 1) == index) { RemoveEnd(); return; }
            while (cur.Next != null)
            {
               
                if (index == inSN) {  cur.Previous.Next = cur.Next;
                    cur.Next.Previous = cur.Previous;
                    break; }
                cur = cur.Next;
                inSN++;

            }
        }



    }
}
