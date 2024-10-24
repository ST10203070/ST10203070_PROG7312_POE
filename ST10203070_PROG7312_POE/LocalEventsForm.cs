using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    /// <summary>
    /// LocalEventsForm class
    /// </summary>
    public partial class LocalEventsForm : Form
    {
        /// <summary>
        /// Sorted dictionary that organizes events by date. 
        /// Each date is associated with a queue of events, 
        /// ensuring that events on the same date are stored in the order they are added.
        /// </summary>
        private SortedDictionary<DateTime, Queue<Event>> eventsByDate;

        /// <summary>
        /// Hash set for event categories
        /// </summary>
        private HashSet<string> eventCategories = new HashSet<string>();

        /// <summary>
        /// Queue to store search history for recommendation feature
        /// </summary>
        private Queue<string> searchHistory = new Queue<string>();

        /// <summary>
        /// A HashSet used to track events that have already been displayed in the search results. 
        /// This ensures that events shown in the search are not duplicated in the recommendations. 
        /// </summary>
        private HashSet<Event> displayedEvents = new HashSet<Event>();

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

            // Set the size of the form
            this.Size = new Size(800, 600);

            // Set the minimum size of the form
            this.MinimumSize = new Size(800, 550);

            // Opening form in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

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
                lblTitle.ForeColor = Color.White;
                lblCategory.ForeColor = Color.White;
                lblDateRange.ForeColor = Color.White;
                lblLocation.ForeColor = Color.White;
                lblPrompt.ForeColor = Color.White;

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(30, 144, 255);
                        btn.ForeColor = Color.White;
                    }
                    else if (ctrl is TextBox txt)
                    {
                        txt.BackColor = Color.FromArgb(30, 30, 30);
                        txt.ForeColor = Color.White;
                    }
                    else if (ctrl is ComboBox cmb)
                    {
                        cmb.BackColor = Color.FromArgb(30, 30, 30);
                        cmb.ForeColor = Color.White;
                        cmb.FlatStyle = FlatStyle.Flat;
                        cmb.DrawMode = DrawMode.OwnerDrawFixed;
                        cmb.DrawItem += ComboBox_DrawItem;
                    }
                    else if (ctrl is RichTextBox rtb)
                    {
                        rtb.BackColor = Color.FromArgb(30, 30, 30);
                        rtb.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                // Apply light theme styling to other controls here
            }
        }

        /// <summary>
        /// Event handler for custom drawing of ComboBox items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox comboBox = (ComboBox)sender;
            e.DrawBackground();

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backgroundColor = isSelected ? Color.FromArgb(60, 60, 60) : Color.FromArgb(30, 30, 30);
            Color textColor = Color.White;

            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Method to initialize some sample events for demonstration
        /// </summary>
        private void LoadEvents()
        {
            eventsByDate = new SortedDictionary<DateTime, Queue<Event>>();

            AddEventToQueue(new Event { Title = "Community Clean-up", Category = "Cultural", Date = new DateTime(2024, 12, 10), Description = "Join us to clean up the park and neighborhood." });
            AddEventToQueue(new Event { Title = "Football Tournament", Category = "Sports", Date = new DateTime(2024, 11, 25), Description = "Annual community football tournament." });
            AddEventToQueue(new Event { Title = "Town Hall Meeting", Category = "Public Meetings", Date = new DateTime(2024, 12, 01), Description = "Discussing public safety and municipal services." });
            AddEventToQueue(new Event { Title = "Music Festival", Category = "Cultural", Date = new DateTime(2024, 12, 10), Description = "A celebration of local talent with music and food." });

            PopulateCategoryComboBox();
        }

        /// <summary>
        /// Method to bind hash set eventCategories to category combobox
        /// </summary>
        private void PopulateCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All"); // Add default "All" option
            foreach (var category in eventCategories)
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0; // Set default selection
        }

        /// <summary>
        /// Adds event to the SortedDictionary as a priority queue (by date)
        /// </summary>
        /// <param name="ev"></param>
        private void AddEventToQueue(Event ev)
        {
            if (!eventsByDate.ContainsKey(ev.Date))
            {
                eventsByDate[ev.Date] = new Queue<Event>();
            }
            eventsByDate[ev.Date].Enqueue(ev);

            // Add category to HashSet to ensure uniqueness
            eventCategories.Add(ev.Category);
        }

        /// <summary>
        /// Event handler for Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchEvents_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchEvents.Text.Trim().ToLower();
            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All";
            DateTime fromDate = dtpFrom.Value;
            DateTime toDate = dtpTo.Value;

            // Clear previous results and recommendations
            rtbEvents.Clear();
            displayedEvents.Clear(); // Clear the list of displayed events

            // Iterate over sorted dictionary, only within the given date range
            foreach (var date in eventsByDate.Keys)
            {
                if (date >= fromDate && date <= toDate)
                {
                    foreach (var ev in eventsByDate[date])
                    {
                        if ((string.IsNullOrEmpty(searchTerm) || ev.Title.ToLower().Contains(searchTerm)) &&
                            (selectedCategory == "All" || ev.Category == selectedCategory))
                        {
                            // Append event details and track it in displayedEvents
                            AppendEventToRichTextBox(ev);
                            displayedEvents.Add(ev); // Keep track of displayed events
                        }
                    }
                }
            }

            if (rtbEvents.Text == string.Empty)
            {
                rtbEvents.AppendText("No events found.\n");
            }

            // Add the current search term to the search history for recommendations
            AddToSearchHistory(searchTerm);

            // Show recommendations, excluding already displayed events
            ShowRecommendations();
        }

        /// <summary>
        /// Appends the details of an event to the RichTextBox in a formatted manner.
        /// The event's date is displayed in bold blue text, the title and category are in bold black text, 
        /// and the description is italicized with a specific color. A separator is added after each event.
        /// </summary>
        /// <param name="ev"></param>
        private void AppendEventToRichTextBox(Event ev)
        {
            rtbEvents.SelectionFont = new Font("Courier New", 12F, FontStyle.Bold);
            rtbEvents.SelectionColor = Color.CadetBlue;
            rtbEvents.AppendText($"{ev.Date.ToShortDateString()}\n");

            rtbEvents.SelectionFont = new Font("Courier New", 10F, FontStyle.Bold);
            rtbEvents.SelectionColor = isDarkMode ? Color.White : Color.Black; 
            rtbEvents.AppendText($"{ev.Title} ({ev.Category})\n");

            rtbEvents.SelectionFont = new Font("Courier New", 10F, FontStyle.Italic);
            rtbEvents.SelectionColor = isDarkMode ? Color.White : Color.Gray; 
            rtbEvents.AppendText($"{ev.Description}\n");

            rtbEvents.SelectionFont = new Font("Courier New", 10F, FontStyle.Regular);
            rtbEvents.SelectionColor = isDarkMode ? Color.White : Color.Black; 
            rtbEvents.AppendText("------------------------------\n");
        }

        /// <summary>
        /// Method to add search term to search history queue
        /// </summary>
        /// <param name="searchTerm"></param>
        private void AddToSearchHistory(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchHistory.Enqueue(searchTerm);
                if (searchHistory.Count > 12) // Limit history size
                {
                    searchHistory.Dequeue();
                }
            }
        }

        /// <summary>
        /// A list of events that are recommended based on the user's search history
        /// </summary>
        /// <returns></returns>
        private List<Event> RecommendEvents()
        {
            var recommendationSet = new HashSet<Event>();  // Use HashSet to avoid duplicates
            foreach (var term in searchHistory)
            {
                foreach (var eventsQueue in eventsByDate.Values)
                {
                    foreach (var ev in eventsQueue)
                    {
                        // Only recommend events that haven't been displayed yet
                        if (ev.Title.ToLower().Contains(term) && !displayedEvents.Contains(ev))
                        {
                            recommendationSet.Add(ev);  // HashSet ensures unique events
                        }
                    }
                }
            }
            return recommendationSet.ToList(); // Convert HashSet back to List to return
        }

        /// <summary>
        /// Display the recommendations in a ListBox or MessageBox
        /// </summary>
        private void ShowRecommendations()
        {
            var recommendations = RecommendEvents();

            if (recommendations.Count > 0)
            {
                rtbEvents.AppendText("\n\n----- Recommended Events -----\n");
                rtbEvents.SelectionFont = new Font("Courier New", 12F, FontStyle.Bold);
                rtbEvents.SelectionColor = Color.DarkGreen;

                foreach (var ev in recommendations)
                {
                    AppendEventToRichTextBox(ev);
                }
            }
            else
            {
                rtbEvents.AppendText("\n\nNo recommendations found.\n");
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
        /// Represents a local event with properties for the event's title, category, date, and description.
        /// This class provides a structure to hold the information for each event in the system.
        /// </summary>
        private class Event
        {
            /// <summary>
            /// Gets or sets the title of the event.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the category of the event, such as "Sports", "Cultural", etc.
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// Gets or sets the date of the event.
            /// </summary>
            public DateTime Date { get; set; }

            /// <summary>
            /// Gets or sets a brief description of the event.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Overrides the Equals method to define equality based on the event's title, category, and date.
            /// This ensures that events are considered equal if they have the same title, category, and date.
            /// </summary>
            /// <param name="obj">The object to compare with the current event.</param>
            /// <returns>True if the provided object is equal to the current event; otherwise, false.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Event otherEvent)
                {
                    return Title == otherEvent.Title && Category == otherEvent.Category && Date == otherEvent.Date;
                }
                return false;
            }

            /// <summary>
            /// Overrides the GetHashCode method to generate a unique hash code for the event.
            /// The hash code is computed based on the event's title, category, and date to ensure 
            /// that events with the same values are treated as duplicates in collections like HashSet.
            /// </summary>
            /// <returns>A hash code for the current event, based on the title, category, and date.</returns>
            public override int GetHashCode()
            {
                return Title.GetHashCode() ^ Category.GetHashCode() ^ Date.GetHashCode();
            }
        }
    }
}
