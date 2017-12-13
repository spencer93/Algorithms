using System;

namespace singlyLinkedList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList sll = new SinglyLinkedList();
            for (int i = 1; i < 20; i+=2){
                sll.insert(i);
            }
            sll.insert(0);
            sll.insert(-1);
            sll.insert(8);
            sll.insert(100);
            Console.WriteLine(sll.delete(19));
            Console.WriteLine(sll.delete(19));
            sll.print();
        }
    }
    /* non generic singly linked list */
    class SinglyLinkedList{

        private class Node
        {
            public int val;
            public Node next;

        }

        public SinglyLinkedList(){
            head = null;
        }
        /* adds a value to the end of this list */
        public void append(int num){
            if (head == null)
            { // list is empty
                Node n = new Node();
                n.val = num;
                n.next = null;
                head = n;
            }
            else
            { // non empty list
                Node prev = null;
                Node cur = head;
                while (cur != null){
                    prev = cur;
                    cur = cur.next;
                }
                Node n = new Node();
                n.val = num;
                n.next = null;
                prev.next = n;
            }
        }
        /* inserts a value into this list */
        public void insert(int num){
            Node n = new Node();
            n.val = num;
            n.next = null;

            if (head == null){ // list is empty
                head = n;
            }
            else{
                Node prev = null;
                Node cur = head;
                while (cur != null && num > cur.val){
                    prev = cur;
                    cur = cur.next;
                }
                if (prev == null){ // insert at front, while loop never entered 
                    n.next = cur;
                    head = n;
                }
                else if (cur == null){ // insert at end
                    prev.next = n;
                }
                else{ // insert in middle
                    prev.next = n;
                    n.next = cur;
                }
            }
        }
        /* removes a value from this list if it exists and returns true, returns
         * false if value not found */
        public bool delete(int num){
            Node prev = null;
            Node cur = head;
            while (cur != null){
                if (cur.val == num){ // found the value, remove it
                    if (prev == null){ // removing at front of list
                        head = cur.next;
                        cur.next = null;
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
            return false;
        }
        public void print(){
            Node cur = head;
            while (cur != null){
                Console.Write(cur.val + " -> ");
                cur = cur.next;
            }
            Console.Write("null");
        }

        private Node head;
    }
}
