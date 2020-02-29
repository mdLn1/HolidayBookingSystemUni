namespace HolidayBookingSystem
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_top = new System.Windows.Forms.Panel();
            this.btn_calendar = new System.Windows.Forms.Button();
            this.btn_holiday = new System.Windows.Forms.Button();
            this.btn_manage = new System.Windows.Forms.Button();
            this.panel_side = new System.Windows.Forms.Panel();
            this.panel_manage_side = new System.Windows.Forms.Panel();
            this.panel_holiday_requests = new System.Windows.Forms.Panel();
            this.btn_day_view = new System.Windows.Forms.Button();
            this.btn_holiday_bookings = new System.Windows.Forms.Button();
            this.btn_pending_requests = new System.Windows.Forms.Button();
            this.panel_manage_employee = new System.Windows.Forms.Panel();
            this.btn_edit_employee = new System.Windows.Forms.Button();
            this.btn_add_employee = new System.Windows.Forms.Button();
            this.btn_delete_employee = new System.Windows.Forms.Button();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.panel_side.SuspendLayout();
            this.panel_manage_side.SuspendLayout();
            this.panel_holiday_requests.SuspendLayout();
            this.panel_manage_employee.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.SystemColors.Menu;
            this.panel_top.Controls.Add(this.btn_calendar);
            this.panel_top.Controls.Add(this.btn_holiday);
            this.panel_top.Controls.Add(this.btn_manage);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(2);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(962, 26);
            this.panel_top.TabIndex = 0;
            // 
            // btn_calendar
            // 
            this.btn_calendar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_calendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_calendar.Location = new System.Drawing.Point(220, 0);
            this.btn_calendar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_calendar.Name = "btn_calendar";
            this.btn_calendar.Size = new System.Drawing.Size(110, 26);
            this.btn_calendar.TabIndex = 3;
            this.btn_calendar.Text = "Calendar View";
            this.btn_calendar.UseVisualStyleBackColor = false;
            this.btn_calendar.Click += new System.EventHandler(this.btn_calendar_Click);
            // 
            // btn_holiday
            // 
            this.btn_holiday.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_holiday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_holiday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_holiday.Location = new System.Drawing.Point(110, 0);
            this.btn_holiday.Margin = new System.Windows.Forms.Padding(2);
            this.btn_holiday.Name = "btn_holiday";
            this.btn_holiday.Size = new System.Drawing.Size(110, 26);
            this.btn_holiday.TabIndex = 2;
            this.btn_holiday.Text = "Holiday Requests";
            this.btn_holiday.UseVisualStyleBackColor = false;
            this.btn_holiday.Click += new System.EventHandler(this.btn_holiday_Click);
            // 
            // btn_manage
            // 
            this.btn_manage.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_manage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_manage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_manage.Location = new System.Drawing.Point(0, 0);
            this.btn_manage.Margin = new System.Windows.Forms.Padding(2);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(110, 26);
            this.btn_manage.TabIndex = 1;
            this.btn_manage.Text = "Manage Employees";
            this.btn_manage.UseVisualStyleBackColor = false;
            this.btn_manage.Click += new System.EventHandler(this.btn_manage_Click);
            // 
            // panel_side
            // 
            this.panel_side.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel_side.Controls.Add(this.panel_manage_side);
            this.panel_side.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_side.Location = new System.Drawing.Point(0, 26);
            this.panel_side.Margin = new System.Windows.Forms.Padding(2);
            this.panel_side.Name = "panel_side";
            this.panel_side.Size = new System.Drawing.Size(100, 383);
            this.panel_side.TabIndex = 1;
            // 
            // panel_manage_side
            // 
            this.panel_manage_side.Controls.Add(this.panel_holiday_requests);
            this.panel_manage_side.Controls.Add(this.panel_manage_employee);
            this.panel_manage_side.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_manage_side.Location = new System.Drawing.Point(0, 0);
            this.panel_manage_side.Margin = new System.Windows.Forms.Padding(2);
            this.panel_manage_side.Name = "panel_manage_side";
            this.panel_manage_side.Size = new System.Drawing.Size(100, 383);
            this.panel_manage_side.TabIndex = 2;
            // 
            // panel_holiday_requests
            // 
            this.panel_holiday_requests.Controls.Add(this.btn_day_view);
            this.panel_holiday_requests.Controls.Add(this.btn_holiday_bookings);
            this.panel_holiday_requests.Controls.Add(this.btn_pending_requests);
            this.panel_holiday_requests.Location = new System.Drawing.Point(0, 71);
            this.panel_holiday_requests.Margin = new System.Windows.Forms.Padding(2);
            this.panel_holiday_requests.Name = "panel_holiday_requests";
            this.panel_holiday_requests.Size = new System.Drawing.Size(100, 92);
            this.panel_holiday_requests.TabIndex = 5;
            // 
            // btn_day_view
            // 
            this.btn_day_view.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_day_view.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_day_view.Location = new System.Drawing.Point(0, 66);
            this.btn_day_view.Margin = new System.Windows.Forms.Padding(2);
            this.btn_day_view.Name = "btn_day_view";
            this.btn_day_view.Size = new System.Drawing.Size(100, 22);
            this.btn_day_view.TabIndex = 3;
            this.btn_day_view.Text = "Day View";
            this.btn_day_view.UseVisualStyleBackColor = true;
            this.btn_day_view.Click += new System.EventHandler(this.btn_day_view_Click);
            // 
            // btn_holiday_bookings
            // 
            this.btn_holiday_bookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_holiday_bookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_holiday_bookings.Location = new System.Drawing.Point(0, 44);
            this.btn_holiday_bookings.Margin = new System.Windows.Forms.Padding(2);
            this.btn_holiday_bookings.Name = "btn_holiday_bookings";
            this.btn_holiday_bookings.Size = new System.Drawing.Size(100, 22);
            this.btn_holiday_bookings.TabIndex = 1;
            this.btn_holiday_bookings.Text = "Holiday Bookings";
            this.btn_holiday_bookings.UseVisualStyleBackColor = true;
            this.btn_holiday_bookings.Click += new System.EventHandler(this.btn_holiday_bookings_Click);
            // 
            // btn_pending_requests
            // 
            this.btn_pending_requests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pending_requests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_pending_requests.Location = new System.Drawing.Point(0, 0);
            this.btn_pending_requests.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pending_requests.Name = "btn_pending_requests";
            this.btn_pending_requests.Size = new System.Drawing.Size(100, 44);
            this.btn_pending_requests.TabIndex = 2;
            this.btn_pending_requests.Text = "Pending Requests";
            this.btn_pending_requests.UseVisualStyleBackColor = true;
            this.btn_pending_requests.Click += new System.EventHandler(this.btn_pending_requests_Click);
            // 
            // panel_manage_employee
            // 
            this.panel_manage_employee.Controls.Add(this.btn_edit_employee);
            this.panel_manage_employee.Controls.Add(this.btn_add_employee);
            this.panel_manage_employee.Controls.Add(this.btn_delete_employee);
            this.panel_manage_employee.Location = new System.Drawing.Point(0, 0);
            this.panel_manage_employee.Margin = new System.Windows.Forms.Padding(2);
            this.panel_manage_employee.Name = "panel_manage_employee";
            this.panel_manage_employee.Size = new System.Drawing.Size(100, 67);
            this.panel_manage_employee.TabIndex = 4;
            // 
            // btn_edit_employee
            // 
            this.btn_edit_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit_employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_edit_employee.Location = new System.Drawing.Point(0, 22);
            this.btn_edit_employee.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit_employee.Name = "btn_edit_employee";
            this.btn_edit_employee.Size = new System.Drawing.Size(100, 22);
            this.btn_edit_employee.TabIndex = 3;
            this.btn_edit_employee.Text = "Edit Employee";
            this.btn_edit_employee.UseVisualStyleBackColor = true;
            this.btn_edit_employee.Click += new System.EventHandler(this.btn_edit_employee_Click);
            // 
            // btn_add_employee
            // 
            this.btn_add_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add_employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_employee.Location = new System.Drawing.Point(0, 0);
            this.btn_add_employee.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add_employee.Name = "btn_add_employee";
            this.btn_add_employee.Size = new System.Drawing.Size(100, 22);
            this.btn_add_employee.TabIndex = 1;
            this.btn_add_employee.Text = "Add Employee";
            this.btn_add_employee.UseVisualStyleBackColor = true;
            this.btn_add_employee.Click += new System.EventHandler(this.btn_add_employee_Click);
            // 
            // btn_delete_employee
            // 
            this.btn_delete_employee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete_employee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_delete_employee.Location = new System.Drawing.Point(0, 45);
            this.btn_delete_employee.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete_employee.Name = "btn_delete_employee";
            this.btn_delete_employee.Size = new System.Drawing.Size(100, 22);
            this.btn_delete_employee.TabIndex = 2;
            this.btn_delete_employee.Text = "Delete Employee";
            this.btn_delete_employee.UseVisualStyleBackColor = true;
            this.btn_delete_employee.Click += new System.EventHandler(this.btn_delete_employee_Click);
            // 
            // panel_main
            // 
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(100, 26);
            this.panel_main.Margin = new System.Windows.Forms.Padding(2);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(862, 383);
            this.panel_main.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(962, 409);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_side);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.panel_top.ResumeLayout(false);
            this.panel_side.ResumeLayout(false);
            this.panel_manage_side.ResumeLayout(false);
            this.panel_holiday_requests.ResumeLayout(false);
            this.panel_manage_employee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button btn_calendar;
        private System.Windows.Forms.Button btn_holiday;
        private System.Windows.Forms.Button btn_manage;
        private System.Windows.Forms.Panel panel_side;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_manage_side;
        private System.Windows.Forms.Button btn_edit_employee;
        private System.Windows.Forms.Button btn_delete_employee;
        private System.Windows.Forms.Button btn_add_employee;
        private System.Windows.Forms.Panel panel_manage_employee;
        private System.Windows.Forms.Panel panel_holiday_requests;
        private System.Windows.Forms.Button btn_day_view;
        private System.Windows.Forms.Button btn_holiday_bookings;
        private System.Windows.Forms.Button btn_pending_requests;
    }
}