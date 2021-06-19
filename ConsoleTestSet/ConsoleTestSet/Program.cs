using System;
using System.Collections.Generic;

namespace ConsoleTestSet
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Sets
            Console.WriteLine("Test Set");
            int[] m1 = { 2, 6 };
            int[] m2 = { 3, 6, 9 };
            string[] ms = { "Masha", "Aidar", "Kolja" };
            Set<int> s1 = new Set<int>(m1);
            Set<int> s2 = new Set<int>(m2);
            Set<string> ss = new Set<string>(ms);
            Console.WriteLine("s1={0}", s1);
            Console.WriteLine("s2={0}", s2);
            Console.WriteLine("ss={0}", ss);
            Set<int> s3 = s1.Union(s2);
            Console.WriteLine("s3={0}", s3);
            s2.Add(7);
            Console.WriteLine("Size= {0} Count={1} Set={2}", s2.Size,s2.Count,s2);
            Set<int> s4 = s1 + s2 + s3;
            Console.WriteLine("s4={0}", s4);
            List<Set<int>> ls = s2.GetList();
            foreach (var curs in ls)
                Console.WriteLine(curs);
            // Test Sorting
            double[] mas = { -2.5, 0.4, 6, -3.0, 8.1, -6.66, 2.11 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas.Length; i++)
                Console.Write("{0}\t", mas[i]);
            Console.WriteLine();
            Sort.BubbleSort<double>(mas);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas.Length; i++)
                Console.Write("{0}\t", mas[i]);
            Console.WriteLine();
            double[] mas2 = { 10.5,-2.5, 0.4, 6, -3.0, 8.1, -6.66, 2.11 };
            Console.WriteLine("Before Array");
            for (int i = 0; i < mas2.Length; i++)
                Console.Write("{0}\t", mas2[i]);
            Console.WriteLine();
            Sort.BubbleSortSwap<double>(mas2);
            Console.WriteLine("After Array");
            for (int i = 0; i < mas2.Length; i++)
                Console.Write("{0}\t", mas2[i]);
            Console.WriteLine("____________");
            /*List<Set<int>> ls2 = s4.Perest();*/
            /*Console.WriteLine("s4={0}", s2.Perest());*/

            #endregion
            #region SLists
            SList<string> Slist = new SList<string>();

            Console.WriteLine("Список состоит из: ");

            Slist.AddEnd("Удал", 0);
            Slist.AddEnd("Ро", 1);
            Slist.AddEnd("C", 2);
            Slist.AddEnd("Т", 3);
            Slist.AddEnd("Удал", 4);

            Slist.RemoveTop();//удаляем элемент
            Slist.RemoveEnd();
            Slist.AddTop("О", 0);
            Slist.AddEnd("Н", 4);
            Slist.View();

            Console.WriteLine("Наличие J {0}", Slist.IsContainsByValue("О"));
            Console.WriteLine("Наличие op {0}", Slist.IsContainsByValue("op"));

            Console.WriteLine("Поиск J {0}", Slist.FindByValue("О"));
            Console.WriteLine("Поиск J {0}", Slist.FindByKey(0));
            Console.WriteLine("Поиск H {0}", Slist.FindByIndex(4));


            Console.WriteLine("Insert");
            Slist.InsertAfterValue(5, "<V", "C");
            Slist.InsertBeforeValue(6, "V>", "C");

            Slist.View();


            Slist.RemoveByValue("Н");//удаляет следующий
            Slist.RemoveByIndex(2);
            Slist.RemoveByKey(4);

            Slist.View();
            #endregion
            #region Dlist
            DList<string> dlist = new DList<string>();
            Console.WriteLine("Dlist: ");
            dlist.AddEnd("Ор",1);
           
            dlist.AddEnd("Ф",2);
            dlist.AddEnd("П",3);
            dlist.AddEnd("В",4);
            dlist.AddTop("Ка",0);
            
            dlist.View();
            dlist.ViewBack();
            dlist.RemoveTop();
            dlist.RemoveEnd();
            dlist.View();
            dlist.ViewBack();
            Console.WriteLine("Наличие Ф {0}", dlist.IsContainsByValue("Ф"));
            Console.WriteLine("Наличие Л {0}", dlist.IsContainsByValue("Л"));

            Console.WriteLine("Поиск Значение {0}", dlist.FindByValue("Ф"));
            Console.WriteLine("Поиск Ключ {0}", dlist.FindByKey(1));
            Console.WriteLine("Поиск Индекс {0}", dlist.FindByIndex(2));


            Console.WriteLine("Insert");
            dlist.InsertAfterValue(5, "<V", "Ф");
            dlist.InsertBeforeValue(6, "V>", "Ф");

            dlist.View();
            dlist.ViewBack();

            Console.WriteLine("Remove 1 Ор, 3 П,2 Ф");
            Console.WriteLine(dlist.count);

            dlist.RemoveByValue("Ор");
             dlist.RemoveByIndex(3);//последнее
             dlist.RemoveByKey(2);
            Console.WriteLine("");
            
           
            dlist.View();
            dlist.ViewBack();




            #endregion
            #region BinTree
            Console.WriteLine("______________Tree_____________");
            var btr = new BinaryTree<string>();
            btr.AddNode(10, "aaa");
            btr.AddNode(15, "aawda");
            btr.AddNode(5, "addassa");
            btr.AddNode(25, "aa121a");
            btr.AddNode(8, "aafwa");
            btr.AddNode(7, "dsaaa");
            btr.AddNode(13, "svaaa");
            btr.AddNode(14, "4taaa");
            btr.AddNode(21, "qdaaaa");
            btr.View1(btr.root);
            Console.WriteLine("Search 7= {0}", btr.Search(7));
            Console.WriteLine("NextNode 15= {0}", btr.NextNode(15));
            Console.WriteLine("PrevNode 21= {0}", btr.PrevNode(21));
            /*btr.LeftRotate(10);
            btr.RightRotate(10);*/
            /*btr.DeleteNode(7);*/
            /*btr.DeleteNode(10);*/
            Console.WriteLine("____________");
            btr.View1(btr.root);
            
            #endregion
            #region HashTable
            Console.WriteLine("Хэш-таблицы");
            var hlist = new HashTable<string>(6);
            hlist.Add(32, "aaaa33333");
            hlist.Add(3, "bbbbb67");
            hlist.Add(17, "cccd");
            hlist.Add(25, "ssddaa");
            hlist.Add(11001, "jhjhjkl");
            hlist.Add(777, "saasa");
            hlist.Add(444, "saweadsds");
            hlist.Add(30, "tryryutr");
            hlist.Add(99, "sesesesese");
            hlist.View();
            Console.WriteLine();
            Console.WriteLine("Search {0}", hlist.Search(3));
            hlist.DeleteKey(444);
            Console.WriteLine("He Search {0}", hlist.Search(444));
            hlist.View();
            Console.WriteLine();
            Console.WriteLine("Хэш-таблицы LIST");
            var HashList = new HTLIST<string>(3);
            HashList.Add(32, "ses33333");
            HashList.Add(34, "aaa9833333");
            HashList.Add(377, "a=3");
            HashList.Add(123, "=apoo3");
            HashList.Add(555, "aakka");
            Console.WriteLine("{0}",HashList.Search(377));
            HashList.View();
            HashList.DeleteKey(377);
            Console.WriteLine("DELITED___________");
            HashList.View();
            #endregion
            #region Graph
            Console.WriteLine("Test Graph!\n");

            Graph graph = new Graph();
            Vertex v1 = new Vertex("A",2);
            Vertex v2 = new Vertex("B",3);
            Vertex v3 = new Vertex("C",5);
            Vertex v4 = new Vertex("D",1);
            Vertex v5 = new Vertex("E",9);
            Vertex v6 = new Vertex("F",4);
            Vertex v7 = new Vertex("G",7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

         
           graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);
            graph.AddEdge(v5, v6);
            graph.AddEdge(v4, v7);
            graph.AddEdge(v6, v7);

            graph.ViewGraph();

            graph.BFS(v1);
            Console.WriteLine("\nTest BFS --- Start");
            graph.ViewBFS(v1);
            //TODO
            Console.WriteLine("\nTest DFS --- Start");
            graph.DFS(v1);
            
                graph.PrintPath(v1, v7);
            
            Console.WriteLine("Test DFS --- End\n");
           


            #endregion
        }
    }
}
