namespace HolidayBookingSystem.UserControls
{
    partial class UC_EmployeesPresent
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.workingEmployeesListView = new System.Windows.Forms.ListView();
            this.workingId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workingEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.onHolidayEmployeesListView = new System.Windows.Forms.ListView();
            this.onHolidayId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.onHolidayEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedDateLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datePickCalendar = new System.Windows.Forms.MonthCalendar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.departmentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.onHolidayDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.selectedDateLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employees";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Lime;
            this.groupBox4.Controls.Add(this.workingEmployeesListView);
            this.groupBox4.Location = new System.Drawing.Point(15, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 322);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Working";
            // 
            // workingEmployeesListView
            // 
            this.workingEmployeesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.workingId,
            this.workingEmployee,
            this.departmentName});
            this.workingEmployeesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingEmployeesListView.HideSelection = false;
            this.workingEmployeesListView.Location = new System.Drawing.Point(3, 16);
            this.workingEmployeesListView.Name = "workingEmployeesListView";
            this.workingEmployeesListView.Size = new System.Drawing.Size(204, 303);
            this.workingEmployeesListView.TabIndex = 0;
            this.workingEmployeesListView.UseCompatibleStateImageBehavior = false;
            this.workingEmployeesListView.View = System.Windows.Forms.View.Details;
            // 
            // workingId
            // 
            this.workingId.Text = "ID";
            this.workingId.Width = 30;
            // 
            // workingEmployee
            // 
            this.workingEmployee.Text = "Employee Name";
            this.workingEmployee.Width = 100;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gold;
            this.groupBox3.Controls.Add(this.onHolidayEmployeesListView);
            this.groupBox3.Location = new System.Drawing.Point(246, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 322);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "On Holiday";
            // 
            // onHolidayEmployeesListView
            // 
            this.onHolidayEmployeesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.onHolidayId,
            this.onHolidayEmployee,
            this.onHolidayDepartment});
            this.onHolidayEmployeesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onHolidayEmployeesListView.HideSelection = false;
            this.onHolidayEmployeesListView.Location = new System.Drawing.Point(3, 16);
            this.onHolidayEmployeesListView.Name = "onHolidayEmployeesListView";
            this.onHolidayEmployeesListView.Size = new System.Drawing.Size(215, 303);
            this.onHolidayEmployeesListView.TabIndex = 1;
            this.onHolidayEmployeesListView.UseCompatibleStateImageBehavior = false;
            this.onHolidayEmployeesListView.View = System.Windows.Forms.View.Details;
            // 
            // onHolidayId
            // 
            this.onHolidayId.Text = "ID";
            this.onHolidayId.Width = 30;
            // 
            // onHolidayEmployee
            // 
            this.onHolidayEmployee.Text = "Employee Name";
            this.onHolidayEmployee.Width = 100;
            // 
            // selectedDateLabel
            // 
            this.selectedDateLabel.AutoSize = true;
            this.selectedDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedDateLabel.Location = new System.Drawing.Point(172, 20);
            this.selectedDateLabel.Name = "selectedDateLabel";
            this.selectedDateLabel.Size = new System.Drawing.Size(91, 16);
            this.selectedDateLabel.TabIndex = 4;
            this.selectedDateLabel.Text = "Selected day ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.datePickCalendar);
            this.groupBox2.Location = new System.Drawing.Point(488, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 407);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Selection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Please select a day";
            // 
            // datePickCalendar
            // 
            this.datePickCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datePickCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.datePickCalendar.Location = new System.Drawing.Point(12, 61);
            this.datePickCalendar.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.datePickCalendar.MaxSelectionCount = 1;
            this.datePickCalendar.MinDate = new System.DateTime(2020, 2, 1, 0, 0, 0, 0);
            this.datePickCalendar.Name = "datePickCalendar";
            this.datePickCalendar.TabIndex = 0;
            this.datePickCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.datePickCalendar_DateSelected);
            // 
            // departmentName
            // 
            this.departmentName.Text = "Department";
            this.departmentName.Width = 70;
            // 
            // onHolidayDepartment
            // 
            this.onHolidayDepartment.Text = "Department";
            this.onHolidayDepartment.Width = 80;
            // 
            // UC_EmployeesPresent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_EmployeesPresent";
            this.Size = new System.Drawing.Size(740, 410);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView onHolidayEmployeesListView;
        private System.Windows.Forms.ListView workingEmployeesListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label selectedDateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar datePickCalendar;
        private System.Windows.Forms.ColumnHeader workingId;
        private System.Windows.Forms.ColumnHeader workingEmployee;
        private System.Windows.Forms.ColumnHeader onHolidayId;
        private System.Windows.Forms.ColumnHeader onHolidayEmployee;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ColumnHeader departmentName;
        private System.Windows.Forms.ColumnHeader onHolidayDepartment;
    }
}
