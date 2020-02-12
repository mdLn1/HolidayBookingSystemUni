namespace HolidayBookingSystem
{
    partial class UC_DeleteUser
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
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lv_users = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemainingDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Department = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_delete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_refresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_refresh.Location = new System.Drawing.Point(803, 25);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(125, 52);
            this.btn_refresh.TabIndex = 1;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lv_users
            // 
            this.lv_users.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Username,
            this.StartDate,
            this.RemainingDays,
            this.Role,
            this.Department});
            this.lv_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_users.HideSelection = false;
            this.lv_users.Location = new System.Drawing.Point(0, 0);
            this.lv_users.Name = "lv_users";
            this.lv_users.Size = new System.Drawing.Size(1618, 550);
            this.lv_users.TabIndex = 2;
            this.lv_users.UseCompatibleStateImageBehavior = false;
            this.lv_users.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 30;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 120;
            // 
            // StartDate
            // 
            this.StartDate.Text = "Start Date";
            this.StartDate.Width = 100;
            // 
            // RemainingDays
            // 
            this.RemainingDays.Text = "Remaining Days";
            this.RemainingDays.Width = 100;
            // 
            // Role
            // 
            this.Role.Text = "Role";
            this.Role.Width = 80;
            // 
            // Department
            // 
            this.Department.Text = "Department";
            this.Department.Width = 100;
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_delete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_delete.Location = new System.Drawing.Point(674, 25);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(123, 52);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1624, 670);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Employee";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_refresh);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 567);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1618, 100);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lv_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1618, 550);
            this.panel1.TabIndex = 4;
            // 
            // UC_DeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "UC_DeleteUser";
            this.Size = new System.Drawing.Size(1624, 670);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.ListView lv_users;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader RemainingDays;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
