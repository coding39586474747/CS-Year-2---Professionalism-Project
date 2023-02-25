namespace FitnessTrackingTools
{
    partial class ExerciseLogger
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
            this.lblLoggerUsernameDisplay = new System.Windows.Forms.Label();
            this.dropExerciseType = new System.Windows.Forms.ComboBox();
            this.lblExerciseType = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIntensity = new System.Windows.Forms.Label();
            this.lblExerciseName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dateTimeExercise = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSets = new System.Windows.Forms.Label();
            this.lblReps = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtReps = new System.Windows.Forms.TextBox();
            this.txtSets = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblExerciseLogger = new System.Windows.Forms.Label();
            this.dropExerciseName = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dropIntensity = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.picClientLogo.TabIndex = 10;
            this.picClientLogo.TabStop = false;
            // 
            // lblLoggerUsernameDisplay
            // 
            this.lblLoggerUsernameDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoggerUsernameDisplay.AutoSize = true;
            this.lblLoggerUsernameDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoggerUsernameDisplay.Location = new System.Drawing.Point(281, 9);
            this.lblLoggerUsernameDisplay.Name = "lblLoggerUsernameDisplay";
            this.lblLoggerUsernameDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLoggerUsernameDisplay.Size = new System.Drawing.Size(99, 28);
            this.lblLoggerUsernameDisplay.TabIndex = 11;
            this.lblLoggerUsernameDisplay.Text = "Username";
            this.lblLoggerUsernameDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dropExerciseType
            // 
            this.dropExerciseType.FormattingEnabled = true;
            this.dropExerciseType.Items.AddRange(new object[] {
            "Strength",
            "Cardio"});
            this.dropExerciseType.Location = new System.Drawing.Point(229, 89);
            this.dropExerciseType.Name = "dropExerciseType";
            this.dropExerciseType.Size = new System.Drawing.Size(151, 28);
            this.dropExerciseType.TabIndex = 12;
            this.dropExerciseType.SelectedIndexChanged += new System.EventHandler(this.dropExerciseType_SelectedIndexChanged);
            // 
            // lblExerciseType
            // 
            this.lblExerciseType.AutoSize = true;
            this.lblExerciseType.Location = new System.Drawing.Point(229, 66);
            this.lblExerciseType.Name = "lblExerciseType";
            this.lblExerciseType.Size = new System.Drawing.Size(100, 20);
            this.lblExerciseType.TabIndex = 13;
            this.lblExerciseType.Text = "Exercise Type:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(12, 215);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(125, 27);
            this.txtID.TabIndex = 14;
            // 
            // lblIntensity
            // 
            this.lblIntensity.AutoSize = true;
            this.lblIntensity.Location = new System.Drawing.Point(12, 331);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(67, 20);
            this.lblIntensity.TabIndex = 17;
            this.lblIntensity.Text = "Intensity:";
            // 
            // lblExerciseName
            // 
            this.lblExerciseName.AutoSize = true;
            this.lblExerciseName.Location = new System.Drawing.Point(12, 266);
            this.lblExerciseName.Name = "lblExerciseName";
            this.lblExerciseName.Size = new System.Drawing.Size(109, 20);
            this.lblExerciseName.TabIndex = 18;
            this.lblExerciseName.Text = "Exercise Name:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 192);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 20);
            this.lblID.TabIndex = 19;
            this.lblID.Text = "ID:";
            // 
            // dateTimeExercise
            // 
            this.dateTimeExercise.Enabled = false;
            this.dateTimeExercise.Location = new System.Drawing.Point(12, 153);
            this.dateTimeExercise.Name = "dateTimeExercise";
            this.dateTimeExercise.Size = new System.Drawing.Size(176, 27);
            this.dateTimeExercise.TabIndex = 39;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 130);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 40;
            this.lblDate.Text = "Date:";
            // 
            // lblSets
            // 
            this.lblSets.AutoSize = true;
            this.lblSets.Location = new System.Drawing.Point(229, 130);
            this.lblSets.Name = "lblSets";
            this.lblSets.Size = new System.Drawing.Size(39, 20);
            this.lblSets.TabIndex = 46;
            this.lblSets.Text = "Sets:";
            // 
            // lblReps
            // 
            this.lblReps.AutoSize = true;
            this.lblReps.Location = new System.Drawing.Point(229, 192);
            this.lblReps.Name = "lblReps";
            this.lblReps.Size = new System.Drawing.Size(44, 20);
            this.lblReps.TabIndex = 45;
            this.lblReps.Text = "Reps:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(229, 266);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(91, 20);
            this.lblWeight.TabIndex = 44;
            this.lblWeight.Text = "Weight (Kg):";
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(229, 289);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(125, 27);
            this.txtWeight.TabIndex = 43;
            // 
            // txtReps
            // 
            this.txtReps.Enabled = false;
            this.txtReps.Location = new System.Drawing.Point(229, 215);
            this.txtReps.Name = "txtReps";
            this.txtReps.Size = new System.Drawing.Size(125, 27);
            this.txtReps.TabIndex = 42;
            // 
            // txtSets
            // 
            this.txtSets.Enabled = false;
            this.txtSets.Location = new System.Drawing.Point(229, 153);
            this.txtSets.Name = "txtSets";
            this.txtSets.Size = new System.Drawing.Size(125, 27);
            this.txtSets.TabIndex = 41;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(229, 331);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(115, 20);
            this.lblDuration.TabIndex = 48;
            this.lblDuration.Text = "Duration (mins):";
            // 
            // txtDuration
            // 
            this.txtDuration.Enabled = false;
            this.txtDuration.Location = new System.Drawing.Point(229, 354);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(125, 27);
            this.txtDuration.TabIndex = 47;
            // 
            // lblExerciseLogger
            // 
            this.lblExerciseLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExerciseLogger.AutoSize = true;
            this.lblExerciseLogger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExerciseLogger.Location = new System.Drawing.Point(111, 9);
            this.lblExerciseLogger.Name = "lblExerciseLogger";
            this.lblExerciseLogger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExerciseLogger.Size = new System.Drawing.Size(147, 28);
            this.lblExerciseLogger.TabIndex = 49;
            this.lblExerciseLogger.Text = "Exercise Logger";
            this.lblExerciseLogger.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dropExerciseName
            // 
            this.dropExerciseName.Enabled = false;
            this.dropExerciseName.FormattingEnabled = true;
            this.dropExerciseName.Items.AddRange(new object[] {
            "Strength",
            "Cardio"});
            this.dropExerciseName.Location = new System.Drawing.Point(12, 290);
            this.dropExerciseName.Name = "dropExerciseName";
            this.dropExerciseName.Size = new System.Drawing.Size(151, 28);
            this.dropExerciseName.TabIndex = 50;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(281, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 65);
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dropIntensity
            // 
            this.dropIntensity.Enabled = false;
            this.dropIntensity.FormattingEnabled = true;
            this.dropIntensity.Items.AddRange(new object[] {
            "Very Low",
            "Low",
            "Average",
            "High",
            "Very High",
            "Extreme"});
            this.dropIntensity.Location = new System.Drawing.Point(12, 354);
            this.dropIntensity.Name = "dropIntensity";
            this.dropIntensity.Size = new System.Drawing.Size(151, 28);
            this.dropIntensity.TabIndex = 74;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(32, 399);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 65);
            this.btnClear.TabIndex = 75;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.clearSelection);
            // 
            // ExerciseLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 476);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dropIntensity);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dropExerciseName);
            this.Controls.Add(this.lblExerciseLogger);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblSets);
            this.Controls.Add(this.lblReps);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtReps);
            this.Controls.Add(this.txtSets);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimeExercise);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblExerciseName);
            this.Controls.Add(this.lblIntensity);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblExerciseType);
            this.Controls.Add(this.dropExerciseType);
            this.Controls.Add(this.lblLoggerUsernameDisplay);
            this.Controls.Add(this.picClientLogo);
            this.Name = "ExerciseLogger";
            this.Text = "ExerciseLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExerciseLogger_FormClosing);
            this.Load += new System.EventHandler(this.ExerciseLogger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picClientLogo;
        private Label lblLoggerUsernameDisplay;
        private ComboBox dropExerciseType;
        private Label lblExerciseType;
        private TextBox txtID;
        private Label lblIntensity;
        private Label lblExerciseName;
        private Label lblID;
        private DateTimePicker dateTimeExercise;
        private Label lblDate;
        private Label lblSets;
        private Label lblReps;
        private Label lblWeight;
        private TextBox txtWeight;
        private TextBox txtReps;
        private TextBox txtSets;
        private Label lblDuration;
        private TextBox txtDuration;
        private Label lblExerciseLogger;
        private ComboBox dropExerciseName;
        private Button btnSave;
        private ComboBox dropIntensity;
        private Button btnClear;
    }
}