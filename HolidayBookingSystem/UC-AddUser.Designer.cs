namespace HolidayBookingSystem
{
    partial class UC_AddUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_register_employee = new System.Windows.Forms.Button();
            this.cb_roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.cb_departments = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dp_add_employee = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 690);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tb_username);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_register_employee);
            this.groupBox1.Controls.Add(this.cb_roles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_password);
            this.groupBox1.Controls.Add(this.cb_departments);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dp_add_employee);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1295, 690);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Employee";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(521, 24);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(225, 31);
            this.tb_username.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(383, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Role:";
            // 
            // btn_register_employee
            // 
            this.btn_register_employee.Location = new System.Drawing.Point(485, 296);
            this.btn_register_employee.Name = "btn_register_employee";
            this.btn_register_employee.Size = new System.Drawing.Size(159, 51);
            this.btn_register_employee.TabIndex = 1;
            this.btn_register_employee.Text = "Register";
            this.btn_register_employee.UseVisualStyleBackColor = true;
            this.btn_register_employee.Click += new System.EventHandler(this.btn_register_employee_Click);
            // 
            // cb_roles
            // 
            this.cb_roles.FormattingEnabled = true;
            this.cb_roles.Location = new System.Drawing.Point(521, 184);
            this.cb_roles.Name = "cb_roles";
            this.cb_roles.Size = new System.Drawing.Size(225, 33);
            this.cb_roles.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Department:";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(521, 74);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(225, 31);
            this.tb_password.TabIndex = 4;
            // 
            // cb_departments
            // 
            this.cb_departments.FormattingEnabled = true;
            this.cb_departments.Location = new System.Drawing.Point(521, 128);
            this.cb_departments.Name = "cb_departments";
            this.cb_departments.Size = new System.Drawing.Size(225, 33);
            this.cb_departments.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start date:";
            // 
            // dp_add_employee
            // 
            this.dp_add_employee.Location = new System.Drawing.Point(546, 237);
            this.dp_add_employee.Name = "dp_add_employee";
            this.dp_add_employee.Size = new System.Drawing.Size(200, 31);
            this.dp_add_employee.TabIndex = 6;
            // 
            // UC_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UC_AddUser";
            this.Size = new System.Drawing.Size(1295, 690);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_register_employee;
        private System.Windows.Forms.ComboBox cb_roles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.ComboBox cb_departments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dp_add_employee;
    }
}
