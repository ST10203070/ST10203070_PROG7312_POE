using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    partial class ServiceRequestStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.ListView lstServiceRequests;
        private System.Windows.Forms.Button btnBackToMainMenu;
        private System.Windows.Forms.ToolTip toolTip;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lstServiceRequests = new System.Windows.Forms.ListView();
            this.btnBackToMainMenu = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Service Request Status";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(50, 50);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(600, 20);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "Track your submitted service requests and view their status:";

            // 
            // lstServiceRequests
            // 
            this.lstServiceRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))));
            this.lstServiceRequests.Location = new System.Drawing.Point(50, 90);
            this.lstServiceRequests.Name = "lstServiceRequests";
            this.lstServiceRequests.Size = new System.Drawing.Size(700, 300);
            this.lstServiceRequests.TabIndex = 2;
            this.lstServiceRequests.View = System.Windows.Forms.View.Details;
            this.lstServiceRequests.FullRowSelect = true;
            this.lstServiceRequests.GridLines = true;
            this.lstServiceRequests.Scrollable = true;

            // Columns for ListView
            this.lstServiceRequests.Columns.Add("Request ID", 150, HorizontalAlignment.Left);
            this.lstServiceRequests.Columns.Add("Description", 350, HorizontalAlignment.Left);
            this.lstServiceRequests.Columns.Add("Status", 150, HorizontalAlignment.Left);
            this.lstServiceRequests.Columns.Add("Submission Date", 150, HorizontalAlignment.Left);

            // 
            // btnBackToMainMenu
            // 
            this.btnBackToMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToMainMenu.Location = new System.Drawing.Point(50, 410);
            this.btnBackToMainMenu.Name = "btnBackToMainMenu";
            this.btnBackToMainMenu.Size = new System.Drawing.Size(200, 50);
            this.btnBackToMainMenu.TabIndex = 3;
            this.btnBackToMainMenu.Text = "Back to Main Menu";
            this.toolTip.SetToolTip(this.btnBackToMainMenu, "Click to return to the main menu.");
            this.btnBackToMainMenu.UseVisualStyleBackColor = true;
            this.btnBackToMainMenu.Click += new System.EventHandler(this.btnBackToMainMenu_Click);

            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.lstServiceRequests);
            this.Controls.Add(this.btnBackToMainMenu);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "Service Request Status";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
