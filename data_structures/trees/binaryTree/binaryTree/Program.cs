using System;

namespace binaryTree
{
    class MainClass
    {
        public static void Main(){
            BinaryTree<int> bst = new BinaryTree<int>();
            Console.Write("test");
        }
      
      
    }

    public class BinaryTree<T> where T : IComparable{

        private class Node{
            public T val;
            public Node left;
            public Node right;
        }

        public BinaryTree(){
            root = null;
        }

        public void insert(T val){
            Node n = new Node();
            n.val = val;
            n.left = null;
            n.right = null;

            if (root == null){
                root = n;
            }
            else{ // non empty tree
                Node prev = null;
                Node cur = null;

                while (cur != null){
                    prev = cur;
                    if (val.CompareTo(cur.val) > 0){
                        cur = cur.right;
                    }
                    else if (val.CompareTo(cur.val) < 0){
                        cur = cur.left;
                    }
                    else { // duplicate value do not insert
                        return;
                    }
                }
                if (prev.right == cur){
                    prev.right = n;
                }
                else if (prev.left == cur){
                    prev.left = n;
                }
            } 
        }

        public void remove(T val){
            
        }
        public void printInorder(){
            
        }
        public void printPreOrder(){
            
        }
        public void printPostOrder(){
            
        }

        private Node root;
    }
}
