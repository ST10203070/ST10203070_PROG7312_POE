using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ST10203070_PROG7312_POE
{
    partial class ReportIssuesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ProgressBar progressBarCompletion;
        private System.Windows.Forms.ToolTip progressBarToolTip;
        private Label lblProgressMessage;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttachMedia = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBarCompletion = new System.Windows.Forms.ProgressBar();
            this.lblReportProgress = new System.Windows.Forms.Label();
            this.progressBarToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblProgressMessage = new System.Windows.Forms.Label();
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
            this.lblTitle.Size = new System.Drawing.Size(194, 27);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Report Issues";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(50, 50);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(508, 18);
            this.lblPrompt.TabIndex = 11;
            this.lblPrompt.Text = "Please provide the following details of the issue:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(50, 88);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(98, 18);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(150, 90);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(507, 26);
            this.txtLocation.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtLocation, "Enter the location of the issue.");
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(50, 125);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(98, 18);
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
            "Sanitation",
            "Roads",
            "Utilities",
            "Public Safety",
            "Other"});
            this.cmbCategory.Location = new System.Drawing.Point(150, 127);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(507, 26);
            this.cmbCategory.TabIndex = 3;
            this.toolTip.SetToolTip(this.cmbCategory, "Select the category of the reported issue.");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(50, 173);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(128, 18);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.Location = new System.Drawing.Point(150, 175);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(507, 80);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            this.toolTip.SetToolTip(this.rtbDescription, "Provide a detailed description of the issue.");
            // 
            // btnAttachMedia
            // 
            this.btnAttachMedia.Location = new System.Drawing.Point(150, 270);
            this.btnAttachMedia.Name = "btnAttachMedia";
            this.btnAttachMedia.Size = new System.Drawing.Size(200, 50);
            this.btnAttachMedia.TabIndex = 6;
            this.btnAttachMedia.Text = "Attach Media";
            this.toolTip.SetToolTip(this.btnAttachMedia, "Click to attach images or documents related to the issue.");
            this.btnAttachMedia.UseVisualStyleBackColor = true;
            this.btnAttachMedia.Click += new System.EventHandler(this.btnAttachMedia_Click);
            this.btnAttachMedia.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomButton_Paint);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(457, 386);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(200, 50);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.toolTip.SetToolTip(this.btnSubmit, "Click to submit the issue report.");
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomButton_Paint);
            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToMainMenu.Location = new System.Drawing.Point(150, 386);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(200, 50);
            this.btnBackToMainMenu.TabIndex = 8;
            this.btnBackToMainMenu.Text = "Back to Main Menu";
            this.toolTip.SetToolTip(this.btnBackToMainMenu, "Click to return to the main menu.");
            this.btnBackToMainMenu.UseVisualStyleBackColor = true;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);
            this.btnBackToMainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomButton_Paint);
            // 
            // lblEngagement
            // 
            this.lblEngagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEngagement.AutoSize = true;
            this.lblEngagement.Location = new System.Drawing.Point(150, 321);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new System.Drawing.Size(0, 18);
            this.lblEngagement.TabIndex = 9;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(150, 346);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(507, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // progressBarCompletion
            // 
            this.progressBarCompletion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCompletion.Location = new System.Drawing.Point(470, 296);
            this.progressBarCompletion.Maximum = 4;
            this.progressBarCompletion.Name = "progressBarCompletion";
            this.progressBarCompletion.Size = new System.Drawing.Size(187, 24);
            this.progressBarCompletion.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCompletion.TabIndex = 12;
            // 
            // lblReportProgress
            // 
            this.lblReportProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportProgress.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportProgress.Location = new System.Drawing.Point(465, 265);
            this.lblReportProgress.Name = "lblReportProgress";
            this.lblReportProgress.Size = new System.Drawing.Size(248, 35);
            this.lblReportProgress.TabIndex = 13;
            this.lblReportProgress.Text = "Report Progress";
            this.lblReportProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReportProgress.Click += new System.EventHandler(this.lblReportProgress_Click);
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.AutoSize = true;
            this.lblProgressMessage.ForeColor = System.Drawing.Color.Black;
            this.lblProgressMessage.Location = new System.Drawing.Point(468, 320);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(0, 18);
            this.lblProgressMessage.TabIndex = 0;
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(807, 461);
            this.Controls.Add(this.lblProgressMessage);
            this.Controls.Add(this.lblReportProgress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAttachMedia);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.progressBarCompletion);
            this.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.Name = "ReportIssuesForm";
            this.Text = "Report Issues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttachMedia;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolTip toolTip;
        private Label lblReportProgress;
    }
}
