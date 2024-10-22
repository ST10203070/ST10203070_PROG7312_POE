using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    /// <summary>
    /// MainMenuForm class
    /// </summary>
    public partial class MainMenuForm : Form
    {
        /// <summary>
        /// Sound variable set to default of on
        /// </summary>
        private bool isSoundOn = true;

        /// <summary>
        /// MainMenuForm constructor
        /// </summary>
        public MainMenuForm()
        {
            InitializeComponent();
            // Load event is connected
            this.Load += MainMenuForm_Load; 
            // Attach the Paint event to each button
            btnReportIssues.Paint += new PaintEventHandler(CustomButton_Paint);
            btnLocalEvents.Paint += new PaintEventHandler(CustomButton_Paint);
            btnServiceRequestStatus.Paint += new PaintEventHandler(CustomButton_Paint);
            // Form resize to adjust label width
            this.Resize += MainMenuForm_Resize;
            // Keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += MainMenuForm_KeyDown;

            // Set the size of the form
            this.Size = new Size(1162, 700);

            // Set the minimum size of the form
            this.MinimumSize = new Size(800, 600);

            // Opening form in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Event handler to load MainMenuForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Set the background image for MainMenuFomr
            this.BackgroundImage = global::ST10203070_PROG7312_POE.Properties.Resources.CTBackground;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Call to force redraw of the form
            this.Invalidate();

            // Position toggle checkboxes
            PositionToggleCheckbox();

            // Initial adjustment
            AdjustTitleLabel(); 

            // Determine the current time of day
            string greeting;
            int hour = DateTime.Now.Hour;

            if (hour >= 5 && hour < 12)
                greeting = "Good Morning! Welcome to Municipal Services.";
            else if (hour >= 12 && hour < 17)
                greeting = "Good Afternoon! Welcome to Municipal Services.";
            else if (hour >= 17 && hour < 21)
                greeting = "Good Evening! Welcome to Municipal Services.";
            else
                greeting = "Good Night! Welcome to Municipal Services.";

            // Set the personalized greeting
            lblTitle.Text = greeting;

            // Center the title label
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;

            // Center the prompt label
            lblPrompt.Left = (this.ClientSize.Width - lblPrompt.Width) / 2;
        }

        /// <summary>
        /// Method for form resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuForm_Resize(object sender, EventArgs e)
        {
            // Adjust label on form resize
            AdjustTitleLabel(); 
        }

        /// <summary>
        /// Method to adjust title label
        /// </summary>
        private void AdjustTitleLabel()
        {
            // Adjust for wrapping
            lblTitle.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
            // Force label to re-evaluate its layout
            lblTitle.Text = lblTitle.Text;
            // Center horizontally
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2; 
        }

        /// <summary>
        /// Event handler for keyboard shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                // Ctrl+R for Report Issues
                btnReportIssues.PerformClick(); 
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                // Ctrl+L for Local Events
                btnLocalEvents.PerformClick(); 
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                // Ctrl+S for Service Request Status
                btnServiceRequestStatus.PerformClick(); 
            }
        }

        /// <summary>
        /// Method to play sound 
        /// </summary>
        private void PlayClickSound()
        {
            if (isSoundOn)
            {
                // Default sound
                SystemSounds.Beep.Play(); 
            }
        }

        /// <summary>
        ///  Event handler for report issues button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;
            // Pass the dark mode state to a new instance of ReportIssuesForm
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm(isDarkMode, isSoundOn); 
            // Show new instance of form
            reportIssuesForm.ShowDialog();
        }

        /// <summary>
        /// Event handler for local events button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;

            // Pass the dark mode state to a new instance of the LocalEventsForm
            LocalEventsForm localEventsForm = new LocalEventsForm(isDarkMode, isSoundOn);

            // Show the new instance of LocalEventsForm as a dialog
            localEventsForm.ShowDialog();
        }

        /// <summary>
        /// Event handler for service request status button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;
            // Pass the dark mode state to a new instance of the ServiceRequestStatusForm
            ServiceRequestStatusForm serviceStatusForm = new ServiceRequestStatusForm(isDarkMode, isSoundOn);
            // Show the new instance of ServiceRequestStatusForm
            serviceStatusForm.ShowDialog();
        }

        /// <summary>
        /// Mehtod to aply custom paint theme to buttons
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

            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, rect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        /// <summary>
        /// Event handler for dark mode checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkThemeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThemeToggle.Checked)
            {
                // Dark Mode
                this.BackColor = Color.FromArgb(45, 45, 48);
                lblTitle.ForeColor = Color.Black;
                lblPrompt.ForeColor = Color.Black;
                chkSoundToggle.ForeColor = Color.Black;
                chkThemeToggle.ForeColor = Color.Black;

                // Update MenuStrip colors
                // Apply custom renderer
                menuStrip.Renderer = new DarkModeRenderer();  
                menuStrip.BackColor = Color.FromArgb(45, 45, 48);
                menuStrip.ForeColor = Color.White;

                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    item.ForeColor = Color.White;
                }

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(30, 144, 255);  
                        btn.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                // Light Mode
                this.BackColor = Color.WhiteSmoke;
                lblTitle.ForeColor = Color.White;
                lblPrompt.ForeColor = Color.White;
                chkSoundToggle.ForeColor = Color.White;
                chkThemeToggle.ForeColor = Color.White;

                // Revert to default renderer
                menuStrip.Renderer = new ToolStripProfessionalRenderer();
                menuStrip.BackColor = Color.LemonChiffon;
                menuStrip.ForeColor = Color.Black;

                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    item.ForeColor = Color.Black;
                }

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(30, 144, 255);  
                        btn.ForeColor = Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for sound checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSoundToggle_CheckedChanged(object sender, EventArgs e)
        {
            // Update the sound state based on checkbox
            isSoundOn = chkSoundToggle.Checked; 
        }

        /// <summary>
        /// Event handler for the "Toggle Sound" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleSoundItem_Click(object sender, EventArgs e)
        {
            // Toggle the sound setting
            isSoundOn = !isSoundOn;
            chkSoundToggle.Checked = isSoundOn;
        }

        /// <summary>
        /// Event handler for the "Toggle Dark Mode" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleDarkModeItem_Click(object sender, EventArgs e)
        {
            // Toggle the dark mode setting
            chkThemeToggle.Checked = !chkThemeToggle.Checked;
        }

        /// <summary>
        /// Event handler for the tablelayoutpanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the "About" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display an "About" message box
            MessageBox.Show("Municipal Services Application\nVersion 1.0\nDeveloped by Max Walsh", "About");
        }

        /// <summary>
        /// Event handler for the "Exit" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event handler for the "Dark Mode On/Off" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the dark mode setting
            chkThemeToggle.Checked = !chkThemeToggle.Checked;
        }

        /// <summary>
        /// Event handler for the "Sound On/Off" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundOnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the sound setting
            isSoundOn = !isSoundOn;
            chkSoundToggle.Checked = isSoundOn;
        }

        /// <summary>
        /// Event handler for the "Local Events" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;
            // Pass the dark mode state to a new instance of the ReportIssuesForm
           LocalEventsForm reportIssuesForm = new LocalEventsForm(isDarkMode, isSoundOn);
            // Show the new instance of ReportIssuesForm
            reportIssuesForm.ShowDialog();
        }

        /// <summary>
        /// Event handler for the "Service Request Status" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serviceRequestStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;
            // Pass the dark mode state to a new instance of the ServiceRequestStatusForm
            ServiceRequestStatusForm serviceStatusForm = new ServiceRequestStatusForm(isDarkMode, isSoundOn);
            // Show the new instance of ServiceRequestStatusForm
            serviceStatusForm.ShowDialog();
        }

        /// <summary>
        /// Event handler for the "Report Issues" menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            // Check if dark mode is active
            bool isDarkMode = chkThemeToggle.Checked;
            // Pass the dark mode state to a new instance of the ReportIssuesForm
            ReportIssuesForm reportIssuesForm = new ReportIssuesForm(isDarkMode, isSoundOn); 
            // Show the new instance of ReportIssuesForm
            reportIssuesForm.ShowDialog();
        }
    }
}
