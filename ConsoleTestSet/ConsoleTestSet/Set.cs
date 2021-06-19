using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestSet
{
    class Set<T> where T:IComparable
    {
        int size, count;
        T[] data;
        public int Size { get { return size; } } // Размер множества
        public int Count { get { return count; } } // Количество элементов в множестве
      // Конструктор
        public Set(int size)
        {
            this.size = size; this.count = 0;
            data = new T[this.size];
        }
        // Проверка на наличие элемента
        public bool IsContains(T element)
        {
            for (int i = 0; i < count; i++) if (data[i].CompareTo(element) == 0) return true;
            return false;
        }
        //Получение данных из множества по индексу
        public T GetElementByIndex(int index)
        {
            if (index < 0 || index >= count) return default(T);
            return data[index];
        }

        //Изменение данных из множества по индексу
        public T SetElementByIndex(int index, T newElevent)
        {
            if (index < 0 || index >= count) return default(T);
            data[index] = newElevent;
            return data[index];
        }
        // Получение индекса элемента
        public int GetIndex(T element)
        {
            for (int i = 0; i < count; i++) if (data[i].CompareTo(element) == 0) return i;
            return -1;
        }
        public Set<T> Copy()
        {
            Set<T> copy = new Set<T>(this.Size);
            for (int i = 0; i < this.Count; i++)
            {
                copy.Add(data[i]);
            }
            return copy;
        }
        //Конструктор
        public Set(T [] mas)
        {
            this.size = mas.Length;
            this.count = 0;
            data = new T[this.size];
            for(int i=0;i<size;i++)
            {
                if(!IsContains(mas[i])) { data[count] = mas[i];count++; }
            }
        }
        // Дабавление нового элемента
        public void Add(T element)
        {
            if (IsContains(element)) return;
            if(count<size) { data[count] = element; count++; return; }
            T[] temp = new T[this.size];
            for (int i = 0; i < size; i++) temp[i] = data[i];
            this.size *= 2;
            data = new T[this.size];
            for (int i = 0; i < count; i++) data[i] = temp[i];
            data[count] = element; count++;
        }
        //Удаление по индексу
        public bool RemoveByIndex(int index)
        {
            if (index < 0 || index >= count) return false;

            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            count--;
            return true;
        }

        //Удаление элемента 
        public bool RemoveByElement(T element)
        {
            if (!IsContains(element)) return false; 
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(element))
                {
                    for (int j = i; j < count; j++)
                    {
                        data[j] = data[j + 1];
                    }
                }
            }
            count -= 1;
            return true;
        }

        //Поиск по индексу
        public int Search(T el)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(el))
                {
                    return i;
                }
            }
            return index;
        }
        public override string ToString()
        {
            T[] temp = new T[count];
            for (int i = 0; i < count; i++) temp[i] = data[i];
            return "{"+string.Join(";",temp)+"}";
        }
        // объедение множеств
        public Set<T> Union(Set<T> s2)
        {
            Set < T > su= new Set<T>(this.size + s2.Size);
            for (int i = 0; i < count; i++) su.Add(data[i]);
            for (int i = 0; i < s2.Count; i++) su.Add(s2.data[i]);
            return su;
        }
        //Пересечение множеств
        public Set<T> Intersection(Set<T> set2)
        {
            Set<T> su = new Set<T>(this.size);
            for (int i = 0; i < count; i++) if (set2.IsContains(data[i])) su.Add(data[i]);
            return su;
        }
        public void Resize(T newSize)
        {
            T[] newarray = new T[this.Count];
            for (int i = 0; i < count; i++)
            {
                newarray[i] = data[i];
            }
            this.size = Convert.ToInt32(newSize);
            data = new T[this.size];
            for (int i = 0; i < count; i++)
            {
                data[i] = newarray[i];
            }
        }
            public void Perevod(int chislo, int osnov)
            {
                Console.WriteLine("Число в 10-й системе = " + chislo);
                string result = "";     // переменная для результата
                int temp = 0;

                if (chislo > 0)     // условие, что число больше 0
                    while (chislo >= (osnov - 1))   // цикл, пока число больше самого основания
                    {
                        temp = chislo % osnov;
                        chislo = (chislo - temp) / osnov;
                        result = Convert.ToString(temp) + result;
                    }

                result = Convert.ToString(chislo) + result;
                Console.WriteLine("Число в " + osnov + "-й системе = " + result);

            }

            //Множество множеств1
            public List<Set<T>> Num1()
            {
                List<T> ddd = new List<T>(this.size);
                int kol = (int)Math.Pow(2, data.Length); // количество подмножеств (2^n)
                List<Set<T>> lsets = new List<Set<T>>(kol);


                for (int i = 0; i < kol; i++)
                {
                    for (int j = 0; j <= lsets.Count; j++)
                    {
                        int tmp = (int)Math.Pow(2, j);
                        if ((i & tmp) != 0)
                        {
                            //
                        }
                    }
                }

                return lsets;
            }

            //Множество множеств2
            public List<Set<T>> Num2()
            {
                int kol = (int)Math.Pow(2, data.Length); // количество подмножеств (2^n)
                List<Set<T>> lsets = new List<Set<T>>(kol);
                for (int i = 0; i < kol; i++)
                {
                    Set<T> tmpset = new Set<T>(i - 1);
                    for (int j = 0; j <= lsets.Count; j++)
                    {
                        tmpset.Add(data[j]);
                    }
                    lsets.Add(tmpset);
                }
                return lsets;
            }
       

        //Дополнение множеств (разность) - 1 вар (при помощи Add)
        public Set<T> Difference(Set<T> set)
            {
                Set<T> res = new Set<T>(size);
                for (int i = 0; i < count; i++)
                    if (!set.IsContains(data[i])) res.Add(data[i]);
                return res;
            }

            //Дополнение множеств (разность) - 2 вар (при помощи Remove)
            public Set<T> Difference1(Set<T> set)
            {
                Set<T> res = new Set<T>(size);
                foreach (var item in set)
                {
                    res.RemoveByElement(item);
                }
                return res;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < count; i++)
                {
                    yield return data[i];
                }
            }


        //Поиск всех подмножеств множества (Показательное множество (булеан))   - испрпавить
        public void Numbcomb(int[] list)
        {
            int gelen = (int)Math.Pow(2, list.Length); // number of subsets / количество подмножеств (2^n)
            string[] result = new string[gelen]; // array with subsets as elements

            for (int i = 0; i < gelen; i++) // filling "result"
            {
                for (int j = 0; j < list.Length; j++)  // 0,1,2 (for n=3)
                {
                    int t = (int)Math.Pow(2, j); // 1,2,4 (for n=3)
                    if ((i & t) != 0)
                    { result[i] += list[j] + " "; } // add to subset
                }
                Console.Write("{0}: ", i);// write subset number
                Console.WriteLine(result[i]);//write subset itself
            }
        }
        public static Set<T> operator + (Set<T> s1,Set<T> s2)
        {
            Set<T> su = new Set<T>(s1.size + s2.Size);
            for (int i = 0; i < s1.count; i++) su.Add(s1.data[i]);
            for (int i = 0; i < s2.Count; i++) su.Add(s2.data[i]);
            return su;
        }
        // Получение набора множеств из последовательности элементов множества
        public List<Set<T>> GetList()
        {
            List < Set<T> > lsets= new List<Set<T>>();
            for(int i=0;i<count;i++)
            {
                Set<T> tmpset = new Set<T>(i + 1);
                for (int j = 0; j <= i; j++) tmpset.Add(data[j]);
                lsets.Add(tmpset);
            }
            return lsets;
        }
       /* public *//*List<*//*Set<T>*//*>*//* Perest()
        {
            *//*List<Set<T>> lsets = new List<Set<T>>();*/
            /*for (int i = 0; i < count; i++)
            {*//*
                Set<T> tmpset = new Set<T>(i + 1);
                for (int j = 0; j <= i; j++) tmpset.Add(data[j]);
                data=Permute(data,0,data.Length);
            return tmpset;
        *//*}*/
            /*return lsets;*//*
        }*/
        public static T[] Permute(T[] da,int i,int n)
        {
           /* T[] ne= (T[])da.Clone();*/
            if (i == n) return da;
            else
            {
                for(int j = i; j < n; j++) {
                    T tmp = da[i];
                    da[i] = da[j];
                    da[j] = tmp;
                    Permute(da, i + 1, n);
                }
                return da;
            }
        }
        //переборка интов и просто делаем выбор по интам data[int]и добавляем в новый список

        public static Set<T> operator *(Set<T> s1, Set<T> s2) => s1.Intersection(s2);

        //Дополнение (разность)
        public static Set<T> operator -(Set<T> s1, Set<T> s2) => s1.Difference(s2);

        /* Добавить методы
      
      
        Пересечение множеств
        дополнение множеств
        получение перестановок
        получение сочетаний
        и т.д.

        */
    }
}
