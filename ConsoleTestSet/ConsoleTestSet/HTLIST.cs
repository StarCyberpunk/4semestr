using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class HTLIST<T>
    {
        List<Hash<T>>[] lists;
        public int count = 0;
        public int Size;
        public int MaxSize;
        public HTLIST(int start)
        {
            lists = new List<Hash<T>>[start];
            Size = start;
            for (int i = 0; i < start; i++)
            {
                lists[i] = new List<Hash<T>>();
            }
            count = 0;
        }
        public int KeySize(int key)
        {
            return key % Size;
        }
        public void Add(int key, T value)
        {
            int ks = KeySize(key);
            var hash = new Hash<T>(key, value);
            lists[ks].Add(hash);
            count++;
        }
        public void View()//+
        {
            for (int index = 0; index < Size; index++)
            {
                Console.WriteLine("List {0}", index);
                for (int i = 0; i < lists[index].Count; i++)
                {
                    var curitem = lists[index][i];
                    Console.Write("{0}    ", curitem);
                }
                Console.WriteLine();
            }
        }
        public void DeleteKey(int ke)
        {
            int index = KeySize(ke);
            int findind = -1;
            for (int i = 0; i < lists[index].Count; i++)
            {
                var curitem = lists[index][i];
                if (curitem.key.CompareTo(ke) == 0) { findind = i; break; }
            }
            if (findind >= 0) { lists[index].RemoveAt(findind); count--; }
        }
        public Hash<T> Search(int k)
        {
            int index = KeySize(k);
            for (int i = 0; i < lists[index].Count; i++)
            {
                var curitem = lists[index][i];
                if (curitem.key.CompareTo(k) == 0) {
                    return curitem;
                }
            }
            return null;

        }
        public void Resize(int start)
        {
            var tmp = new List<Hash<T>>();
            for (int index = 0; index < Size; index++)
            {

                for (int i = 0; i < lists[index].Count; i++)
                {
                    var cur = lists[index][i];
                    tmp.Add(cur);

                }

            }
            lists = new List<Hash<T>>[start];
            Size = start;
            for(int i = 0; i < Size; i++)
            {
                lists[i] = new List<Hash<T>>();
            }
            count = 0;
            foreach(var t in tmp)
            {
                this.Add(t.key, t.value);
            }
        }



    }
}
