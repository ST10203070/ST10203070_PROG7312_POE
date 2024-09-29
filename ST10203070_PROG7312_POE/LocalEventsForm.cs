using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    /// <summary>
    /// LocalEventsForm class
    /// </summary>
    public partial class LocalEventsForm : Form
    {
        /// <summary>
        /// List to store the local events
        /// </summary>
        private List<Event> eventsList;

        /// <summary>
        /// Dark mode variable
        /// </summary>
        private bool isDarkMode;

        /// <summary>
        /// Sound variable set to default of on
        /// </summary>
        private bool isSoundOn = true;

        /// <summary>
        /// Constructor accepting dark mode and sound settings
        /// </summary>
        /// <param name="isDarkMode"></param>
        /// <param name="isSoundOn"></param>
        public LocalEventsForm(bool isDarkMode, bool isSoundOn)
        {
            InitializeComponent();

            // Set local variables
            this.isDarkMode = isDarkMode;
            this.isSoundOn = isSoundOn;

            // Apply the selected theme (dark or light mode)
            ApplyTheme(isDarkMode);

            // Initialize and load sample events
            LoadEvents();

            // Attach the custom paint event handler to both buttons
            btnSearchEvents.Paint += new PaintEventHandler(CustomButton_Paint);
            btnBackToMainMenu.Paint += new PaintEventHandler(CustomButton_Paint);
        }

        /// <summary>
        /// Method to apply the theme
        /// </summary>
        /// <param name="isDarkMode"></param>
        private void ApplyTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                // Apply dark theme styling to other controls here
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                // Apply light theme styling to other controls here
            }
        }

        /// <summary>
        /// Method to initialize some sample events for demonstration
        /// </summary>
        private void LoadEvents()
        {
            eventsList = new List<Event>
            {
                new Event { Title = "Community Clean-up", Category = "Cultural", Date = new DateTime(2024, 10, 10), Description = "Join us to clean up the park and neighborhood." },
                new Event { Title = "Football Tournament", Category = "Sports", Date = new DateTime(2024, 11, 05), Description = "Annual community football tournament." },
                new Event { Title = "Town Hall Meeting", Category = "Public Meetings", Date = new DateTime(2024, 12, 01), Description = "Discussing public safety and municipal services." },
                new Event { Title = "Music Festival", Category = "Cultural", Date = new DateTime(2024, 12, 10), Description = "A celebration of local talent with music and food." }
            };
        }

        /// <summary>
        /// Event handler for Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchEvents_Click(object sender, EventArgs e)
        {
            // Ensure the eventsList is not null
            if (eventsList == null)
            {
                MessageBox.Show("No events are loaded.", "Error");
                return;
            }

            string searchTerm = txtSearchEvents.Text.Trim().ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All";
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            // Filter the events based on user input
            var filteredEvents = eventsList.FindAll(ev =>
                (string.IsNullOrEmpty(searchTerm) || ev.Title.ToLower().Contains(searchTerm)) &&
                (selectedCategory == "All" || ev.Category == selectedCategory) &&
                ev.Date >= fromDate && ev.Date <= toDate
            );

            // Display the filtered events in the ListBox
            lstEvents.Items.Clear(); // Clear previous results
            if (filteredEvents.Count > 0)
            {
                foreach (var ev in filteredEvents)
                {
                    lstEvents.Items.Add($"{ev.Date.ToShortDateString()} - {ev.Title} ({ev.Category})");
                }
            }
            else
            {
                lstEvents.Items.Add("No events found.");
            }
        }

        /// <summary>
        /// Event handler for Back to Main Menu button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the LocalEventsForm and return to the main menu
        }

        /// <summary>
        /// Custom paint method for buttons with rounded corners and specific colors
        /// </summary>
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the colors and radius for rounded corners
            Color backColor = Color.LemonChiffon;
            Color borderColor = Color.Gray;
            Color textColor = Color.Black;
            int radius = 15;  // Rounded corner radius

            // Define the button rectangle
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();

            // Create the rounded rectangle path
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Fill the button with the background color
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Draw the border around the button
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawPath(pen, path);
            }

            // Draw the button text
            TextRenderer.DrawText(e.Graphics, btn.Text, new Font("Courier New", 12, FontStyle.Bold), rect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        /// <summary>
        /// Event class to hold the information for each event
        /// </summary>
        private class Event
        {
            public string Title { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
        }
    }
}
