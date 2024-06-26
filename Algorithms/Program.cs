// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompileCs
{
    class Program
    {
        public List<T> FilterList<T>(List<T> list, Func<T, bool> predicate)
        {
            return list.Where(predicate).ToList();
        }
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("This is working!");
            //Arrays();
            //LinkedList();
            //BinaryTreeComplete();
            //Problems problem = new Problems();
            //problem.Hello();

            //2 Implement an Asynchronous Method Using async and await
            var requester = new WebRequester();
            string content = await requester.GetWebContentAsync("https://example.com");
            Console.WriteLine(content);

            //3 Implement an Event and an Event Handler(events and delegates)
            var publisher = new Publisher();
            var subscriber = new Subscriber();
            subscriber.Subscribe(publisher);
            publisher.RaiseEvent();

            //4 Implement a Custom IEnumerable<T> Collection
            var collection = new CustomCollection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            //5 Implement a Thread-Safe Blocking Queue (Knowledge of threading, synchronization, and concurrency.)
            var blockingQueue = new BlockingQueue<int>();
            var producer = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    blockingQueue.Enqueue(i);
                    Thread.Sleep(100); // Simulate work
                }
            });

            var consumer = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var item = blockingQueue.Dequeue();
                    Console.WriteLine($"Dequeued: {item}");
                }
            });

            producer.Start();
            consumer.Start();
            producer.Join();
            consumer.Join();

            //6
            var demo = new Program();

            var intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = demo.FilterList(intList, n => n % 2 == 0);

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number); // 2, 4, 6, 8, 10
            }

            var stringList = new List<string> { "apple", "banana", "cherry", "date" };
            var longStrings = demo.FilterList(stringList, s => s.Length > 5);

            foreach (var str in longStrings)
            {
                Console.WriteLine(str); // banana, cherry
            }
        }

        static void Hello()
        {
           System.Console.WriteLine("Hello");
        }

        //O(1)
        static void BigOSimple()
        {
            int[] algo = {1,2,3};
            System.Console.WriteLine(algo[0]);
        }


        //O(n)
        static void BigOMedium()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(i);
            }
        }


        //O(n+2)
        static void BigOMediumPlus2()
        {
            System.Console.WriteLine("hi");
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(i);
            }
            System.Console.WriteLine(2);
        }


        //O(n^2)
        static void BigOComplex()
        {
            System.Console.WriteLine("hi");
            for (int i = 0; i < 10; i++)
            {
                for (int p = 0; i < 20; p++)
                {
                    System.Console.WriteLine(p);
                }
            }
            System.Console.WriteLine(2);
        }

        //O(logn)
        static void BigOLog()
        {
            System.Console.WriteLine("hi");
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(i);
            }
            System.Console.WriteLine(2);
        }

        //O(2^n)
        static void BigOWorst()
        {

        }

        //Arrays
        static void Arrays()
        {
            int[] algo = {1,2,3};
            algo[0] = algo[0] < 3 ? 5 : 2; 
            System.Console.WriteLine(algo[0]);
        }

        //LinkedList add, last, first, indexOf, contains, removeFirst, removeLast, size,
        static void LinkedList()
        {
            // Creating a linked list using LinkedList class
            LinkedList<string> my_list = new LinkedList<string>();

            // Adding elements to the LinkedList using AddLast() method
            my_list.AddLast("Potato");
            my_list.AddLast("Papa");
            my_list.AddLast("Termo");
            my_list.AddLast("Mate");
            my_list.AddLast("Babe");
            my_list.AddLast("Pipi");

            Console.WriteLine("Best students of XYZ university:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // Deleting the last element
            my_list.RemoveLast();
            Console.WriteLine("\nLinked list after removing the last item:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // Checking the first index value
            if (my_list.First != null)
            {
                Console.WriteLine("\nFirst index value: " + my_list.First.Value);
            }

            // Check a value on a random index (e.g., index 2)
            int index = 2;
            if (index < my_list.Count)
            {
                LinkedListNode<string> current = my_list.First;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                Console.WriteLine("\nValue at index " + index + ": " + current.Value);
            }

            // Remove the first item
            my_list.RemoveFirst();
            Console.WriteLine("\nLinked list after removing the first item:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // Remove the last item again
            my_list.RemoveLast();
            Console.WriteLine("\nLinked list after removing the last item again:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // Check the size of the list
            Console.WriteLine("\nSize of the list: " + my_list.Count);
        }

        //LinkedList Reverse
        static void ReverseLinkedListCompletly()
        {
            LinkedList<string> my_list = new LinkedList<string>();

            // Adding elements to the LinkedList using AddLast() method
            my_list.AddLast("Potato");
            my_list.AddLast("Papa");
            my_list.AddLast("Termo");
            my_list.AddLast("Mate");
            my_list.AddLast("Babe");
            my_list.AddLast("Pipi");

            Console.WriteLine("Original Linked list:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            // Reverse the linked list
            my_list = ReverseLinkedList(my_list);

            Console.WriteLine("\nReversed Linked list:");
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }
        }

        static LinkedList<string> ReverseLinkedList(LinkedList<string> list)
        {
            LinkedList<string> reversedList = new LinkedList<string>();
            foreach (var item in list)
            {
                reversedList.AddFirst(item);
            }
            return reversedList;
        }

        //LinkedList find 1 middle odd or 2 middle even
        static void PrintMiddleElements(LinkedList<string> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            // Move fast pointer two steps and slow pointer one step at a time
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // If the list has an even number of elements, fast will be null
            if (fast == null)
            {
                Console.WriteLine("Middle elements: " + slow.Previous.Value + " and " + slow.Value);
            }
            else
            {
                Console.WriteLine("Middle element: " + slow.Value);
            }
        }

        //stack
        static void SimpleStack()
        {
            {
 
                // Create a stack
                // Using Stack class
                Stack my_stack = new Stack();
        
                // Adding elements in the Stack
                // Using Push method
                my_stack.Push("Geeks");
                my_stack.Push("geeksforgeeks");
                my_stack.Push('G');
                my_stack.Push(null);
                my_stack.Push(1234);
                my_stack.Push(490.98);
                //my_stack.Pop();
                //my_stack.Clear();
        
                // Accessing the elements
                // of my_stack Stack
                // Using foreach loop
                foreach(var elem in my_stack)
                {
                    Console.WriteLine(elem);
                }
            }
        }
        //queue
        static void SimpleQueue()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("1");
            numbers.Enqueue("2");
            numbers.Enqueue("3");
            numbers.Enqueue("4");
            numbers.Enqueue("5");

            // A queue can be enumerated without disturbing its contents.
            foreach( string number in numbers )
            {
                Console.WriteLine(number);
            }
        }

        //Hash Table
        static void HashTable()
        {
            Hashtable my_hashtable1 = new Hashtable();
    
            my_hashtable1.Add("A1", "Welcome");
            my_hashtable1.Add("A2", "to");
            my_hashtable1.Add("A3", "GeeksforGeeks");
    
            Console.WriteLine("Key and Value pairs from my_hashtable1:");
    
            foreach(DictionaryEntry ele1 in my_hashtable1)
            {
                Console.WriteLine("{0} and {1} ", ele1.Key, ele1.Value);
            }

        }

        //Hash Table first Repetitive word
        static void HashTableFirstRepWord()
        {
            string input = "Poatoomass";
            char? firstRepetitiveCharacter = FindFirstRepetitiveCharacter(input);
        
            if (firstRepetitiveCharacter != null)
            {
                Console.WriteLine("First repetitive character: " + firstRepetitiveCharacter);
            }
            else
            {
                Console.WriteLine("No repetitive character found.");
            }
        }
        static char? FindFirstRepetitiveCharacter(string input)
        {
            Hashtable hashtable = new Hashtable();

            foreach (char ch in input)
            {
                if (hashtable.ContainsKey(ch))
                {
                    Console.WriteLine($"Character: {ch}");
                    return ch;
                }
                else
                {
                    hashtable[ch] = 1;
                }
            }

            return null; // No repetitive character found
        }

        //Binary Trees InOrder, PreOrder, PostOrder. All operations are O(log n)
        static void BinaryTreeComplete()
        {
            BinaryTree tree = new BinaryTree();

            // Insert nodes into the binary tree
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            //Depth First
            Console.WriteLine("In-order traversal:");
            tree.InOrder();
            Console.WriteLine();

            Console.WriteLine("Pre-order traversal:");
            tree.PreOrder();
            Console.WriteLine();

            Console.WriteLine("Post-order traversal:");
            tree.PostOrder();
            Console.WriteLine();

            // Find and print the minimum value in the binary tree
            try
            {
                int minValue = tree.FindMin();
                Console.WriteLine("Minimum value in the tree: " + minValue);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Duplicate the tree and compare
            BinaryTree duplicateTree = tree.Duplicate();
            bool areEqual = BinaryTree.CompareTrees(tree.Root, duplicateTree.Root);
            Console.WriteLine("Are the original and duplicate trees equal? " + areEqual);

            // Print the node value at a given distance from the root
            int distance = 1;
            tree.PrintNodeAtDistance(distance);
    
        }

        class TreeNode
        {
            public int Data;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinaryTree
        {
            public TreeNode Root;

            public BinaryTree()
            {
                Root = null;
            }

            // Insert a node into the binary tree
            public void Insert(int data)
            {
                Root = InsertRec(Root, data);
            }

            private TreeNode InsertRec(TreeNode root, int data)
            {
                if (root == null)
                {
                    root = new TreeNode(data);
                    return root;
                }

                if (data < root.Data)
                {
                    root.Left = InsertRec(root.Left, data);
                }
                else if (data > root.Data)
                {
                    root.Right = InsertRec(root.Right, data);
                }

                return root;
            }

            // In-order traversal of the binary tree
            public void InOrder()
            {
                InOrderRec(Root);
            }

            private void InOrderRec(TreeNode root)
            {
                if (root != null)
                {
                    InOrderRec(root.Left);
                    Console.Write(root.Data + " ");
                    InOrderRec(root.Right);
                }
            }

            // Pre-order traversal of the binary tree
            public void PreOrder()
            {
                PreOrderRec(Root);
            }

            private void PreOrderRec(TreeNode root)
            {
                if (root != null)
                {
                    Console.Write(root.Data + " ");
                    PreOrderRec(root.Left);
                    PreOrderRec(root.Right);
                }
            }

            // Post-order traversal of the binary tree
            public void PostOrder()
            {
                PostOrderRec(Root);
            }

            private void PostOrderRec(TreeNode root)
            {
                if (root != null)
                {
                    PostOrderRec(root.Left);
                    PostOrderRec(root.Right);
                    Console.Write(root.Data + " ");
                }
            }

            // Find the minimum value in the binary tree
            public int FindMin()
            {
                return FindMinRec(Root);
            }

            private int FindMinRec(TreeNode root)
            {
                if (root == null)
                {
                    throw new InvalidOperationException("The tree is empty.");
                }

                TreeNode current = root;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.Data;
            }
            
            // Create a duplicate of the binary tree
            public BinaryTree Duplicate()
            {
                BinaryTree duplicateTree = new BinaryTree();
                duplicateTree.Root = DuplicateRec(Root);
                return duplicateTree;
            }

            private TreeNode DuplicateRec(TreeNode root)
            {
                if (root == null)
                {
                    return null;
                }

                TreeNode newNode = new TreeNode(root.Data);
                newNode.Left = DuplicateRec(root.Left);
                newNode.Right = DuplicateRec(root.Right);
                return newNode;
            }

            // Compare two binary trees
            public static bool CompareTrees(TreeNode root1, TreeNode root2)
            {
                if (root1 == null && root2 == null)
                {
                    return true;
                }

                if (root1 == null || root2 == null)
                {
                    return false;
                }

                return (root1.Data == root2.Data) &&
                    CompareTrees(root1.Left, root2.Left) &&
                    CompareTrees(root1.Right, root2.Right);
            }

            // Print the node value at a given distance from the root
            public void PrintNodeAtDistance(int distance)
            {
                PrintNodeAtDistanceRec(Root, distance);
            }

            private void PrintNodeAtDistanceRec(TreeNode root, int distance)
            {
                if (root == null)
                {
                    return;
                }

                if (distance == 0)
                {
                    Console.WriteLine("Node at distance " + distance + " from the root: " + root.Data);
                    return;
                }

                PrintNodeAtDistanceRec(root.Left, distance - 1);
                PrintNodeAtDistanceRec(root.Right, distance - 1);
            }

        }
        //AVL Trees. This tree code is missing  but in a nutshell
        //AVL Trees reorder themselves in order always to be even    

        //Heaps
        /*
        A heap is a special tree-based data structure that satisfies the heap property(max-heap, min-heap):
        When to Use a Heap:
        Priority Queue: When you need a priority queue, where you frequently need to extract the minimum or maximum element.
        Efficient Access to Extremes: When you need efficient access to the smallest or largest element in the collection.
        
        */

        //Tries

        //Graphs

        //Undirect Graphs

        //Fibonacci Sequence Assesssment
        // class Result
        // {

        //     static void Main(string[] args)
        //     {
        //         int n = Convert.ToInt32(Console.ReadLine());
        //         List<int> fibonacciSequence = fibonacci(n);

        //         foreach (int number in fibonacciSequence)
        //         {
        //             Console.WriteLine(number);
        //         }
        //     }
            
        //     public static List<int> fibonacci(int n)
        //     {
        //         List<int> fibSequence = new List<int>();

        //         if (n >= 1) fibSequence.Add(0);
        //         if (n >= 2) fibSequence.Add(1);

        //         for (int i = 2; i < n; i++)
        //         {
        //             int nextNumber = fibSequence[i - 1] + fibSequence[i - 2];
        //             fibSequence.Add(nextNumber);
        //         }

        //         return fibSequence;
        //     }

        // }



    }
}