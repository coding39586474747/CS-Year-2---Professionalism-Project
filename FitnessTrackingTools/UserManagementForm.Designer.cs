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
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 450);
            this.Controls.Add(this.picClientLogo);
            this.Name = "UserManagementForm";
            this.Text = "UserManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picClientLogo;
    }
}