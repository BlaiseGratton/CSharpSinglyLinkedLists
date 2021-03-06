﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            foreach (object item in values)
            {
                 AddLast(item.ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set {
                    SinglyLinkedListNode node = firstNode;
                    for (int index = i; index > 1; index--)
                    {
                        node = node.Next;
                    }
                    var temp = node.Next.Next;
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                    newNode.Next = temp;
                    node.Next = newNode;
                }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode node = this.firstNode;
            while (true)
            {
                if (node.Value == existingValue)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                    newNode.Next = node.Next;
                    node.Next = newNode;
                    break;
                }
                node = node.Next;
                if (node == null)
                {
                    throw new System.ArgumentException();
                }
            }
        }

        public void AddFirst(string value)
        {
            if (this.firstNode == null)
            {
                this.firstNode = new SinglyLinkedListNode(value);
                return;
            }
            SinglyLinkedListNode node = new SinglyLinkedListNode(value);
            node.Next = this.firstNode;
            this.firstNode = node;
        }

        public void AddLast(string value)
        {
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
                return;
            }

            SinglyLinkedListNode node = this.firstNode;
            while (true)
            {
                if (node.Next == null)
                {
                    node.Next = new SinglyLinkedListNode(value);
                    break;
                }
                node = node.Next;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            if (firstNode == null)
            {
                return 0;
            }
            int counter = 0;
            SinglyLinkedListNode node = firstNode;
            while (true)
            {
                counter++;
                if (node.Next == null)
                {
                    return counter;
                }
                node = node.Next;
            }
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode node = firstNode;
            if (node == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index > this.Count() - 1)
            {
                throw new ArgumentOutOfRangeException();
            } 
            for (; index > 0; index--)
            {
               
                node = node.Next;
            }
            return node.ToString();
        }

        public string First()
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            if (firstNode == null)
            {
                return -1;
            }
            int index = 0;
            SinglyLinkedListNode node = firstNode;
            while (true)
            {
                if (node.Value == value)
                {
                    return index;
                }
                if (node.Next == null)
                {
                    return -1;
                }
                node = node.Next;
                index++;
            }
        }

        public bool IsSorted()
        {
            if (firstNode == null)
            {
                return true;
            }
            SinglyLinkedListNode node = firstNode;
            while (true)
            {
                if (node.Next == null)
                {
                    return true;
                } 
                if (node.Next < node)
                {
                    return false;
                }
                node = node.Next;
            }
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (this.firstNode == null)
            {
                return null;
            }
            int counter = 0;
            SinglyLinkedListNode node = firstNode;
            while (true)
            {
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
                counter++;
            }
            return this.ElementAt(counter);
        }

        public void Remove(string value)
        {
            SinglyLinkedListNode node = firstNode;
            if (node.Value == value)
            {
                this.firstNode = firstNode.Next;
                return;
            }
            while (true)
            {
                if (node.Next == null)
                {
                    return;
                }
                if (node.Next.Value == value)
                {
                    node.Next = node.Next.Next;
                    break;
                }
                
                node = node.Next;
            }
        }

        public void Sort()
        {
            SinglyLinkedListNode node = firstNode;
            if (node == null)
            {
                return;
            }
            while (true)
            {
                if (node.Next == null)
                {
                    break;
                }
                if(firstNode.Next < firstNode)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(firstNode.Value);
                    newNode.Next = firstNode.Next.Next;
                    firstNode = firstNode.Next;
                    firstNode.Next = newNode;
                    node = firstNode;
                }
                if (node.Next.Next == null)
                {
                    break;
                }
                if (node.Next.Next < node.Next)
                {
                    SinglyLinkedListNode node1 = new SinglyLinkedListNode(node.Next.Value);
                    SinglyLinkedListNode node2 = new SinglyLinkedListNode(node.Next.Next.Value);
                    node2.Next = node1;
                    node1.Next = node.Next.Next.Next;
                    node.Next = node2;
                    node = firstNode;
                }
                node = node.Next;
                if (node.Next < node)
                {
                    node = firstNode;
                }
            }
        }

        public string[] ToArray()
        {
            if (this.firstNode == null)
            {
                return new string[] { };
            }
            List<string> array = new List<string> { };
            SinglyLinkedListNode node = this.firstNode;
            while (true)
            {
                array.Add(node.Value);
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
            }
            return array.ToArray<string>();
        }

        public override string ToString()
        {
            if (this.firstNode == null)
            {
                return "{ }";
            }
            StringBuilder listString = new StringBuilder("{ \"");
            SinglyLinkedListNode node = this.firstNode;
            while (true)
            {
                listString.Append(node.ToString());
                if (node.Next == null)
                {
                    break;
                }
                listString.Append("\", \"");
                node = node.Next; 
            }
            listString.Append("\" }");
            return listString.ToString();
        }
    }
}
