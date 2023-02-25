namespace FitnessTrackingTools
{
    partial class UserManagementForm
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
            this.picClientLogo = new System.Windows.Forms.PictureBox();
            this.btnUserLogin = new System.Windows.Forms.Button();
            this.btnUserNew = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserDOB = new System.Windows.Forms.Label();
            this.lblUserWeight = new System.Windows.Forms.Label();
            this.lblUserHeight = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserWeight = new System.Windows.Forms.TextBox();
            this.txtUserHeight = new System.Windows.Forms.TextBox();
            this.btnUserCreate = new System.Windows.Forms.Button();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.dateTimeDOB = new System.Windows.Forms.DateTimePicker();
            this.txtUserLoginUsername = new System.Windows.Forms.TextBox();
            this.lblUserUsername = new System.Windows.Forms.Label();
            this.lblUserLoginPassword = new System.Windows.Forms.Label();
            this.txtUserLoginPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picClientLogo
            // 
            this.picClientLogo.Image = global::FitnessTrackingTools.Properties.Resources.client_logo;
            this.picClientLogo.Location = new System.Drawing.Point(12, 12);
            this.picClientLogo.Name = "picClientLogo";
            this.picClientLogo.Size = new System.Drawing.Size(63, 83);
            this.picClientLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClientLogo.TabIndex = 9;
            this.picClientLogo.TabStop = false;
            // 
            // btnUserLogin
            // 
            this.btnUserLogin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUserLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUserLogin.Location = new System.Drawing.Point(314, 22);
            this.btnUserLogin.Name = "btnUserLogin";
            this.btnUserLogin.Size = new System.Drawing.Size(59, 60);
            this.btnUserLogin.TabIndex = 23;
            this.btnUserLogin.Text = "Login";
            this.btnUserLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserLogin.UseVisualStyleBackColor = false;
            this.btnUserLogin.Click += new System.EventHandler(this.btnUserLogin_Click);
            // 
            // btnUserNew
            // 
            this.btnUserNew.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUserNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUserNew.Location = new System.Drawing.Point(290, 244);
            this.btnUserNew.Name = "btnUserNew";
            this.btnUserNew.Size = new System.Drawing.Size(72, 65);
            this.btnUserNew.TabIndex = 24;
            this.btnUserNew.Text = "New User";
            this.btnUserNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserNew.UseVisualStyleBackColor = false;
            this.btnUserNew.Click += new System.EventHandler(this.btnUserNew_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(21, 244);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(52, 20);
            this.lblUserName.TabIndex = 25;
            this.lblUserName.Text = "Name:";
            // 
            // lblUserDOB
            // 
            this.lblUserDOB.AutoSize = true;
            this.lblUserDOB.Location = new System.Drawing.Point(21, 343);
            this.lblUserDOB.Name = "lblUserDOB";
            this.lblUserDOB.Size = new System.Drawing.Size(43, 20);
            this.lblUserDOB.TabIndex = 26;
            this.lblUserDOB.Text = "DOB:";
            // 
            // lblUserWeight
            // 
            this.lblUserWeight.AutoSize = true;
            this.lblUserWeight.Location = new System.Drawing.Point(21, 310);
            this.lblUserWeight.Name = "lblUserWeight";
            this.lblUserWeight.Size = new System.Drawing.Size(59, 20);
            this.lblUserWeight.TabIndex = 27;
            this.lblUserWeight.Text = "Weight:";
            // 
            // lblUserHeight
            // 
            this.lblUserHeight.AutoSize = true;
            this.lblUserHeight.Location = new System.Drawing.Point(21, 277);
            this.lblUserHeight.Name = "lblUserHeight";
            this.lblUserHeight.Size = new System.Drawing.Size(57, 20);
            this.lblUserHeight.TabIndex = 28;
            this.lblUserHeight.Text = "Height:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(91, 241);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(176, 27);
            this.txtUserName.TabIndex = 29;
            // 
            // txtUserWeight
            // 
            this.txtUserWeight.Location = new System.Drawing.Point(91, 307);
            this.txtUserWeight.Name = "txtUserWeight";
            this.txtUserWeight.ReadOnly = true;
            this.txtUserWeight.Size = new System.Drawing.Size(176, 27);
            this.txtUserWeight.TabIndex = 31;
            // 
            // txtUserHeight
            // 
            this.txtUserHeight.Location = new System.Drawing.Point(91, 274);
            this.txtUserHeight.Name = "txtUserHeight";
            this.txtUserHeight.ReadOnly = true;
            this.txtUserHeight.Size = new System.Drawing.Size(176, 27);
            this.txtUserHeight.TabIndex = 32;
            // 
            // btnUserCreate
            // 
            this.btnUserCreate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUserCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUserCreate.Location = new System.Drawing.Point(290, 404);
            this.btnUserCreate.Name = "btnUserCreate";
            this.btnUserCreate.Size = new System.Drawing.Size(72, 65);
            this.btnUserCreate.TabIndex = 33;
            this.btnUserCreate.Text = "Create";
            this.btnUserCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserCreate.UseVisualStyleBackColor = false;
            this.btnUserCreate.Visible = false;
            this.btnUserCreate.Click += new System.EventHandler(this.btnUserCreate_Click);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(91, 404);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.ReadOnly = true;
            this.txtUserPassword.Size = new System.Drawing.Size(176, 27);
            this.txtUserPassword.TabIndex = 34;
            // 
            // txtUserPasswordConfirm
            // 
            this.txtUserPasswordConfirm.Location = new System.Drawing.Point(91, 437);
            this.txtUserPasswordConfirm.Name = "txtUserPasswordConfirm";
            this.txtUserPasswordConfirm.PasswordChar = '*';
            this.txtUserPasswordConfirm.ReadOnly = true;
            this.txtUserPasswordConfirm.Size = new System.Drawing.Size(176, 27);
            this.txtUserPasswordConfirm.TabIndex = 35;
            // 
            // lblPasswordConfirm
            // 
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.Location = new System.Drawing.Point(21, 440);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(65, 20);
            this.lblPasswordConfirm.TabIndex = 36;
            this.lblPasswordConfirm.Text = "Confirm:";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(21, 407);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(73, 20);
            this.lblUserPassword.TabIndex = 37;
            this.lblUserPassword.Text = "Password:";
            // 
            // dateTimeDOB
            // 
            this.dateTimeDOB.Enabled = false;
            this.dateTimeDOB.Location = new System.Drawing.Point(91, 343);
            this.dateTimeDOB.Name = "dateTimeDOB";
            this.dateTimeDOB.Size = new System.Drawing.Size(176, 27);
            this.dateTimeDOB.TabIndex = 38;
            // 
            // txtUserLoginUsername
            // 
            this.txtUserLoginUsername.Location = new System.Drawing.Point(170, 22);
            this.txtUserLoginUsername.Name = "txtUserLoginUsername";
            this.txtUserLoginUsername.Size = new System.Drawing.Size(138, 27);
            this.txtUserLoginUsername.TabIndex = 40;
            // 
            // lblUserUsername
            // 
            this.lblUserUsername.AutoSize = true;
            this.lblUserUsername.Location = new System.Drawing.Point(87, 25);
            this.lblUserUsername.Name = "lblUserUsername";
            this.lblUserUsername.Size = new System.Drawing.Size(78, 20);
            this.lblUserUsername.TabIndex = 39;
            this.lblUserUsername.Text = "Username:";
            // 
            // lblUserLoginPassword
            // 
            this.lblUserLoginPassword.AutoSize = true;
            this.lblUserLoginPassword.Location = new System.Drawing.Point(92, 57);
            this.lblUserLoginPassword.Name = "lblUserLoginPassword";
            this.lblUserLoginPassword.Size = new System.Drawing.Size(73, 20);
            this.lblUserLoginPassword.TabIndex = 42;
            this.lblUserLoginPassword.Text = "Password:";
            // 
            // txtUserLoginPassword
            // 
            this.txtUserLoginPassword.Location = new System.Drawing.Point(170, 55);
            this.txtUserLoginPassword.Name = "txtUserLoginPassword";
            this.txtUserLoginPassword.PasswordChar = '*';
            this.txtUserLoginPassword.Size = new System.Drawing.Size(138, 27);
            this.txtUserLoginPassword.TabIndex = 41;
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 521);
            this.Controls.Add(this.lblUserLoginPassword);
            this.Controls.Add(this.txtUserLoginPassword);
            this.Controls.Add(this.txtUserLoginUsername);
            this.Controls.Add(this.lblUserUsername);
            this.Controls.Add(this.dateTimeDOB);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.txtUserPasswordConfirm);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.btnUserCreate);
            this.Controls.Add(this.txtUserHeight);
            this.Controls.Add(this.txtUserWeight);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserHeight);
            this.Controls.Add(this.lblUserWeight);
            this.Controls.Add(this.lblUserDOB);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnUserNew);
            this.Controls.Add(this.btnUserLogin);
            this.Controls.Add(this.picClientLogo);
            this.Name = "UserManagementForm";
            this.Text = "UserManagementForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManagementForm_FormClosing);
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picClientLogo;
        private Button btnUserLogin;
        private Button btnUserNew;
        private Label lblUserName;
        private Label lblUserDOB;
        private Label lblUserWeight;
        private Label lblUserHeight;
        private TextBox txtUserName;
        private TextBox txtUserWeight;
        private TextBox txtUserHeight;
        private Button btnUserCreate;
        private TextBox txtUserPassword;
        private TextBox txtUserPasswordConfirm;
        private Label lblPasswordConfirm;
        private Label lblUserPassword;
        private DateTimePicker dateTimeDOB;
        private TextBox txtUserLoginUsername;
        private Label lblUserUsername;
        private Label lblUserLoginPassword;
        private TextBox txtUserLoginPassword;
    }
}