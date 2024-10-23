using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    public partial class ServiceRequestStatusForm : Form
    {
        // Variables to store dark mode and sound settings
        private bool isDarkMode;
        private bool isSoundOn;

        // AVL Tree for storing service requests, indexed by unique request ID
        private AVLTree<ServiceRequest> serviceRequestsTree;

        // Min-Heap for prioritizing service requests based on submission date
        private MinHeap<ServiceRequest> serviceRequestHeap;

        // Graph for managing dependencies between service requests and Minimum Spanning Tree
        private Graph<ServiceRequest> serviceRequestGraph;

        // Constructor with parameters for dark mode and sound settings
        public ServiceRequestStatusForm(bool isDarkMode, bool isSoundOn)
        {
            InitializeComponent();

            // Store the passed values
            this.isDarkMode = isDarkMode;
            this.isSoundOn = isSoundOn;

            // Set the size of the form
            this.Size = new Size(800, 600);

            // Set the minimum size of the form
            this.MinimumSize = new Size(800, 550);

            // Opening form in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Attach the Paint event to button to apply the custom theme
            btnBackToMainMenu.Paint += new PaintEventHandler(CustomButton_Paint);

            // Initialize the data structures
            serviceRequestsTree = new AVLTree<ServiceRequest>();
            serviceRequestHeap = new MinHeap<ServiceRequest>();
            serviceRequestGraph = new Graph<ServiceRequest>();

            // Apply the selected theme (dark or light mode)
            ApplyTheme(isDarkMode);

            // Load service requests into the tree (Sample Data)
            LoadSampleServiceRequests();

            // Display the service requests in the ListView
            DisplayServiceRequests();
        }

        // Method to apply dark mode or light mode based on the parameter
        private void ApplyTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                lblTitle.ForeColor = Color.White;
                lblPrompt.ForeColor = Color.White;
                lstServiceRequests.BackColor = Color.FromArgb(30, 30, 30);
                lstServiceRequests.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                lblTitle.ForeColor = Color.Black;
                lblPrompt.ForeColor = Color.Black;
                lstServiceRequests.BackColor = Color.White;
                lstServiceRequests.ForeColor = Color.Black;
            }
        }

        // Load sample service requests into the AVL tree and heap
        private void LoadSampleServiceRequests()
        {
            var request1 = new ServiceRequest(1001, "Road Pothole Repair", "Pending", new DateTime(2024, 1, 10));
            var request2 = new ServiceRequest(1002, "Water Leakage", "In Progress", new DateTime(2024, 2, 5));
            var request3 = new ServiceRequest(1003, "Streetlight Repair", "Completed", new DateTime(2024, 3, 12));

            serviceRequestsTree.Insert(request1);
            serviceRequestsTree.Insert(request2);
            serviceRequestsTree.Insert(request3);

            serviceRequestHeap.Insert(request1);
            serviceRequestHeap.Insert(request2);
            serviceRequestHeap.Insert(request3);

            // Add dependencies between requests to the graph
            serviceRequestGraph.AddNode(request1);
            serviceRequestGraph.AddNode(request2);
            serviceRequestGraph.AddNode(request3);

            serviceRequestGraph.AddEdge(request1, request2);  // Example: request1 must be completed before request2
        }

        // Display service requests in the ListView using in-order traversal of the AVL tree
        private void DisplayServiceRequests()
        {
            lstServiceRequests.Items.Clear(); // Clear previous entries
            foreach (var request in serviceRequestsTree.InOrderTraversal())
            {
                ListViewItem item = new ListViewItem(request.RequestId.ToString());
                item.SubItems.Add(request.Description);
                item.SubItems.Add(request.Status);
                item.SubItems.Add(request.SubmissionDate.ToShortDateString());
                lstServiceRequests.Items.Add(item);
            }
        }

        // Event handler for Back to Main Menu button click
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the ServiceRequestStatusForm and return to the main menu
        }

        /// <summary>
        /// Method to apply custom paint theme to buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = Color.LemonChiffon;
            Color borderColor = Color.Gray;
            Color textColor = Color.Black;

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();
            // Rounded corners
            int radius = 15;
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawPath(pen, path);
            }

            TextRenderer.DrawText(e.Graphics, btn.Text, new Font("Courier New", 12, FontStyle.Bold), rect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }
    }

    // ServiceRequest class to represent individual service requests
    public class ServiceRequest : IComparable<ServiceRequest>
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }

        public ServiceRequest(int requestId, string description, string status, DateTime submissionDate)
        {
            RequestId = requestId;
            Description = description;
            Status = status;
            SubmissionDate = submissionDate;
        }

        // Implement IComparable to enable comparison of service requests based on request ID
        public int CompareTo(ServiceRequest other)
        {
            return this.RequestId.CompareTo(other.RequestId);
        }
    }

    // AVLTree class for balancing service request inserts
    public class AVLTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        // Insert a new service request into the AVL tree
        public void Insert(T value)
        {
            root = InsertRecursive(root, value);
        }

        // Recursive insertion with balancing
        private TreeNode<T> InsertRecursive(TreeNode<T> node, T value)
        {
            if (node == null)
                return new TreeNode<T>(value);

            int compareResult = value.CompareTo(node.Value);

            if (compareResult < 0)
                node.Left = InsertRecursive(node.Left, value);
            else if (compareResult > 0)
                node.Right = InsertRecursive(node.Right, value);

            return Balance(node);
        }

        // Balance the tree after insertions
        private TreeNode<T> Balance(TreeNode<T> node)
        {
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1) // Left heavy
            {
                if (GetBalanceFactor(node.Left) < 0) // Left-Right Case
                    node.Left = RotateLeft(node.Left);
                node = RotateRight(node); // Left-Left Case
            }
            else if (balanceFactor < -1) // Right heavy
            {
                if (GetBalanceFactor(node.Right) > 0) // Right-Left Case
                    node.Right = RotateRight(node.Right);
                node = RotateLeft(node); // Right-Right Case
            }

            return node;
        }

        // Rotate nodes right
        private TreeNode<T> RotateRight(TreeNode<T> y)
        {
            TreeNode<T> x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            return x;
        }

        // Rotate nodes left
        private TreeNode<T> RotateLeft(TreeNode<T> x)
        {
            TreeNode<T> y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            return y;
        }

        // Get the balance factor of the node
        private int GetBalanceFactor(TreeNode<T> node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        // Get the height of the node
        private int GetHeight(TreeNode<T> node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        // In-order traversal to display the service requests in sorted order
        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderRecursive(root, result);
            return result;
        }

        // Recursive in-order traversal method
        private void InOrderRecursive(TreeNode<T> node, List<T> result)
        {
            if (node == null)
                return;

            InOrderRecursive(node.Left, result);
            result.Add(node.Value);
            InOrderRecursive(node.Right, result);
        }
    }

    // TreeNode class to represent each node in the AVL tree
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // MinHeap class for priority queue
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        // Insert an element into the heap
        public void Insert(T value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        // Get the minimum element (root of the heap) without removing it
        public T Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");
            return heap[0];
        }

        // Remove and return the minimum element
        public T ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T minValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return minValue;
        }

        // Get the size of the heap
        public int Size()
        {
            return heap.Count;
        }

        // Heapify up for maintaining heap property after insertion
        private void HeapifyUp(int index)
        {
            if (index == 0) return;  // Reached the root

            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        // Heapify down for maintaining heap property after extraction
        private void HeapifyDown(int index)
        {
            int smallest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        // Swap two elements in the heap
        private void Swap(int index1, int index2)
        {
            T temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }

    // Graph class for service request dependencies and Minimum Spanning Tree (MST)
    public class Graph<T>
    {
        private Dictionary<T, List<T>> adjacencyList = new Dictionary<T, List<T>>();

        public void AddNode(T node)
        {
            if (!adjacencyList.ContainsKey(node))
                adjacencyList[node] = new List<T>();
        }

        public void AddEdge(T fromNode, T toNode)
        {
            if (adjacencyList.ContainsKey(fromNode))
                adjacencyList[fromNode].Add(toNode);
        }

        public List<T> BreadthFirstSearch(T startNode)
        {
            List<T> result = new List<T>();
            Queue<T> queue = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                T currentNode = queue.Dequeue();
                result.Add(currentNode);

                foreach (T neighbor in adjacencyList[currentNode])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            return result;
        }

        // Implementing Prim's Algorithm to compute Minimum Spanning Tree (MST)
        public List<Tuple<T, T>> MinimumSpanningTree(T startNode)
        {
            List<Tuple<T, T>> mst = new List<Tuple<T, T>>();
            HashSet<T> visited = new HashSet<T>();
            PriorityQueue<Tuple<T, T>> priorityQueue = new PriorityQueue<Tuple<T, T>>();

            visited.Add(startNode);

            // Add all edges from start node to priority queue
            foreach (T neighbor in adjacencyList[startNode])
            {
                priorityQueue.Enqueue(Tuple.Create(startNode, neighbor));
            }

            // Prim's algorithm
            while (priorityQueue.Count > 0)
            {
                var edge = priorityQueue.Dequeue();

                T nodeA = edge.Item1;
                T nodeB = edge.Item2;

                if (!visited.Contains(nodeB))
                {
                    visited.Add(nodeB);
                    mst.Add(edge);

                    foreach (T neighbor in adjacencyList[nodeB])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            priorityQueue.Enqueue(Tuple.Create(nodeB, neighbor));
                        }
                    }
                }
            }

            return mst;
        }
    }

    // Simple priority queue class for Prim's MST algorithm
    public class PriorityQueue<T>
    {
        private List<T> elements = new List<T>();

        public int Count => elements.Count;

        public void Enqueue(T item)
        {
            elements.Add(item);
        }

        public T Dequeue()
        {
            T item = elements[0];
            elements.RemoveAt(0);
            return item;
        }
    }
}
