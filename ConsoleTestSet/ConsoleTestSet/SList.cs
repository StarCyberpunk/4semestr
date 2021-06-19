using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class SList<T> where T : IComparable
    {
        SNode<T> top;
    

        public int count { get; set; }
        public void AddTop(T data, int k)
        {
            SNode<T> snode = new SNode<T>(k, data, null);
            snode.Next = top;
            top = snode;
            count++;
        }
        public void AddEnd(T data, int k)
        {
            SNode<T> snode = new SNode<T>(k, data, null);
            if (top == null)
            {
                top = snode;
                count++;
                return;
            }
            else
            {
                SNode<T> c = top;
                while (c.Next != null)
                {
                    c = c.Next;
                }
                c.Next = snode;
            }
            count++;
        }
        public void RemoveTop()
        {
            if (count > 0)
            {
                top = top.Next;
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
                SNode<T> tmp = top;
                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                count--;
            }
        }


        public bool IsContainsByValue(T v)
        {
            SNode<T> tmp = top;
            while (tmp != null)
            {
                if (tmp.Value.Equals(v)) return true;
                tmp = tmp.Next;

            }
            return false;

        }
        public void View()
        {
            SNode<T> cur = top;
            Console.Write("SList   ");
            while (cur != null)
            {
                Console.Write("{0}->", cur);
                cur = cur.Next;
            }
            Console.WriteLine();

        }
        public SNode<T> FindByValue(T val)
        {
            SNode<T> cur = top;
            while (cur != null)
            {
                if (cur.Value.Equals(val)) return cur;
                cur = cur.Next;
            }
            return null;
        }
        public SNode<T> FindByKey(int k)
        {
            SNode<T> cur = top;
            while (cur != null)
            {
                if (cur.Key.Equals(k)) return cur;
                cur = cur.Next;
            }
            return null;
        }
        public SNode<T> FindByIndex(int index)
        {
            int inSN = 0;
            SNode<T> cur = top;
            if (index < 0 || index > count) return null;
            while (cur != null)
            {
                
                if (inSN==index) return cur;
                cur = cur.Next;
                inSN++;

            }
            return null;
        }


        public void InsertAfterValue(int k, T v, T sel)
        {
            SNode<T> tmp = top;
            if (count == 0) { top = tmp;/*end = tmp;*/ }
            while (tmp != null)
            {
                if (tmp.Value.Equals(sel))
                {
                    SNode<T> nn = new SNode<T>(k, v);
                    nn.Next = tmp.Next;
                    tmp.Next = nn;
                    count++;
                }
                tmp = tmp.Next;
                
            }
        }
        public void InsertBeforeValue(int k, T v, T sel)
        {
            SNode<T> tmp = top;
            SNode<T> before = null;
            if (count == 0) { top = tmp; /*end = tmp;*/ }
            while (tmp != null)
            {
                if (tmp.Value.Equals(sel))
                {
                    SNode<T> nn = new SNode<T>(k, v);
                    nn.Next = tmp;
                    if (before != null)
                    {
                        before.Next = nn;
                    }
                    else top = nn;
                    count++;
                }
                before = tmp;
                tmp = tmp.Next;
                
            }
        }
        public void RemoveByValue(T val)
        {
            
            SNode<T> cur = top;
            
            /* if (count > 0)
             {
                 if (count == 1)
                 {
                     top = null; count = 0; return;
                 }
             }*/
            while (cur != null)
            {

                if (cur.Value.Equals(val))
                {
                    Console.WriteLine(cur);
                    if (cur.Next == null) { RemoveEnd(); return; }
                    cur.Next = cur.Next.Next; return;
                }
                cur = cur.Next;
            }
            
        }
        public void RemoveByKey(int k)
        {
            SNode<T> cur = top;
            if (k == 0) { RemoveTop(); return; }
            if ((count - 1) == k) { RemoveEnd(); return; }
            /*if (count > 0)
            {
                if (count == 1)
                {
                    top = null; count = 0; return;
                }
            }*/
            while (cur != null)
            {
                if (cur.Key == k)
                {
                    if (cur.Next == null) {cur.Next = null; break;
                }
                    cur.Next = cur.Next.Next; 
                }
                cur = cur.Next;
            }

        }
        public void RemoveByIndex(int index)
        {
            int inSN=0;
            SNode<T> cur = top;
            if (index == 0) RemoveTop();
            if ((count - 1 )== index) RemoveEnd();
            /*if (count > 0)
            {
                if (count == 1)
                {
                    top = null; count = 0; return;
                }
            }*/
            while (cur.Next != null)//возможно  
            {
                inSN++;

                if (index == inSN) { cur.Next = cur.Next.Next; break; }
                cur = cur.Next;
                
            }

        }




    }
}

