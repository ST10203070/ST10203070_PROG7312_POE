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

        // Binary Search Tree for storing service requests, indexed by unique request ID
        private BinarySearchTree<ServiceRequest> serviceRequestsTree;

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

            // Initialize the binary search tree for service requests
            serviceRequestsTree = new BinarySearchTree<ServiceRequest>();

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

        // Load sample service requests into the binary search tree
        private void LoadSampleServiceRequests()
        {
            serviceRequestsTree.Insert(new ServiceRequest(1001, "Road Pothole Repair", "Pending", new DateTime(2024, 1, 10)));
            serviceRequestsTree.Insert(new ServiceRequest(1002, "Water Leakage", "In Progress", new DateTime(2024, 2, 5)));
            serviceRequestsTree.Insert(new ServiceRequest(1003, "Streetlight Repair", "Completed", new DateTime(2024, 3, 12)));
            serviceRequestsTree.Insert(new ServiceRequest(1004, "Public Park Clean-up", "Pending", new DateTime(2024, 4, 20)));
        }

        // Display service requests in the ListView using in-order traversal of the binary search tree
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

    // BinarySearchTree class for organizing service requests
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        // Insert a new service request into the tree
        public void Insert(T value)
        {
            root = InsertRecursive(root, value);
        }

        // Recursive insertion method
        private TreeNode<T> InsertRecursive(TreeNode<T> node, T value)
        {
            if (node == null)
                return new TreeNode<T>(value);

            int compareResult = value.CompareTo(node.Value);

            if (compareResult < 0)
                node.Left = InsertRecursive(node.Left, value);
            else if (compareResult > 0)
                node.Right = InsertRecursive(node.Right, value);

            return node;
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

    // TreeNode class to represent each node in the binary search tree
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
}
