namespace HolidayBookingSystem.UserControls
{
    partial class UC_Suggestions
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
            this.label1 = new System.Windows.Forms.Label();
            this.suggesstionConfirmedButton = new HolidayBookingSystem.CustomControls.ThemedButton();
            this.suggestionsListView = new System.Windows.Forms.ListView();
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.suggestionsListView);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.suggesstionConfirmedButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Suggestions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please select suggestion";
            // 
            // suggesstionConfirmedButton
            // 
            this.suggesstionConfirmedButton.BackColor = System.Drawing.Color.Green;
            this.suggesstionConfirmedButton.CausesValidation = false;
            this.suggesstionConfirmedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.suggesstionConfirmedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suggesstionConfirmedButton.ForeColor = System.Drawing.Color.White;
            this.suggesstionConfirmedButton.Location = new System.Drawing.Point(232, 88);
            this.suggesstionConfirmedButton.Margin = new System.Windows.Forms.Padding(2);
            this.suggesstionConfirmedButton.Name = "suggesstionConfirmedButton";
            this.suggesstionConfirmedButton.Size = new System.Drawing.Size(144, 43);
            this.suggesstionConfirmedButton.TabIndex = 9;
            this.suggesstionConfirmedButton.Text = "Ask employee";
            this.suggesstionConfirmedButton.UseVisualStyleBackColor = false;
            this.suggesstionConfirmedButton.Click += new System.EventHandler(this.suggesstionConfirmedButton_Click);
            // 
            // suggestionsListView
            // 
            this.suggestionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StartDate,
            this.EndDate});
            this.suggestionsListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.suggestionsListView.FullRowSelect = true;
            this.suggestionsListView.GridLines = true;
            this.suggestionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.suggestionsListView.HideSelection = false;
            this.suggestionsListView.Location = new System.Drawing.Point(3, 16);
            this.suggestionsListView.MultiSelect = false;
            this.suggestionsListView.Name = "suggestionsListView";
            this.suggestionsListView.Size = new System.Drawing.Size(204, 203);
            this.suggestionsListView.TabIndex = 11;
            this.suggestionsListView.UseCompatibleStateImageBehavior = false;
            this.suggestionsListView.View = System.Windows.Forms.View.Details;
            // 
            // StartDate
            // 
            this.StartDate.Text = "Start Date";
            this.StartDate.Width = 100;
            // 
            // EndDate
            // 
            this.EndDate.Text = "End Date";
            this.EndDate.Width = 100;
            // 
            // UC_Suggestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_Suggestions";
            this.Size = new System.Drawing.Size(403, 247);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.ThemedButton suggesstionConfirmedButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView suggestionsListView;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader EndDate;
    }
}
