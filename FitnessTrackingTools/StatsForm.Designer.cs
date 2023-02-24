namespace FitnessTrackingTools
{
    partial class StatsForm
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
            this.lblStats = new System.Windows.Forms.Label();
            this.lblStatsUsernameDisplay = new System.Windows.Forms.Label();
            this.picClientLogo = new System.Windows.Forms.PictureBox();
            this.gridStrength = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExercise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCardio = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGridCardio = new System.Windows.Forms.Label();
            this.lblGridStrength = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCardio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStats
            // 
            this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStats.Location = new System.Drawing.Point(104, 9);
            this.lblStats.Name = "lblStats";
            this.lblStats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStats.Size = new System.Drawing.Size(88, 28);
            this.lblStats.TabIndex = 52;
            this.lblStats.Text = "Statistics";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatsUsernameDisplay
            // 
            this.lblStatsUsernameDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatsUsernameDisplay.AutoSize = true;
            this.lblStatsUsernameDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatsUsernameDisplay.Location = new System.Drawing.Point(274, 9);
            this.lblStatsUsernameDisplay.Name = "lblStatsUsernameDisplay";
            this.lblStatsUsernameDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatsUsernameDisplay.Size = new System.Drawing.Size(99, 28);
            this.lblStatsUsernameDisplay.TabIndex = 51;
            this.lblStatsUsernameDisplay.Text = "Username";
            this.lblStatsUsernameDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picClientLogo
            // 
            this.picClientLogo.Image = global::FitnessTrackingTools.Properties.Resources.client_logo;
            this.picClientLogo.Location = new System.Drawing.Point(8, 12);
            this.picClientLogo.Name = "picClientLogo";
            this.picClientLogo.Size = new System.Drawing.Size(63, 83);
            this.picClientLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClientLogo.TabIndex = 50;
            this.picClientLogo.TabStop = false;
            // 
            // gridStrength
            // 
            this.gridStrength.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStrength.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colExercise,
            this.colDate,
            this.colIntensity,
            this.colReps,
            this.colSets,
            this.colWeight});
            this.gridStrength.Location = new System.Drawing.Point(8, 416);
            this.gridStrength.Name = "gridStrength";
            this.gridStrength.RowHeadersWidth = 51;
            this.gridStrength.RowTemplate.Height = 29;
            this.gridStrength.Size = new System.Drawing.Size(366, 106);
            this.gridStrength.TabIndex = 53;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 125;
            // 
            // colExercise
            // 
            this.colExercise.HeaderText = "Exercise";
            this.colExercise.MinimumWidth = 6;
            this.colExercise.Name = "colExercise";
            this.colExercise.Width = 125;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.Width = 125;
            // 
            // colIntensity
            // 
            this.colIntensity.HeaderText = "Intensity";
            this.colIntensity.MinimumWidth = 6;
            this.colIntensity.Name = "colIntensity";
            this.colIntensity.Width = 125;
            // 
            // colReps
            // 
            this.colReps.HeaderText = "Reps";
            this.colReps.MinimumWidth = 6;
            this.colReps.Name = "colReps";
            this.colReps.Width = 125;
            // 
            // colSets
            // 
            this.colSets.HeaderText = "Sets";
            this.colSets.MinimumWidth = 6;
            this.colSets.Name = "colSets";
            this.colSets.Width = 125;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "Weight";
            this.colWeight.MinimumWidth = 6;
            this.colWeight.Name = "colWeight";
            this.colWeight.Width = 125;
            // 
            // gridCardio
            // 
            this.gridCardio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCardio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.colDuration});
            this.gridCardio.Location = new System.Drawing.Point(8, 282);
            this.gridCardio.Name = "gridCardio";
            this.gridCardio.RowHeadersWidth = 51;
            this.gridCardio.RowTemplate.Height = 29;
            this.gridCardio.Size = new System.Drawing.Size(366, 106);
            this.gridCardio.TabIndex = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Exercise";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Intensity";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Duration";
            this.colDuration.MinimumWidth = 6;
            this.colDuration.Name = "colDuration";
            this.colDuration.Width = 125;
            // 
            // lblGridCardio
            // 
            this.lblGridCardio.AutoSize = true;
            this.lblGridCardio.Location = new System.Drawing.Point(8, 259);
            this.lblGridCardio.Name = "lblGridCardio";
            this.lblGridCardio.Size = new System.Drawing.Size(53, 20);
            this.lblGridCardio.TabIndex = 55;
            this.lblGridCardio.Text = "Cardio";
            // 
            // lblGridStrength
            // 
            this.lblGridStrength.AutoSize = true;
            this.lblGridStrength.Location = new System.Drawing.Point(8, 393);
            this.lblGridStrength.Name = "lblGridStrength";
            this.lblGridStrength.Size = new System.Drawing.Size(65, 20);
            this.lblGridStrength.TabIndex = 56;
            this.lblGridStrength.Text = "Strength";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 529);
            this.Controls.Add(this.lblGridStrength);
            this.Controls.Add(this.lblGridCardio);
            this.Controls.Add(this.gridCardio);
            this.Controls.Add(this.gridStrength);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblStatsUsernameDisplay);
            this.Controls.Add(this.picClientLogo);
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClientLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCardio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblStats;
        private Label lblStatsUsernameDisplay;
        private PictureBox picClientLogo;
        private DataGridView gridStrength;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colExercise;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colIntensity;
        private DataGridViewTextBoxColumn colReps;
        private DataGridViewTextBoxColumn colSets;
        private DataGridViewTextBoxColumn colWeight;
        private DataGridView gridCardio;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn colDuration;
        private Label lblGridCardio;
        private Label lblGridStrength;
    }
}