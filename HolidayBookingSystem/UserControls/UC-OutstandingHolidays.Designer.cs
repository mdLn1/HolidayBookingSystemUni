namespace HolidayBookingSystem.UserControls
{
    partial class UC_OutstandingHolidays
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outstandingHolidaysListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WorkingDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fourthLabel = new System.Windows.Forms.Label();
            this.thirdLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.firstLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.declineButton = new HolidayBookingSystem.CustomControls.ThemedButton();
            this.approveButton = new HolidayBookingSystem.CustomControls.ThemedButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outstandingHolidaysListView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 370);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outstanding Holiday Requests";
            // 
            // outstandingHolidaysListView
            // 
            this.outstandingHolidaysListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.StartDate,
            this.EndDate,
            this.WorkingDays});
            this.outstandingHolidaysListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outstandingHolidaysListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outstandingHolidaysListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outstandingHolidaysListView.FullRowSelect = true;
            this.outstandingHolidaysListView.GridLines = true;
            this.outstandingHolidaysListView.HideSelection = false;
            this.outstandingHolidaysListView.Location = new System.Drawing.Point(3, 16);
            this.outstandingHolidaysListView.Name = "outstandingHolidaysListView";
            this.outstandingHolidaysListView.Size = new System.Drawing.Size(725, 351);
            this.outstandingHolidaysListView.TabIndex = 0;
            this.outstandingHolidaysListView.UseCompatibleStateImageBehavior = false;
            this.outstandingHolidaysListView.View = System.Windows.Forms.View.Details;
            this.outstandingHolidaysListView.SelectedIndexChanged += new System.EventHandler(this.outstandingHolidaysListView_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Tag = "";
            this.ID.Text = "ID";
            // 
            // StartDate
            // 
            this.StartDate.Text = "StartDate";
            this.StartDate.Width = 100;
            // 
            // EndDate
            // 
            this.EndDate.Text = "EndDate";
            this.EndDate.Width = 100;
            // 
            // WorkingDays
            // 
            this.WorkingDays.Text = "WorkingDays";
            this.WorkingDays.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.messageLabel);
            this.groupBox2.Controls.Add(this.declineButton);
            this.groupBox2.Controls.Add(this.approveButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(368, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(363, 370);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Approve/Reject Request";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.firstLabel);
            this.groupBox3.Controls.Add(this.fourthLabel);
            this.groupBox3.Controls.Add(this.secondLabel);
            this.groupBox3.Controls.Add(this.thirdLabel);
            this.groupBox3.Location = new System.Drawing.Point(5, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 211);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Breaking Constraints";
            // 
            // fourthLabel
            // 
            this.fourthLabel.AutoSize = true;
            this.fourthLabel.Location = new System.Drawing.Point(6, 157);
            this.fourthLabel.Name = "fourthLabel";
            this.fourthLabel.Size = new System.Drawing.Size(220, 13);
            this.fourthLabel.TabIndex = 14;
            this.fourthLabel.Text = "At least 60% of a department must be on duty";
            // 
            // thirdLabel
            // 
            this.thirdLabel.AutoSize = true;
            this.thirdLabel.Location = new System.Drawing.Point(6, 114);
            this.thirdLabel.Name = "thirdLabel";
            this.thirdLabel.Size = new System.Drawing.Size(321, 13);
            this.thirdLabel.TabIndex = 13;
            this.thirdLabel.Text = "At least one manager and one senior staff member must be on duty";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(6, 71);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(335, 13);
            this.secondLabel.TabIndex = 12;
            this.secondLabel.Text = "Either the head or the deputy head of the department must be on duty";
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Location = new System.Drawing.Point(6, 33);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(323, 13);
            this.firstLabel.TabIndex = 11;
            this.firstLabel.Text = "No employee can exceed the number of days of holiday entitlement";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.Green;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.messageLabel.Location = new System.Drawing.Point(35, 50);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Padding = new System.Windows.Forms.Padding(2);
            this.messageLabel.Size = new System.Drawing.Size(4, 20);
            this.messageLabel.TabIndex = 10;
            this.messageLabel.Visible = false;
            // 
            // declineButton
            // 
            this.declineButton.BackColor = System.Drawing.Color.IndianRed;
            this.declineButton.CausesValidation = false;
            this.declineButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.declineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.declineButton.ForeColor = System.Drawing.Color.White;
            this.declineButton.Location = new System.Drawing.Point(199, 298);
            this.declineButton.Margin = new System.Windows.Forms.Padding(2);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(132, 43);
            this.declineButton.TabIndex = 9;
            this.declineButton.Text = "Decline";
            this.declineButton.UseVisualStyleBackColor = false;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // approveButton
            // 
            this.approveButton.BackColor = System.Drawing.Color.Green;
            this.approveButton.CausesValidation = false;
            this.approveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.approveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveButton.ForeColor = System.Drawing.Color.White;
            this.approveButton.Location = new System.Drawing.Point(38, 298);
            this.approveButton.Margin = new System.Windows.Forms.Padding(2);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(132, 43);
            this.approveButton.TabIndex = 9;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = false;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // UC_OutstandingHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_OutstandingHolidays";
            this.Size = new System.Drawing.Size(731, 370);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView outstandingHolidaysListView;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader EndDate;
        private System.Windows.Forms.ColumnHeader WorkingDays;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CustomControls.ThemedButton declineButton;
        private CustomControls.ThemedButton approveButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label fourthLabel;
        private System.Windows.Forms.Label thirdLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label firstLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
