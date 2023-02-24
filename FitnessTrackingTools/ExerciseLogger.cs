using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTrackingTools
{
    public partial class ExerciseLogger : Form
    {
        User user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");
        Form1 mainForm = new Form1();

        public ExerciseLogger(Form1 original, User u)
        {
            InitializeComponent();
            mainForm = original;
            this.user = u;
        }

        private void ExerciseLogger_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblLoggerUsernameDisplay.Text = user.Name;
            txtID.Text = updateID().ToString();
        }

        private void dropExerciseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropExerciseName.Enabled = true;
            dropIntensity.Enabled = true;
            dateTimeExercise.Enabled = true;

            if (dropExerciseType.SelectedItem.ToString() == "Strength")
            {
                txtSets.Enabled = true;
                txtReps.Enabled = true;
                txtWeight.Enabled = true;

                txtDuration.Enabled = false;

                dropExerciseName.Items.Clear();
                dropExerciseName.Items.Add("Bench Press");
                dropExerciseName.Items.Add("Dumbbell Press");
                dropExerciseName.Items.Add("Squats");
                dropExerciseName.Items.Add("Deadlift");
                dropExerciseName.Items.Add("Overhead Press");
                dropExerciseName.Items.Add("Bent Over Rows");
            }

            else if (dropExerciseType.SelectedItem.ToString() == "Cardio")
            {
                txtDuration.Enabled = true;

                txtSets.Enabled = false;
                txtReps.Enabled = false;
                txtWeight.Enabled = false;

                dropExerciseName.Items.Clear();
                dropExerciseName.Items.Add("Running");
                dropExerciseName.Items.Add("Swimming");
                dropExerciseName.Items.Add("Cycling");
                dropExerciseName.Items.Add("Hiking");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dropExerciseType.SelectedItem.ToString() == "Strength")
            {
                Strength str = new Strength
                    (int.Parse(txtID.Text), dropExerciseName.SelectedItem.ToString(), 
                    dropIntensity.SelectedItem.ToString(), user, dateTimeExercise.Value, 
                    int.Parse(txtReps.Text), int.Parse(txtSets.Text), 
                    double.Parse(txtWeight.Text));

                str.AppendToCSV();
            }

            else if (dropExerciseType.SelectedItem.ToString() == "Cardio")
            {
                Cardio card = new Cardio
                    (int.Parse(txtID.Text), dropExerciseName.SelectedItem.ToString(),
                    dropIntensity.SelectedItem.ToString(), user, dateTimeExercise.Value,
                    int.Parse(txtDuration.Text));

                card.AppendToCSV();
            }

            MessageBox.Show("Added Exercise");

            clearSelection(null, EventArgs.Empty);
            txtID.Text = updateID().ToString();

        }

        private int updateID()
        {
            int rowCount = 0;
            string fileName = $"{user.Name}.csv";
            string filePath = Path.Combine("C:\\Users\\taful\\source\\repos\\CS-Year-2---Professionalism-Project\\FitnessTrackingTools\\ExerciseLogs", fileName);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        rowCount++;
                    }
                }
            }
            catch(Exception ex)
            {
                return 1;
            }


            return rowCount + 1;
        }

        private void clearSelection(object sender, EventArgs e)
        {
            dropExerciseName.SelectedIndex = -1;
            dropExerciseType.SelectedIndex = 0;
            dropIntensity.SelectedIndex = -1;

            txtSets.Text = "";
            txtReps.Text = "";
            txtWeight.Text = "";
            txtDuration.Text = "";
        }
    }
}
