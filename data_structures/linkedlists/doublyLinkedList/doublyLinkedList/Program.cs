using System;

namespace doublyLinkedList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            for (int i = 0; i < 20; i+=2){
                dll.append(i);
            }
            dll.insert(13);
            dll.insert(-1);
            dll.insert(100);
            dll.delete(6);
            dll.delete(-1);
            dll.delete(100);
            dll.delete(0);
            dll.print();
        }
    }

    public class DoublyLinkedList<T> where T : IComparable
    {
        private class Node<T>{
            public T val;
            public Node<T> next;
            public Node<T> prev;
        }
        public DoublyLinkedList(){
            head = null;
        }
        public void append(T val){
            Node<T> n = new Node<T>();
            n.val = val;
            n.next = null;
            n.prev = null;
            if (head == null){ // list is empty
                head = n;
            }
            else{ // list is non empty
                Node<T> prev = null;
                Node<T> cur = head;

                while (cur != null){
                    prev = cur;
                    cur = cur.next;
                }
                prev.next = n;
                n.prev = prev;
            }
        }
        public void insert(T val){
            Node<T> n = new Node<T>();
            n.val = val;
            n.next = null;
            if (head == null){ // list is empty
                head = n;
            }
            else{ // non empty list
                Node<T> prev = null;
                Node<T> cur = head;
                while (cur != null && (n.val).CompareTo(cur.val) > 0){
                    prev = cur;
                    cur = cur.next;
                }
                if (prev == null){ // insert at front
                    n.next = cur;
                    cur.prev = n;
                    head = n;
                }
                else if (cur == null){// insert at end
                    prev.next = n;
                    n.prev = prev;
                }
                else{ // insert at middle
                    prev.next = n;
                    n.prev = prev;
                    n.next = cur;
                    cur.prev = n;
                }
            }
        }
        /* remove a value if found and returns true, otherwise returns false */
        public bool delete(T val)
        {
            Node<T> cur = head;
            Node<T> prev = null;
            while (cur != null){
                if (cur.val.CompareTo(val) == 0){
                    if (prev == null){ // delete from front
                        head = cur.next;
                        head.prev = null;
                        cur.next = null;
                    }
                    else if (cur.next == null){ // delete end
                        prev.next = null;
                        cur.prev = null;
                    }
                    else{ // delete middle
                        prev.next = cur.next;
                        cur.next.prev = prev;
                        cur.next = null;
                        cur.prev = null;
                    }
                    return true;
                }
                prev = cur;
                cur = cur.next;
            }
            return false;
        }

        /* prints the list forwards on one line and backwards on the next */
        public void print(){
            Node<T> cur = head;
            Node<T> prev = null;
            while (cur != null){
                Console.Write(cur.val + " -> ");
                prev = cur;
                cur = cur.next;
            }
            Console.Write("null");
            Console.WriteLine();
            while (prev != null){
                Console.Write(prev.val + " -> ");
                prev = prev.prev;
            }
            Console.Write("null");
        }

        private Node<T> head;
    }
}
