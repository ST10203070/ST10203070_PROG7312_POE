using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ST10203070_PROG7312_POE
{
    /// <summary>
    /// ReportIssuesForm class
    /// </summary>
    public partial class ReportIssuesForm : Form
    {
        /// <summary>
        /// Tree structure (AVL Tree) to store reported issues
        /// </summary>
        public static AVLTree<ServiceRequest> reportedIssuesTree = new AVLTree<ServiceRequest>();
        /// <summary>
        /// List to store attached media files
        /// </summary>
        private List<string> attachedMediaFiles = new List<string>();
        /// <summary>
        /// Variables for sound and dark mode theme
        /// </summary>
        private bool isSoundOn;
        private bool isDarkMode;

        /// <summary>
        /// ReportIssuesForm Constructor
        /// </summary>
        /// <param name="isDarkMode"></param>
        /// <param name="soundEnabled"></param>
        public ReportIssuesForm(bool isDarkMode, bool soundEnabled)
        {
            // Set sound and theme states
            this.isSoundOn = soundEnabled;
            this.isDarkMode = isDarkMode;

            // Initialize the components
            InitializeComponent();

            // Set the size of the form
            this.Size = new Size(800, 600);

            // Set the minimum size of the form
            this.MinimumSize = new Size(800, 550);

            // Opening form in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Attach the Paint event to each button to apply the custom theme
            btnAttachMedia.Paint += new PaintEventHandler(CustomButton_Paint);
            btnSubmit.Paint += new PaintEventHandler(CustomButton_Paint);
            btnBackToMainMenu.Paint += new PaintEventHandler(CustomButton_Paint);

            // Apply theme settings based on the mode
            ApplyTheme(isDarkMode);

            // Event handlers to update progress when the user interacts with the form
            txtLocation.TextChanged += InputFieldChanged;
            cmbCategory.SelectedIndexChanged += InputFieldChanged;
            rtbDescription.TextChanged += InputFieldChanged;

            // Initialize progress bar and message
            UpdateProgressBar();
        }

        /// <summary>
        /// Method to apply dark mode
        /// </summary>
        /// <param name="isDarkMode"></param>
        private void ApplyTheme(bool isDarkMode)
        {
            try
            {
                if (isDarkMode)
                {
                    // Dark Mode settings
                    this.BackColor = Color.FromArgb(45, 45, 48);
                    lblTitle.ForeColor = Color.White;
                    lblPrompt.ForeColor = Color.White;
                    lblLocation.ForeColor = Color.White;
                    lblCategory.ForeColor = Color.White;
                    lblDescription.ForeColor = Color.White;
                    lblEngagement.ForeColor = Color.White;
                    lblReportProgress.ForeColor = Color.White;
                    lblProgressMessage.ForeColor = Color.White;

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
                    // Light Mode settings
                    this.BackColor = Color.WhiteSmoke;
                    lblTitle.ForeColor = Color.Black;
                    lblPrompt.ForeColor = Color.Black;
                    lblLocation.ForeColor = Color.Black;
                    lblCategory.ForeColor = Color.Black;
                    lblDescription.ForeColor = Color.Black;
                    lblEngagement.ForeColor = Color.Black;
                    lblProgressMessage.ForeColor = Color.Black;

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Button btn)
                        {
                            btn.BackColor = Color.FromArgb(30, 144, 255);  
                            btn.ForeColor = Color.Black;
                        }
                        else if (ctrl is TextBox txt)
                        {
                            txt.BackColor = Color.White;
                            txt.ForeColor = Color.Black;
                        }
                        else if (ctrl is ComboBox cmb)
                        {
                            cmb.BackColor = Color.White;
                            cmb.ForeColor = Color.Black;
                            cmb.FlatStyle = FlatStyle.Standard;
                            cmb.DrawMode = DrawMode.Normal;
                            cmb.DrawItem -= ComboBox_DrawItem; 
                        }
                        else if (ctrl is RichTextBox rtb)
                        {
                            rtb.BackColor = Color.White;
                            rtb.ForeColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply theme: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method to play sound based on the sound toggle state
        /// </summary>
        private void PlayClickSound()
        {
            if (isSoundOn)
            {
                SystemSounds.Asterisk.Play();
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
        /// Event handler for media atttaching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            try
            {
                openFileDialog.Title = "Select Media Files";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachedMediaFiles.AddRange(openFileDialog.FileNames);
                    MessageBox.Show($"{openFileDialog.FileNames.Length} file(s) attached successfully.", "Media Attached");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error attaching media: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            try
            {
                // Gather input data
                string location = txtLocation.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString() ?? string.Empty;
                string description = rtbDescription.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Please fill in all required fields.", "Input Error");
                    return;
                }

                // Simulate processing delay with async/await
                progressBar.Visible = true;
                lblEngagement.Text = "Reporting your issue, please wait...";
                // Simulated delay
                await Task.Delay(2000);

                // Create and add new reported issue (using ServiceRequest class)
                ServiceRequest newIssue = new ServiceRequest(reportedIssuesTree.Count + 1, description, "Pending", DateTime.Now);
                reportedIssuesTree.Insert(newIssue); // Store issue globally

                MessageBox.Show("Issue reported successfully!", "Submission Confirmation");
                lblEngagement.Text = "Thank you for reporting!";
                // Clearing form
                ClearForm();
                // Reset progress
                progressBarCompletion.Value = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit report: {ex.Message}", "Submission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        /// <summary>
        /// Event handler for back to main menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            // Close the form to return to the main menu
            this.Close(); 
        }

        /// <summary>
        /// Method to clear form
        /// </summary>
        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            attachedMediaFiles.Clear();
            lblEngagement.Text = string.Empty;
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

        /// <summary>
        /// Event handler for change in location text field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        /// <summary>
        /// Event handler for change in category dropdown index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        /// <summary>
        /// Event handler for change in description text field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        /// <summary>
        /// Method to update the progress bar and message whenever an input changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFieldChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        /// <summary>
        /// Method to update progress bar
        /// </summary>
        /// <param name="finalStep"></param>
        private void UpdateProgressBar(bool finalStep = false)
        {
            int progress = 0;

            // Update progress based on filled fields
            if (!string.IsNullOrEmpty(txtLocation.Text.Trim())) progress++;
            if (cmbCategory.SelectedItem != null) progress++;
            if (!string.IsNullOrEmpty(rtbDescription.Text.Trim())) progress++;

            if (finalStep) progress++;

            progressBarCompletion.Value = progress;


            // Display appropriate messages based on progress
            switch (progress)
            {
                case 1:
                    lblProgressMessage.Text = "Step 1: Enter the location.";
                    break;
                case 2:
                    lblProgressMessage.Text = "Step 2: Select the category.";
                    break;
                case 3:
                    lblProgressMessage.Text = "Step 3: Describe the issue.";
                    break;
                case 4:
                    lblProgressMessage.Text = "All steps completed. Ready to submit!";
                    break;
                default:
                    lblProgressMessage.Text = "Please start by filling the location.";
                    break;
            }

            // Show tooltip at 75% completion
            if (progress == 3 && !finalStep)
            {
                progressBarToolTip.SetToolTip(progressBarCompletion, "Almost there! Click Submit.");
                // Show tooltip for 3 seconds
                progressBarToolTip.Show("Almost there! Click Submit.", progressBarCompletion, 0, -20, 3000); 
            }
            else
            {
                progressBarToolTip.Hide(progressBarCompletion);
            }
        }

        /// <summary>
        /// Event handler for report progress label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReportProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
