﻿namespace HolidayBookingSystem
{
    partial class UC_EditUser
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
            this.tb_search = new System.Windows.Forms.TextBox();
            this.btn_show_all = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.lv_search = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Department = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.confirmPasswordErrorLabel = new System.Windows.Forms.Label();
            this.passwordErrorLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_repeat_password = new HolidayBookingSystem.TextBox_Password();
            this.tb_password = new HolidayBookingSystem.TextBox_Password();
            this.btn_password = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.phoneErrorLabel = new System.Windows.Forms.Label();
            this.usernameErrorLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_details = new System.Windows.Forms.Button();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dp_edit = new System.Windows.Forms.DateTimePicker();
            this.cb_roles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_departments = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tb_phoneNumber = new SolutionUtils.PhoneTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_search);
            this.groupBox1.Controls.Add(this.btn_show_all);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.lv_search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(344, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Employee";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // tb_search
            // 
            this.tb_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_search.Location = new System.Drawing.Point(73, 21);
            this.tb_search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(83, 20);
            this.tb_search.TabIndex = 6;
            // 
            // btn_show_all
            // 
            this.btn_show_all.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_show_all.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_show_all.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show_all.ForeColor = System.Drawing.Color.White;
            this.btn_show_all.Location = new System.Drawing.Point(245, 18);
            this.btn_show_all.Margin = new System.Windows.Forms.Padding(2);
            this.btn_show_all.Name = "btn_show_all";
            this.btn_show_all.Size = new System.Drawing.Size(79, 25);
            this.btn_show_all.TabIndex = 9;
            this.btn_show_all.Text = "Show All";
            this.btn_show_all.UseVisualStyleBackColor = false;
            this.btn_show_all.Click += new System.EventHandler(this.btn_show_all_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Search.BackColor = System.Drawing.Color.Green;
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(169, 18);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(72, 25);
            this.btn_Search.TabIndex = 8;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lv_search
            // 
            this.lv_search.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lv_search.BackColor = System.Drawing.SystemColors.Menu;
            this.lv_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Username,
            this.Role,
            this.Department});
            this.lv_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lv_search.FullRowSelect = true;
            this.lv_search.GridLines = true;
            this.lv_search.HideSelection = false;
            this.lv_search.Location = new System.Drawing.Point(14, 59);
            this.lv_search.Margin = new System.Windows.Forms.Padding(2);
            this.lv_search.Name = "lv_search";
            this.lv_search.Size = new System.Drawing.Size(312, 262);
            this.lv_search.TabIndex = 1;
            this.lv_search.UseCompatibleStateImageBehavior = false;
            this.lv_search.View = System.Windows.Forms.View.Details;
            this.lv_search.SelectedIndexChanged += new System.EventHandler(this.lv_search_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 80;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(353, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(452, 348);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Employee";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.confirmPasswordErrorLabel);
            this.groupBox4.Controls.Add(this.passwordErrorLabel);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tb_repeat_password);
            this.groupBox4.Controls.Add(this.tb_password);
            this.groupBox4.Controls.Add(this.btn_password);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(4, 215);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(444, 129);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Update Password";
            // 
            // confirmPasswordErrorLabel
            // 
            this.confirmPasswordErrorLabel.AutoSize = true;
            this.confirmPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmPasswordErrorLabel.Location = new System.Drawing.Point(257, 52);
            this.confirmPasswordErrorLabel.Name = "confirmPasswordErrorLabel";
            this.confirmPasswordErrorLabel.Size = new System.Drawing.Size(123, 13);
            this.confirmPasswordErrorLabel.TabIndex = 28;
            this.confirmPasswordErrorLabel.Text = "Passwords do not match";
            // 
            // passwordErrorLabel
            // 
            this.passwordErrorLabel.AutoSize = true;
            this.passwordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorLabel.Location = new System.Drawing.Point(257, 25);
            this.passwordErrorLabel.Name = "passwordErrorLabel";
            this.passwordErrorLabel.Size = new System.Drawing.Size(146, 13);
            this.passwordErrorLabel.TabIndex = 27;
            this.passwordErrorLabel.Text = "Not meeting password criteria";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(104, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "* must contain 1 uppercase, 1 number  and 8 chars";
            // 
            // tb_repeat_password
            // 
            this.tb_repeat_password.Location = new System.Drawing.Point(140, 50);
            this.tb_repeat_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_repeat_password.MaxLength = 32;
            this.tb_repeat_password.Name = "tb_repeat_password";
            this.tb_repeat_password.PasswordChar = '*';
            this.tb_repeat_password.Size = new System.Drawing.Size(111, 20);
            this.tb_repeat_password.TabIndex = 21;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(140, 22);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.MaxLength = 32;
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(111, 20);
            this.tb_password.TabIndex = 20;
            // 
            // btn_password
            // 
            this.btn_password.BackColor = System.Drawing.Color.Green;
            this.btn_password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_password.ForeColor = System.Drawing.Color.White;
            this.btn_password.Location = new System.Drawing.Point(183, 102);
            this.btn_password.Margin = new System.Windows.Forms.Padding(2);
            this.btn_password.Name = "btn_password";
            this.btn_password.Size = new System.Drawing.Size(68, 27);
            this.btn_password.TabIndex = 19;
            this.btn_password.Text = "Update";
            this.btn_password.UseVisualStyleBackColor = false;
            this.btn_password.Click += new System.EventHandler(this.btn_password_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.tb_phoneNumber);
            this.groupBox3.Controls.Add(this.phoneErrorLabel);
            this.groupBox3.Controls.Add(this.usernameErrorLabel);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btn_details);
            this.groupBox3.Controls.Add(this.tb_username);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dp_edit);
            this.groupBox3.Controls.Add(this.cb_roles);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cb_departments);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(4, 20);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(444, 191);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Details";
            // 
            // phoneErrorLabel
            // 
            this.phoneErrorLabel.AutoSize = true;
            this.phoneErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.phoneErrorLabel.Location = new System.Drawing.Point(257, 138);
            this.phoneErrorLabel.Name = "phoneErrorLabel";
            this.phoneErrorLabel.Size = new System.Drawing.Size(109, 13);
            this.phoneErrorLabel.TabIndex = 26;
            this.phoneErrorLabel.Text = "Invalid phone number";
            // 
            // usernameErrorLabel
            // 
            this.usernameErrorLabel.AutoSize = true;
            this.usernameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameErrorLabel.Location = new System.Drawing.Point(257, 34);
            this.usernameErrorLabel.Name = "usernameErrorLabel";
            this.usernameErrorLabel.Size = new System.Drawing.Size(144, 13);
            this.usernameErrorLabel.TabIndex = 25;
            this.usernameErrorLabel.Text = "Must have least 6 characters";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Phone Number:";
            // 
            // btn_details
            // 
            this.btn_details.BackColor = System.Drawing.Color.Green;
            this.btn_details.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_details.ForeColor = System.Drawing.Color.White;
            this.btn_details.Location = new System.Drawing.Point(183, 160);
            this.btn_details.Margin = new System.Windows.Forms.Padding(2);
            this.btn_details.Name = "btn_details";
            this.btn_details.Size = new System.Drawing.Size(68, 28);
            this.btn_details.TabIndex = 20;
            this.btn_details.Text = "Update";
            this.btn_details.UseVisualStyleBackColor = false;
            this.btn_details.Click += new System.EventHandler(this.btn_details_Click);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(115, 28);
            this.tb_username.Margin = new System.Windows.Forms.Padding(2);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(136, 20);
            this.tb_username.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Role:";
            // 
            // dp_edit
            // 
            this.dp_edit.Location = new System.Drawing.Point(115, 112);
            this.dp_edit.Margin = new System.Windows.Forms.Padding(2);
            this.dp_edit.Name = "dp_edit";
            this.dp_edit.Size = new System.Drawing.Size(136, 20);
            this.dp_edit.TabIndex = 17;
            // 
            // cb_roles
            // 
            this.cb_roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_roles.FormattingEnabled = true;
            this.cb_roles.Location = new System.Drawing.Point(115, 84);
            this.cb_roles.Margin = new System.Windows.Forms.Padding(2);
            this.cb_roles.Name = "cb_roles";
            this.cb_roles.Size = new System.Drawing.Size(136, 21);
            this.cb_roles.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Start date:";
            // 
            // cb_departments
            // 
            this.cb_departments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_departments.FormattingEnabled = true;
            this.cb_departments.Location = new System.Drawing.Point(115, 56);
            this.cb_departments.Margin = new System.Windows.Forms.Padding(2);
            this.cb_departments.Name = "cb_departments";
            this.cb_departments.Size = new System.Drawing.Size(136, 21);
            this.cb_departments.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Department:";
            // 
            // tb_phoneNumber
            // 
            this.tb_phoneNumber.ForeColor = System.Drawing.Color.Black;
            this.tb_phoneNumber.Location = new System.Drawing.Point(115, 135);
            this.tb_phoneNumber.Name = "tb_phoneNumber";
            this.tb_phoneNumber.Size = new System.Drawing.Size(136, 20);
            this.tb_phoneNumber.TabIndex = 27;
            // 
            // UC_EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_EditUser";
            this.Size = new System.Drawing.Size(805, 348);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_show_all;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_roles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_departments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dp_edit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_details;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox_Password tb_repeat_password;
        private TextBox_Password tb_password;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label confirmPasswordErrorLabel;
        private System.Windows.Forms.Label passwordErrorLabel;
        private System.Windows.Forms.Label phoneErrorLabel;
        private System.Windows.Forms.Label usernameErrorLabel;
        private SolutionUtils.PhoneTextBox tb_phoneNumber;
    }
}
