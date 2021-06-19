using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestSet
{
    public class BinaryTree<T>
    {

        public NodeTree<T> root;
        public int countNode;
        public BinaryTree(NodeTree<T> r = null)
        {
            root = r;
        }


        public void AddNode(int k, T value)
        {
            if (root == null) { root = new NodeTree<T>(k, value); return; }
            var tmp = root;
            while (tmp != null)
            {
                if (tmp.key == k) return;
                if (tmp.key > k)
                {
                    if (tmp.Left != null) { tmp = tmp.Left; }
                    else
                    {
                        var nnn = new NodeTree<T>(k, value);
                        nnn.Parent = tmp;
                        tmp.Left = nnn;

                    }
                }
                if (tmp.key < k)
                {
                    if (tmp.Right != null) { tmp = tmp.Right; }
                    else
                    {
                        var nnn = new NodeTree<T>(k, value);
                        nnn.Parent = tmp;
                        tmp.Right = nnn;

                    }
                }
            }

        }

        public void View1(NodeTree<T> tmp)
        {
            if (tmp != null)
            {
                if (tmp.Left != null) View1(tmp.Left);
                Console.WriteLine(tmp);
                if (tmp.Right != null) View1(tmp.Right);
            }
        }
        public void View2(NodeTree<T> tmp)
        {
            if (tmp != null)
            {
                if (tmp.Right != null) View2(tmp.Right);
                Console.WriteLine(tmp);
                if (tmp.Left != null) View2(tmp.Left);
            }
        }
        public void View3(NodeTree<T> tmp)
        {
            if (tmp != null)
            {
                Console.WriteLine(tmp);
                if (tmp.Left != null) View3(tmp.Left);
                if (tmp.Right != null) View3(tmp.Right);
            }
        }


        public NodeTree<T> Search(int k)
        {
            if (root == null) { return null; }
            var tmp = root;
            while (tmp != null)
            {
                if (tmp.key == k) return tmp;
                else if (tmp.key > k)
                {
                    if (tmp.Left != null) tmp = tmp.Left;
                    else break;
                }
                else if (tmp.key < k)
                {
                    if (tmp.Right != null) tmp = tmp.Right;
                    else break;
                }
                else
                {
                    break;
                }
            }
            return null;
        }
        public bool DeleteNode(int k)
        {
            var nod = Search(k);
            if (nod == null) return false;
            if (nod.Right == null && nod.Left == null)
            {
                if (nod == root) { root = null; return true; }
                if (nod.Parent.Right == nod) { nod.Parent.Right = null; return true; }
                if (nod.Parent.Left == nod) { nod.Parent.Left = null; return true; }

            }
            if (nod.Right == null && nod.Left != null)
            {
                if (nod == root) { root = root.Left; return true; }
                if (nod.Parent.Right == nod) { nod.Parent.Right = nod.Left; return true; }
                if (nod.Parent.Left == nod) { nod.Parent.Left = nod.Left; return true; }

            }
            if (nod.Right != null && nod.Left == null)
            {
                if (nod == root) { root = root.Right; return true; }
                if (nod.Parent.Right == nod) { nod.Parent.Right = nod.Right; return true; }
                if (nod.Parent.Left == nod) { nod.Parent.Left = nod.Right; return true; }

            }

            if (nod.Right != null && nod.Left != null)
            {
                var tmp = MinNode(nod.Right);//справого минимальное 
                DeleteNode(MinNode(nod.Right).key);
                tmp.Left = nod.Left;
                tmp.Right = nod.Right;
                if (nod == root)
                {
                    root = tmp;
                    tmp.Parent = null;
                }
                else
                {
                    if (nod.Parent.Left == nod) nod.Parent.Left = tmp;
                    else nod.Parent.Right = tmp;
                    tmp.Parent = nod.Parent;
                }

                nod.Parent = null;
                nod.Left = null;
                nod.Right = null;
                return true;
            }
            return false;
        }

        public void LeftRotate(int k)
        {
            if (Search(k) == null) return;
            var x = Search(k);
            var Nroot = x.Right;
            Nroot.Left.Parent = x.Right.Parent;
            x.Right = Nroot.Left;
            if (x != root)
            {
                if (x.Parent.Left == x) x.Parent.Left = Nroot;
                else x.Parent.Right = Nroot;
                Nroot.Parent = x.Parent;
            }
            else
            {

                Nroot.Parent = null;
                root.Parent = Nroot;
                root = Nroot;

            }

            Nroot.Left = x;


        }
        public void RightRotate(int k)
        {
            if (Search(k) == null) return;
            var x = Search(k);
            var Nroot = x.Left;
            Nroot.Right.Parent = x.Left.Parent;
            x.Left = Nroot.Right;
            if (x != root)
            {
                if (x.Parent.Right == x) x.Parent.Right = Nroot;
                else x.Parent.Left = Nroot;
                Nroot.Parent = x.Parent;
            }
            else
            {

                Nroot.Parent = null;
                root.Parent = Nroot;
                root = Nroot;
            }
            Nroot.Right = x;
        }
        public NodeTree<T> MinNode(NodeTree<T> t)
        {
            while (t.Left != null)
            {
                t = t.Left;
            }
            return t;
        }
        public NodeTree<T> MaxNode(NodeTree<T> t)
        {
            while (t.Right != null)
            {
                t = t.Right;
            }
            return t;
        }
        public NodeTree<T> NextNode(int k)
        {
            if (Search(k) == null) return null;
            var maz = MaxNode(root).key;
            k = k + 1;
            while (k != maz)
            {
                if (Search(k) != null) return Search(k);
                k++;
            }
            return null;
        }
        public NodeTree<T> Next(NodeTree<T> tmp)
        {
            if (tmp == null) return null;
            int k = tmp.key;
            if (Search(k) == null) return null;
            var maz = MaxNode(root).key;
            k = k + 1;
            while (k != maz)
            {
                if (Search(k) != null) return Search(k);
                k++;
            }
            return null;
        }
        public NodeTree<T> PrevNode(int k)
        {

            if (Search(k) == null) return null;
            var min = MinNode(root).key;
            k = k - 1;
            while (k != min)
            {
                if (Search(k) != null) return Search(k);
                k--;
            }
            return null;
        }
        public NodeTree<T> Prev(NodeTree<T> tmp)

        {
            if (tmp == null) return null;
            int k = tmp.key;
            if (Search(k) == null) return null;
            var min = MinNode(root).key;
            k = k - 1;
            while (k != min)
            {
                if (Search(k) != null) return Search(k);
                k--;
            }
            return null;
        }


    }
}
#region DEL
/*public bool DeleteNode(int k)
        {
            var nod = Search(k);
            if (nod == null) return false;
            if (nod.Right != null && nod.Left == null)
            {
                if (nod.Parent.Right == nod) nod.Parent.Right = nod.Right;
                else if (nod.Parent.Left == nod) nod.Parent.Left = nod.Right;
                return;
            }
            if (nod.Right == null && nod.Left != null)
            {
                if (nod.Parent.Right == nod) nod.Parent.Right = nod.Left;
                else if (nod.Parent.Left == nod) nod.Parent.Left = nod.Left;
                return;
            }
            if (nod.Right != null && nod.Left != null)
            {
                var tmp = MinNode(nod);
                nod.Parent.Right = tmp;
                while (true)
                {
                    if (nod.Left == null && nod.Right == null) break;
                    else if (MinNode(nod.Left) != null) { tmp.Right = MinNode(nod.Left); DeleteNode(nod.Left.key); }
                    else if (MaxNode(nod.Left) != null) { tmp.Right = MaxNode(nod.Right); DeleteNode(nod.Right.key); }
                    else if (MinNode(nod.Left) == null && MaxNode(nod.Left) == null) break;
                }
            }
        }*/
