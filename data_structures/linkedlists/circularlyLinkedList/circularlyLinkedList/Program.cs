using System;

namespace circularlyLinkedList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CircularlyLinkedList<int> cll = new CircularlyLinkedList<int>();

            for (int i = 0; i < 20; i += 2){
                cll.insert(i);
            }
            cll.insert(-2);
            cll.insert(33);
            cll.insert(-10);
            cll.insert(-4);
            cll.delete(-10);
            cll.delete(-4);
            cll.delete(33);
            cll.delete(18);
            Console.WriteLine(cll.delete(8));
            Console.WriteLine(cll.delete(9));
            cll.print();
        }
    }

    class CircularlyLinkedList<T> where T : IComparable{
        private class Node{
            public T val;
            public Node next;
        }

        public CircularlyLinkedList(){
            last = null;
        }
        public void insert(T val){
            Node n = new Node();
            n.val = val;
            n.next = null;
            if (last == null){ // list is empty
                last = n;
                last.next = last; // loop back to itself, list size 1
            }
            else{ // list is non empty
                Node prev = last;
                Node cur = last.next; // front of the list

                while (n.val.CompareTo(cur.val) > 0 && cur != last){
                    prev = cur;
                    cur = cur.next;
                }
                if (cur == last && n.val.CompareTo(last.val) > 0){
                    n.next = last.next;
                    last.next = n;
                    last = n;
                }
                else{
                    n.next = cur;
                    prev.next = n;
                } 
            }
        }
        public bool delete(T val){
            if (last != null){ // non empty list
                Node prev = last;
                Node cur = last.next;
                do
                {
                    if (val.CompareTo(cur.val) == 0){ // found value to remove
                        if (prev == cur){// one element in list
                            cur.next = null;
                            last = null;
                        }
                        else if (cur == last){
                            prev.next = last.next;
                            last.next = null;
                            last = prev;
                        }
                        else{
                            prev.next = cur.next;
                            cur.next = null;
                        }
                        return true;
                    }
                    prev = cur;
                    cur = cur.next;
                }
                while (cur != last.next);
            }      
            return false;
        }
        public void print(){
            Node start = last.next;
            do
            {
                Console.Write(start.val + " -> ");
                start = start.next;
            }
            while (start != last.next);
        }

        private Node last;
    }
}
