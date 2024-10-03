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

        private RichTextBox rtbEvents;


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
          //this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblProgressMessage = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rtbEvents = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(893, 54);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Local Events and Announcements";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(50, 50);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(889, 36);
            this.lblPrompt.TabIndex = 11;
            this.lblPrompt.Text = "Search for local events and news in your area:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(48, 88);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(206, 31);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Search Term:";
            // 
            // txtSearchEvents
            // 
            this.txtSearchEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchEvents.Location = new System.Drawing.Point(150, 90);
            this.txtSearchEvents.Name = "txtSearchEvents";
            this.txtSearchEvents.Size = new System.Drawing.Size(507, 38);
            this.txtSearchEvents.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtSearchEvents, "Enter search term for events or news.");
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(50, 125);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(158, 31);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "All",
            "Sports",
            "Cultural",
            "Public Meetings"});
            this.cmbCategory.Location = new System.Drawing.Point(150, 127);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(507, 39);
            this.cmbCategory.TabIndex = 3;
            this.toolTip.SetToolTip(this.cmbCategory, "Select the category of events.");
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(50, 170);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(190, 31);
            this.lblDateRange.TabIndex = 4;
            this.lblDateRange.Text = "Date Range:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(150, 170);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 38);
            this.dtpFrom.TabIndex = 5;
            this.toolTip.SetToolTip(this.dtpFrom, "Select the start date for the event search.");
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(370, 170);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 38);
            this.dtpTo.TabIndex = 6;
            this.toolTip.SetToolTip(this.dtpTo, "Select the end date for the event search.");
            // 
            // btnSearchEvents
            // 
            this.btnSearchEvents.Location = new System.Drawing.Point(150, 220);
            this.btnSearchEvents.Name = "btnSearchEvents";
            this.btnSearchEvents.Size = new System.Drawing.Size(200, 50);
            this.btnSearchEvents.TabIndex = 7;
            this.btnSearchEvents.Text = "Search Events";
            this.toolTip.SetToolTip(this.btnSearchEvents, "Click to search events based on the given criteria.");
            this.btnSearchEvents.UseVisualStyleBackColor = true;
            this.btnSearchEvents.Click += new System.EventHandler(this.btnSearchEvents_Click);
            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToMainMenu.Location = new System.Drawing.Point(150, 450);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(200, 50);
            this.btnBackToMainMenu.TabIndex = 9;
            this.btnBackToMainMenu.Text = "Back to Main Menu";
            this.toolTip.SetToolTip(this.btnBackToMainMenu, "Click to return to the main menu.");
            this.btnBackToMainMenu.UseVisualStyleBackColor = true;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            // 
            // lstEvents
            // 
/*            this.lstEvents.ItemHeight = 31;
            this.lstEvents.Location = new System.Drawing.Point(0, 0);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(120, 66);
            this.lstEvents.TabIndex = 12;*/
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.AutoSize = true;
            this.lblProgressMessage.ForeColor = System.Drawing.Color.Black;
            this.lblProgressMessage.Location = new System.Drawing.Point(150, 430);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(0, 31);
            this.lblProgressMessage.TabIndex = 0;
            // 
            // rtbEvents
            // 
            this.rtbEvents.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            this.rtbEvents.BackColor = System.Drawing.Color.White;
            this.rtbEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbEvents.Font = new System.Drawing.Font("Courier New", 10F);
            this.rtbEvents.ForeColor = System.Drawing.Color.Black;
            this.rtbEvents.Location = new System.Drawing.Point(150, 280);
            this.rtbEvents.Name = "rtbEvents";
            this.rtbEvents.ReadOnly = true;
            this.rtbEvents.Size = new System.Drawing.Size(507, 150);
            this.rtbEvents.TabIndex = 0;
            this.rtbEvents.Text = "";
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(807, 561);
            this.Controls.Add(this.rtbEvents);
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
            this.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
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
