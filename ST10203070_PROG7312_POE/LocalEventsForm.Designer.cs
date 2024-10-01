using System;
using System.Drawing;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    partial class LocalEventsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBarCompletion;
        private System.Windows.Forms.ToolTip progressBarToolTip;
        private Label lblProgressMessage;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "LocalEventsForm";
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtSearchEvents = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearchEvents = new System.Windows.Forms.Button();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblProgressMessage = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(274, 27);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Local Events and Announcements";
            this.lblTitle.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new Point(50, 50);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new Size(478, 18);
            this.lblPrompt.TabIndex = 11;
            this.lblPrompt.Text = "Search for local events and news in your area:";

            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new Point(48, 88);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new Size(128, 18);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Search Term:";

            // 
            // txtSearchEvents
            // 
            this.txtSearchEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtSearchEvents.Location = new Point(150, 90);
            this.txtSearchEvents.Name = "txtSearchEvents";
            this.txtSearchEvents.Size = new Size(507, 26);
            this.txtSearchEvents.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtSearchEvents, "Enter search term for events or news.");

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new Point(50, 125);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(98, 18);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";

            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] { "All", "Sports", "Cultural", "Public Meetings" });
            this.cmbCategory.Location = new Point(150, 127);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(507, 26);
            this.cmbCategory.TabIndex = 3;
            this.toolTip.SetToolTip(this.cmbCategory, "Select the category of events.");

            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new Point(50, 170);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new Size(138, 18);
            this.lblDateRange.TabIndex = 4;
            this.lblDateRange.Text = "Date Range:";

            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new Point(150, 170);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new Size(200, 26);
            this.dtpFrom.TabIndex = 5;
            this.toolTip.SetToolTip(this.dtpFrom, "Select the start date for the event search.");

            // 
            // dtpTo
            // 
            this.dtpTo.Location = new Point(370, 170);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new Size(200, 26);
            this.dtpTo.TabIndex = 6;
            this.toolTip.SetToolTip(this.dtpTo, "Select the end date for the event search.");

            // 
            // btnSearchEvents
            // 
            this.btnSearchEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnSearchEvents.Location = new Point(150, 220);
            this.btnSearchEvents.Name = "btnSearchEvents";
            this.btnSearchEvents.Size = new Size(200, 50);
            this.btnSearchEvents.TabIndex = 7;
            this.btnSearchEvents.Text = "Search Events";
            this.toolTip.SetToolTip(this.btnSearchEvents, "Click to search events based on the given criteria.");
            this.btnSearchEvents.UseVisualStyleBackColor = true;
            this.btnSearchEvents.Click += new EventHandler(this.btnSearchEvents_Click);

            // 
            // lstEvents
            // 
            this.lstEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.lstEvents.Location = new Point(150, 280);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new Size(507, 150);
            this.lstEvents.TabIndex = 8;
            this.lstEvents.Items.Clear();

            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnBackToMainMenu.Location = new Point(150, 450);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new Size(200, 50);
            this.btnBackToMainMenu.TabIndex = 9;
            this.btnBackToMainMenu.Text = "Back to Main Menu";
            this.toolTip.SetToolTip(this.btnBackToMainMenu, "Click to return to the main menu.");
            this.btnBackToMainMenu.UseVisualStyleBackColor = true;
            this.btnBackToMainMenu.Click += new EventHandler(this.btnBackToMainMenu_Click);

            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.AutoSize = true;
            this.lblProgressMessage.ForeColor = Color.Black;
            this.lblProgressMessage.Location = new Point(150, 430);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new Size(0, 18);
            this.lblProgressMessage.TabIndex = 0;

            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new SizeF(10F, 18F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(807, 561); // Increased height for better layout
            this.Controls.Add(this.lblProgressMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblDateRange);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Controls.Add(this.btnSearchEvents);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtSearchEvents);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Font = new Font("Courier New", 10F, FontStyle.Bold);
            this.Name = "LocalEventsForm";
            this.Text = "Local Events and Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtSearchEvents;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearchEvents;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
