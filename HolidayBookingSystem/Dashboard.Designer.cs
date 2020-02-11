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
            this.btn_edit_employee = new System.Windows.Forms.Button();
            this.btn_delete_employee = new System.Windows.Forms.Button();
            this.btn_add_employee = new System.Windows.Forms.Button();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.panel_side.SuspendLayout();
            this.panel_manage_side.SuspendLayout();
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
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(2051, 50);
            this.panel_top.TabIndex = 0;
            // 
            // btn_calendar
            // 
            this.btn_calendar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_calendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_calendar.Location = new System.Drawing.Point(442, 0);
            this.btn_calendar.Name = "btn_calendar";
            this.btn_calendar.Size = new System.Drawing.Size(221, 50);
            this.btn_calendar.TabIndex = 3;
            this.btn_calendar.Text = "Calendar View";
            this.btn_calendar.UseVisualStyleBackColor = false;
            this.btn_calendar.Click += new System.EventHandler(this.btn_calendar_Click);
            // 
            // btn_holiday
            // 
            this.btn_holiday.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_holiday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_holiday.Location = new System.Drawing.Point(221, 0);
            this.btn_holiday.Name = "btn_holiday";
            this.btn_holiday.Size = new System.Drawing.Size(221, 50);
            this.btn_holiday.TabIndex = 2;
            this.btn_holiday.Text = "Holiday Requests";
            this.btn_holiday.UseVisualStyleBackColor = false;
            this.btn_holiday.Click += new System.EventHandler(this.btn_holiday_Click);
            // 
            // btn_manage
            // 
            this.btn_manage.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_manage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_manage.Location = new System.Drawing.Point(0, 0);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(221, 50);
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
            this.panel_side.Location = new System.Drawing.Point(0, 50);
            this.panel_side.Name = "panel_side";
            this.panel_side.Size = new System.Drawing.Size(200, 735);
            this.panel_side.TabIndex = 1;
            // 
            // panel_manage_side
            // 
            this.panel_manage_side.Controls.Add(this.btn_edit_employee);
            this.panel_manage_side.Controls.Add(this.btn_delete_employee);
            this.panel_manage_side.Controls.Add(this.btn_add_employee);
            this.panel_manage_side.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_manage_side.Location = new System.Drawing.Point(0, 0);
            this.panel_manage_side.Name = "panel_manage_side";
            this.panel_manage_side.Size = new System.Drawing.Size(200, 735);
            this.panel_manage_side.TabIndex = 2;
            // 
            // btn_edit_employee
            // 
            this.btn_edit_employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_edit_employee.Location = new System.Drawing.Point(0, 84);
            this.btn_edit_employee.Name = "btn_edit_employee";
            this.btn_edit_employee.Size = new System.Drawing.Size(200, 42);
            this.btn_edit_employee.TabIndex = 3;
            this.btn_edit_employee.Text = "Edit Employee";
            this.btn_edit_employee.UseVisualStyleBackColor = true;
            this.btn_edit_employee.Click += new System.EventHandler(this.btn_edit_employee_Click);
            // 
            // btn_delete_employee
            // 
            this.btn_delete_employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_delete_employee.Location = new System.Drawing.Point(0, 42);
            this.btn_delete_employee.Name = "btn_delete_employee";
            this.btn_delete_employee.Size = new System.Drawing.Size(200, 42);
            this.btn_delete_employee.TabIndex = 2;
            this.btn_delete_employee.Text = "Delete Employee";
            this.btn_delete_employee.UseVisualStyleBackColor = true;
            this.btn_delete_employee.Click += new System.EventHandler(this.btn_delete_employee_Click);
            // 
            // btn_add_employee
            // 
            this.btn_add_employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_employee.Location = new System.Drawing.Point(0, 0);
            this.btn_add_employee.Name = "btn_add_employee";
            this.btn_add_employee.Size = new System.Drawing.Size(200, 42);
            this.btn_add_employee.TabIndex = 1;
            this.btn_add_employee.Text = "Add Employee";
            this.btn_add_employee.UseVisualStyleBackColor = true;
            this.btn_add_employee.Click += new System.EventHandler(this.btn_add_employee_Click);
            // 
            // panel_main
            // 
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(200, 50);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1851, 735);
            this.panel_main.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(2051, 785);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_side);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.panel_top.ResumeLayout(false);
            this.panel_side.ResumeLayout(false);
            this.panel_manage_side.ResumeLayout(false);
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
    }
}