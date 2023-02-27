namespace FitnessTrackingTools
{
    partial class DisclaimerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisclaimerForm));
            this.txtDisclaimer = new System.Windows.Forms.TextBox();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisclaimer
            // 
            this.txtDisclaimer.Location = new System.Drawing.Point(12, 54);
            this.txtDisclaimer.Multiline = true;
            this.txtDisclaimer.Name = "txtDisclaimer";
            this.txtDisclaimer.ReadOnly = true;
            this.txtDisclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisclaimer.Size = new System.Drawing.Size(333, 333);
            this.txtDisclaimer.TabIndex = 0;
            this.txtDisclaimer.Text = resources.GetString("txtDisclaimer.Text");
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDisclaimer.Location = new System.Drawing.Point(12, 9);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(232, 41);
            this.lblDisclaimer.TabIndex = 1;
            this.lblDisclaimer.Text = "Legal Disclaimer";
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDecline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecline.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDecline.Location = new System.Drawing.Point(12, 407);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(73, 65);
            this.btnDecline.TabIndex = 74;
            this.btnDecline.Text = "Decline";
            this.btnDecline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDecline.UseVisualStyleBackColor = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccept.Location = new System.Drawing.Point(272, 407);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(73, 65);
            this.btnAccept.TabIndex = 75;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // DisclaimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 484);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.lblDisclaimer);
            this.Controls.Add(this.txtDisclaimer);
            this.Name = "DisclaimerForm";
            this.Text = "DisclaimerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtDisclaimer;
        private Label lblDisclaimer;
        private Button btnDecline;
        private Button btnAccept;
    }
}