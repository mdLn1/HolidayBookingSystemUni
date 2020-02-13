namespace HolidayBookingSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel_top = new System.Windows.Forms.Panel();
            this.loginPictureBox = new System.Windows.Forms.PictureBox();
            this.btn_skip = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.picture_user = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_password = new HolidayBookingSystem.TextBox_Password();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.loginPictureBox);
            this.panel_top.Controls.Add(this.btn_skip);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(2);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(250, 141);
            this.panel_top.TabIndex = 0;
            // 
            // loginPictureBox
            // 
            this.loginPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loginPictureBox.Image")));
            this.loginPictureBox.Location = new System.Drawing.Point(84, 27);
            this.loginPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.loginPictureBox.Name = "loginPictureBox";
            this.loginPictureBox.Size = new System.Drawing.Size(88, 87);
            this.loginPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loginPictureBox.TabIndex = 4;
            this.loginPictureBox.TabStop = false;
            // 
            // btn_skip
            // 
            this.btn_skip.Location = new System.Drawing.Point(191, 101);
            this.btn_skip.Margin = new System.Windows.Forms.Padding(2);
            this.btn_skip.Name = "btn_skip";
            this.btn_skip.Size = new System.Drawing.Size(46, 23);
            this.btn_skip.TabIndex = 9;
            this.btn_skip.Text = "Skip";
            this.btn_skip.UseVisualStyleBackColor = true;
            this.btn_skip.Click += new System.EventHandler(this.btn_skip_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 199);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 1);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(12, 264);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 1);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(0, 73);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 1);
            this.panel5.TabIndex = 2;
            // 
            // tb_username
            // 
            this.tb_username.BackColor = System.Drawing.Color.White;
            this.tb_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.Location = new System.Drawing.Point(48, 183);
            this.tb_username.Margin = new System.Windows.Forms.Padding(2);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(192, 15);
            this.tb_username.TabIndex = 4;
            this.tb_username.Click += new System.EventHandler(this.textBox_Enter);
            this.tb_username.CursorChanged += new System.EventHandler(this.textBox_Enter);
            this.tb_username.TextChanged += new System.EventHandler(this.formValuesChanged);
            this.tb_username.Enter += new System.EventHandler(this.textBox_Enter);
            this.tb_username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.tb_username.Leave += new System.EventHandler(this.textBox_Leave);
            this.tb_username.MouseEnter += new System.EventHandler(this.textBox_Enter);
            this.tb_username.MouseLeave += new System.EventHandler(this.textBox_Leave);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.IndianRed;
            this.btn_login.CausesValidation = false;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.No;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(60, 294);
            this.btn_login.Margin = new System.Windows.Forms.Padding(2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(132, 43);
            this.btn_login.TabIndex = 9;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // picture_user
            // 
            this.picture_user.Image = ((System.Drawing.Image)(resources.GetObject("picture_user.Image")));
            this.picture_user.Location = new System.Drawing.Point(12, 172);
            this.picture_user.Margin = new System.Windows.Forms.Padding(2);
            this.picture_user.Name = "picture_user";
            this.picture_user.Size = new System.Drawing.Size(32, 26);
            this.picture_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture_user.TabIndex = 7;
            this.picture_user.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 237);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // tb_password
            // 
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(47, 248);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.MaxLength = 20;
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(190, 15);
            this.tb_password.TabIndex = 6;
            this.tb_password.Click += new System.EventHandler(this.textBox_Enter);
            this.tb_password.CursorChanged += new System.EventHandler(this.textBox_Enter);
            this.tb_password.TabIndexChanged += new System.EventHandler(this.textBox_Enter);
            this.tb_password.TextChanged += new System.EventHandler(this.formValuesChanged);
            this.tb_password.Enter += new System.EventHandler(this.textBox_Enter);
            this.tb_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.tb_password.Leave += new System.EventHandler(this.textBox_Leave);
            this.tb_password.MouseEnter += new System.EventHandler(this.textBox_Enter);
            this.tb_password.MouseLeave += new System.EventHandler(this.textBox_Leave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(250, 378);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picture_user);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Holiday Booking System - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox loginPictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.PictureBox picture_user;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_skip;
        private TextBox_Password tb_password;
    }
}

