using System;
using System.Drawing;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkThemeToggle;
        private System.Windows.Forms.CheckBox chkSoundToggle;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkThemeToggle = new System.Windows.Forms.CheckBox();
            this.chkSoundToggle = new System.Windows.Forms.CheckBox();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceRequestStatus = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundOnOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceRequestStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkThemeToggle
            // 
            this.chkThemeToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThemeToggle.AutoSize = true;
            this.chkThemeToggle.BackColor = System.Drawing.Color.Transparent;
            this.chkThemeToggle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.chkThemeToggle.ForeColor = System.Drawing.Color.White;
            this.chkThemeToggle.Location = new System.Drawing.Point(244, 0);
            this.chkThemeToggle.Margin = new System.Windows.Forms.Padding(0);
            this.chkThemeToggle.Name = "chkThemeToggle";
            this.chkThemeToggle.Size = new System.Drawing.Size(218, 40);
            this.chkThemeToggle.TabIndex = 3;
            this.chkThemeToggle.Text = "Dark Mode";
            this.chkThemeToggle.UseVisualStyleBackColor = true;
            this.chkThemeToggle.CheckedChanged += new System.EventHandler(this.chkThemeToggle_CheckedChanged);
            // 
            // chkSoundToggle
            // 
            this.chkSoundToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSoundToggle.AutoSize = true;
            this.chkSoundToggle.BackColor = System.Drawing.Color.Transparent;
            this.chkSoundToggle.Checked = true;
            this.chkSoundToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoundToggle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.chkSoundToggle.ForeColor = System.Drawing.Color.White;
            this.chkSoundToggle.Location = new System.Drawing.Point(263, 0);
            this.chkSoundToggle.Margin = new System.Windows.Forms.Padding(0);
            this.chkSoundToggle.Name = "chkSoundToggle";
            this.chkSoundToggle.Size = new System.Drawing.Size(199, 40);
            this.chkSoundToggle.TabIndex = 4;
            this.chkSoundToggle.Text = "Sound On";
            this.chkSoundToggle.UseVisualStyleBackColor = true;
            this.chkSoundToggle.CheckedChanged += new System.EventHandler(this.chkSoundToggle_CheckedChanged);
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReportIssues.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportIssues.Location = new System.Drawing.Point(481, 195);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(200, 50);
            this.btnReportIssues.TabIndex = 2;
            this.btnReportIssues.Text = "Report Issues";
            this.toolTip.SetToolTip(this.btnReportIssues, "Click to report an issue to the municipality.");
            this.btnReportIssues.UseVisualStyleBackColor = true;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnLocalEvents
            // 
            this.btnLocalEvents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLocalEvents.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnLocalEvents.Location = new System.Drawing.Point(481, 265);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new System.Drawing.Size(200, 50);
            this.btnLocalEvents.TabIndex = 3;
            this.btnLocalEvents.Text = "Local Events and Announcements";
            this.toolTip.SetToolTip(this.btnLocalEvents, "This feature is not yet implemented.");
            this.btnLocalEvents.UseVisualStyleBackColor = true;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            // 
            // btnServiceRequestStatus
            // 
            this.btnServiceRequestStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServiceRequestStatus.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnServiceRequestStatus.Location = new System.Drawing.Point(481, 335);
            this.btnServiceRequestStatus.Name = "btnServiceRequestStatus";
            this.btnServiceRequestStatus.Size = new System.Drawing.Size(200, 50);
            this.btnServiceRequestStatus.TabIndex = 4;
            this.btnServiceRequestStatus.Text = "Service Request Status";
            this.toolTip.SetToolTip(this.btnServiceRequestStatus, "This feature is not yet implemented.");
            this.btnServiceRequestStatus.UseVisualStyleBackColor = true;
            this.btnServiceRequestStatus.Click += new System.EventHandler(this.btnServiceRequestStatus_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(581, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 73);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.ForeColor = System.Drawing.Color.White;
            this.lblPrompt.Location = new System.Drawing.Point(258, 123);
            this.lblPrompt.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(646, 49);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "Please select a service:";
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblPrompt, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnReportIssues, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnLocalEvents, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnServiceRequestStatus, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1162, 505);
            this.tableLayoutPanel.TabIndex = 5;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.LemonChiffon;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.viewMenuItem,
            this.servicesMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1162, 42);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 44);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundOnOffToolStripMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(74, 38);
            this.editMenuItem.Text = "Edit";
            // 
            // soundOnOffToolStripMenuItem
            // 
            this.soundOnOffToolStripMenuItem.Name = "soundOnOffToolStripMenuItem";
            this.soundOnOffToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.soundOnOffToolStripMenuItem.Text = "Sound On/Off";
            this.soundOnOffToolStripMenuItem.Click += new System.EventHandler(this.soundOnOffToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(85, 38);
            this.viewMenuItem.Text = "View";
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.darkModeToolStripMenuItem.Text = "Dark Mode On/Off";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // servicesMenuItem
            // 
            this.servicesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportIssueToolStripMenuItem,
            this.localEventsToolStripMenuItem,
            this.serviceRequestStatusToolStripMenuItem});
            this.servicesMenuItem.Name = "servicesMenuItem";
            this.servicesMenuItem.Size = new System.Drawing.Size(120, 38);
            this.servicesMenuItem.Text = "Services";
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(575, 44);
            this.reportIssueToolStripMenuItem.Text = "Report Issue                                 Ctrl+R";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click);
            // 
            // localEventsToolStripMenuItem
            // 
            this.localEventsToolStripMenuItem.Name = "localEventsToolStripMenuItem";
            this.localEventsToolStripMenuItem.Size = new System.Drawing.Size(575, 44);
            this.localEventsToolStripMenuItem.Text = "Local Events                                 Ctrl+L";
            this.localEventsToolStripMenuItem.Click += new System.EventHandler(this.localEventsToolStripMenuItem_Click);
            // 
            // serviceRequestStatusToolStripMenuItem
            // 
            this.serviceRequestStatusToolStripMenuItem.Name = "serviceRequestStatusToolStripMenuItem";
            this.serviceRequestStatusToolStripMenuItem.Size = new System.Drawing.Size(575, 44);
            this.serviceRequestStatusToolStripMenuItem.Text = "Service Request Status                Ctrl+S";
            this.serviceRequestStatusToolStripMenuItem.Click += new System.EventHandler(this.serviceRequestStatusToolStripMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(84, 38);
            this.helpMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(212, 44);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ST10203070_PROG7312_POE.Properties.Resources.CTBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1162, 547);
            this.Controls.Add(this.chkThemeToggle);
            this.Controls.Add(this.chkSoundToggle);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMenuForm";
            this.Text = "Municipal Services - Main Menu";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Method to position the checkbox dynamically
        private void PositionToggleCheckbox()
        {
            // Place it near the top right corner of the form
            this.chkThemeToggle.Location = new Point(this.ClientSize.Width - this.chkThemeToggle.Width - 0, 90);

            // Position the Sound checkbox below the Dark Mode checkbox
            this.chkSoundToggle.Location = new Point(this.ClientSize.Width - this.chkSoundToggle.Width - 9, this.chkThemeToggle.Bottom + 5);
        }

        #endregion

        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceRequestStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private ToolStripMenuItem soundOnOffToolStripMenuItem;
        private ToolStripMenuItem reportIssueToolStripMenuItem;
        private ToolStripMenuItem localEventsToolStripMenuItem;
        private ToolStripMenuItem serviceRequestStatusToolStripMenuItem;
    }
}
