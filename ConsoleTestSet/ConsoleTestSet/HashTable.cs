using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class HashTable<T> 
    {
        public int count = 0;
        Hash<T>[] KeyValues;
        public int Size;
        public int[] active;
        public int MaxSize;
        public HashTable()
        {
            KeyValues = new Hash<T>[0];
        }
        
        public HashTable(int start)
        {
            KeyValues = new Hash<T>[start];
            Size = start;
            active = new int[Size];
            count = 0;
        }
        public int KeySize(int key)
        {
            return key % Size;
        }
        public void Add(int key,T value)
        {
            if (count >= Size)
            {
                Resize(2*Size);
                Add(key, value);
                return;
            }
            int ks = KeySize(key);
            var hash = new Hash<T>(key,value);
            if (active[ks] == 0)
            {
                KeyValues[ks] = hash;
                count++;
                active[ks] = 1;
                return;
            }
            if (active[ks]!=0 && KeyValues[ks].key == key)
            {
                Console.WriteLine("Ectb key");
                return;
            }
            while (active[ks] != 0)
            {  ks++;
                if (ks == Size) ks = 0;
            }
            KeyValues[ks] = hash;
            active[ks] = 1;
                count++;
                return;

            
            
        }//+
     
        public void Resize(int start)
        {
            var tmp = new Hash<T>[start];
            for (int index = 0; index < Size; index++)
            {
                tmp[index] = KeyValues[index];
            }
            KeyValues = new Hash<T>[start];
            Size = start;
            for (int index = 0; index < Size; index++)
            {
                KeyValues[index] = tmp[index];
            }
            Array.Resize(ref active, start);

        }
        public void OLDResize(int nsize)
        {
            var KeyValues2 = new Hash<T>[nsize];
            int i = 0;
            foreach (var k in KeyValues)
            {
                KeyValues2[i] = k;
                i++;
            }
            Size++;
            Array.Resize(ref active, nsize);
            KeyValues = KeyValues2;
        }
        public void View()//+
        {
            int k = 0;
            while (k!=active.Length)
            {
                if(active[k]!=0) Console.Write(KeyValues[k]);
                k++;
                if (k == count) return;
            }
            Console.WriteLine();
        }
        public void DeleteKey(int ke)
        {
            var ha = Search(ke);
            var h1 = SearchKe(ke);
            if (h1 == -1) return;
            if (ha != null)
            {
                active[h1] = 0;
                KeyValues[h1] = null;
            }
            else return;
        }
        public Hash<T> Search(int ke)
        {
            int j = 0;
            Hash<T> res=null;
            while (j != active.Length)
            {
                if (KeyValues[j] != null) 
                { 
                if (KeyValues[j].key == ke) { res = KeyValues[j]; break; }
                if (j == KeyValues.Length) { res = null; break; }
                }
                j++;
            }
            return res;
        }
        public int SearchKe(int ke)
        {
            int j = 0;
            while (j != active.Length)
            {
                if (KeyValues[j] != null)
                {
                    if (KeyValues[j].key == ke) { return j;  }
                    if (j == KeyValues.Length) { return -1; }
                }
                j++;
            }
            return -1;
            
        }
        public override string ToString()
        {
            return String.Format("({0}) ",KeyValues);
        }


    } 
}
