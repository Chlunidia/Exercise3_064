using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /* Creates Nodes for the circular nexted list */
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        // Add new node
        public void InsertNode()
        {
            // Create variable studentNo and studentName
            int studentNo;
            string studentName;
            Console.Write("\nEnter the roll number of the student : ");
            studentNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            studentName = Console.ReadLine();
            // Add new object named newNode
            Node newNode = new Node();
            // Create node list saver
            newNode.rollNumber = studentNo;
            newNode.name = studentName;
            // Create condition if the list is empty
            if (listEmpty())
            {
                newNode.next = newNode;
                LAST = newNode;
            }
            // Add new node from the left of the list
            else if (studentNo < LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
            }
            // Add new node from the right of the list
            else if (studentNo > LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
                LAST = newNode;
            }
            // Add new node in the middle of the list
            else
            {
                Node curr, prev;
                curr = prev = LAST.next;
                int i = 0;
                while (i < studentNo - 1)
                {
                    prev = curr;
                    curr = curr.next;
                    i++;
                }
                newNode.next = curr;
                prev.next = newNode;
            }
        }
        // Delete recorded node
        public bool deleteNode(int rollNumber)
        {
            // Create variable previous and current
            Node previous, current;
            previous = current = LAST.next;
            // Check the specification of the node
            if (Search(rollNumber, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (LAST.next.rollNumber == LAST.rollNumber)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (rollNumber == LAST.next.rollNumber)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current) /*searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber) /*if the node is present at the end*/
                return true;
            else
                return (false); /*returns false if the node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() /*traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.WriteLine(currentNode.rollNumber + "   " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.WriteLine(LAST.rollNumber + "   " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "   " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add new record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for the record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                // Add new node
                                obj.InsertNode();
                            }
                            break;
                        case '2':
                            {
                                // Check the record in the nodes list
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                // Searches the student whose record is to be delete
                                Console.Write("\nEnter the roll number of " + "the student whose record is to be deleted: ");
                                int studentNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                // deleteNode output
                                if (obj.deleteNode(studentNo) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                    Console.WriteLine("Record with roll number " + studentNo + " deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}