/*public void AddNodeV(NodeTree<T> nod)
        {
            if (root == null) root = nod;
            var n = root;
            while (n != null)
            {
                if (n.Value.CompareTo(nod.Value) > 0)
                {
                    //n>nod
                    if (n.Left == null) { n.Left = nod; nod.prev = n; break; }
                    n = n.Left;
                }
                else if (n.Value.CompareTo(nod.Value) < 0)
                {
                    //n<nod
                    if (n.Right == null)
                    {
                        n.Right = nod; nod.prev = n;
                        break;
                    }
                    n = n.Right;
                }
            }

        }*/
/* public void View(NodeTree<T> r)
        {
            if (r == null) return;
            Console.Write(r);
            if (r.Right != null && r.Left != null)
            {
                View(r.Right);
                View(r.Left);
                Console.WriteLine();
            }
            else
            {
                if (r.Right == null&& r.Left != null) View(r.Left);
                else if (r.Left == null&& r.Right != null) View(r.Right);
                else if(r.Right == null && r.Left == null) return;
                Console.WriteLine();
            }
        }*/
/*public NodeTree<T> Search(int ke)
        {
            var nod = root;
            if (nod.key == ke) return nod;
            else
            {
                if (nod.Right == null&& nod.Left != null) Search(ke, nod.Left);
                else if (nod.Left == null&& nod.Right != null) Search(ke, nod.Right);
                else if (nod.Left == null && nod.Right == null) return null;
                else
                {
                    Search(ke, nod.Right);
                    Search(ke, nod.Left);
                }
            }
            return null;
        }*/
#endregion