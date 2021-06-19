using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    class Sort
    {
        public static void BubbleSort<T>(T[] list) where T : IComparable
        {
            int N = list.Length;
            int numberOfPairs = N - 1;
            int swappedElements = N;
            while (swappedElements > 0)
            {
                swappedElements = 0;
                for (int i = 0; i < numberOfPairs; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)   // if(list[i]>list[i+1])
                    {
                        T tmp; tmp = list[i]; list[i] = list[i + 1]; list[i + 1] = tmp; //Swap(list[i],list[i+1])
                        swappedElements++;
                    }
                }
                numberOfPairs--;  // numberOfPairs = numberOfPairs - l;
            }
        }
        public static void BubbleSortSwap<T>(T[] list) where T : IComparable
        {
            int N = list.Length;
            int numberOfPairs = N - 1;
            int swappedElements = N;
            while (swappedElements > 0)
            {
                swappedElements = 0;
                for (int i = 0; i < numberOfPairs; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)   // if(list[i]>list[i+1])
                    {
                        Swap(ref list[i], ref list[i + 1]); //Swap(list[i],list[i+1])
                        swappedElements++;
                    }
                }
                numberOfPairs--;  // numberOfPairs = numberOfPairs - l;
            }
        }
      

        //метод обмена элементов
        public static void Swap<T>(ref T a, ref T b)
        {
            T c = a; a = b; b = c;
        }

        //cортировка вставками
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1].CompareTo(key) > 0))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
        }

        //Min index
        public static int IndexOfMin<T>(T[] list, int n) where T : IComparable
        {
            int result = n;
            for (var i = n; i < list.Length; ++i)
            {
                if (list[i].CompareTo(list[result]) < 0)
                {
                    result = i;
                }
            }
            return result;
        }

        //cортировка выбором
        public static T SelectionSort<T>(T[] list, int currentIndex = 0) where T : IComparable
        {
            if (currentIndex == list.Length - 1)
                return list[currentIndex];

            int index = IndexOfMin(list, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref list[index], ref list[currentIndex]);
            }

            return SelectionSort(list, currentIndex + 1);
        }

        //сортиовка Шелла
        public static void ShellSort<T>(T[] list) where T : IComparable
        {
            //расстояние между элементами, которые сравниваются
            var d = list.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < list.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (list[j - d].CompareTo(list[j]) > 0))
                    {
                        Swap(ref list[j], ref list[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }
        }

        //сортировка "Шейкер"
        public static T[] ShakerSort<T>(T[] list) where T : IComparable
        {
            for (var i = 0; i < list.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо || сверху вниз
                for (var j = i; j < list.Length - i - 1; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        Swap(ref list[j], ref list[j + 1]);
                        swapFlag = true;
                    }
                }

                for (var j = list.Length - 2 - i; j > i; j--)
                {
                    if (list[j - 1].CompareTo(list[j]) > 0)
                    {
                        Swap(ref list[j - 1], ref list[j]);
                        swapFlag = true;
                    }
                }

          
                if (!swapFlag)
                {
                    break;
                }
            }

            return list;
        }

        //метод возвращающий индекс разделяющего эл-та
        public static int Partition<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            var Razdel = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (list[i].CompareTo(list[maxIndex]) < 0)
                {
                    Razdel++;
                    Swap(ref list[Razdel], ref list[i]);
                }
            }

            Razdel++;
            Swap(ref list[Razdel], ref list[maxIndex]);
            return Razdel;
        }
        //169 Алгоритм Ломуто для разбиения 
        public static int PartitionLomuto<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            var i = minIndex - 1;
            var x = list[maxIndex];
            for (var j = minIndex; j < maxIndex; j++)
            {
                if (list[j].CompareTo(x)<0)
                {
                    i++;
                    Swap(ref list[i], ref list[j]);
                }
            }
            if (i < maxIndex)
            {
                return i;
            }
            else return i - 1;
            
        }
        //Random-partiton 162
        public static int PartitionRandom<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            Random rnd = new Random();
            int i = rnd.Next(minIndex,maxIndex);
            Swap(ref list[minIndex], ref list[i]);
            return PartitionRandom<T>(list, minIndex, maxIndex);

        }

        //Быстрая сортировка
        public static T[] QuickSort<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            if (minIndex >= maxIndex)
            {
                return list;
            }

            var razdelIndex = Partition(list, minIndex, maxIndex);
            QuickSort(list, minIndex, razdelIndex - 1);
            QuickSort(list, razdelIndex + 1, maxIndex);

            return list;
        }

        //Метод для слияния массивов
        public static void Merge<T>(T[] list, int minIndex, int middleIndex, int maxIndex) where T : IComparable
        {
            var left = minIndex;
            var right = middleIndex + 1;
            var tempArray = new T[maxIndex - minIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= maxIndex))
            {
                if (list[left].CompareTo(list[right]) < 0)
                {
                    tempArray[index] = list[left];
                    left++;
                }
                else
                {
                    tempArray[index] = list[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = list[i];
                index++;
            }

            for (var i = right; i <= maxIndex; i++)
            {
                tempArray[index] = list[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                list[minIndex + i] = tempArray[i];
                
            }
        }

        //Сортировка слиянием
        public static T[] MergeSort<T>(T[] list, int minIndex, int maxIndex) where T : IComparable
        {
            if (minIndex < maxIndex)
            {
                var middleIndex = (minIndex + maxIndex) / 2;
                MergeSort(list, minIndex, middleIndex);
                MergeSort(list, middleIndex + 1, maxIndex);
                Merge(list, minIndex, middleIndex, maxIndex);
            }

            return list;
        }
    }
}

