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
    public partial class AchievementsForm : Form
    {
        Form1 mainForm;
        User user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");
        Achievement[] achievements = {  };

        public AchievementsForm(Form1 original, User u)
        {
            InitializeComponent();
            mainForm = original;
            this.user = u;
        }

        private void AchievementsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (user.Name == "null user") return;
            else
            {

                populateAchievementGoals();
                populateAchievementProgress();
                populateMedals();
                
            }
        }

        void populateAchievementGoals()
        {
            achievements = new Achievement[] { 
            new Achievement(double.Parse(txtRunningGoal.Text)),
            new Achievement(double.Parse(txtSwimmingGoal.Text)),
            new Achievement(double.Parse(txtCyclingGoal.Text)),
            new Achievement(double.Parse(txtHikingGoal.Text)),

            new Achievement(double.Parse(txtBenchGoal.Text)),
            new Achievement(double.Parse(txtDumbbellGoal.Text)),
            new Achievement(double.Parse(txtSquatsGoal.Text)),
            new Achievement(double.Parse(txtDeadliftGoal.Text)),
            new Achievement(double.Parse(txtOHPGoal.Text)),
            new Achievement(double.Parse(txtBORGoal.Text))
            };
        }

        void populateAchievementProgress()
        {
            string fileName = $"{user.Name}.csv";
            string filePath = Path.Combine("C:\\Users\\taful\\source\\repos\\CS-Year-2---Professionalism-Project\\FitnessTrackingTools\\ExerciseLogs", fileName);

            // Read all lines from the CSV file.
            string[] lines = File.ReadAllLines(filePath);

            // Split each line into an array of string values, starting from index 1.
            string[][] data = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                data[i] = lines[i].Split(',').Skip(1).ToArray();
            }

            // Search for exercises to increment
            for (int i = 0; i < data.Length; i++)
            {
                if (lines[i].Split(',').ToArray()[2] == "Running")
                {
                    achievements[0].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[5]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Swimming")
                {
                    achievements[1].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[5]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Cycling")
                {
                    achievements[2].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[5]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Hiking")
                {
                    achievements[3].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[5]));
                }

                else if (lines[i].Split(',').ToArray()[2] == "Bench Press")
                {
                    achievements[4].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Dumbbell Press")
                {
                    achievements[5].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Squats")
                {
                    achievements[6].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Deadlift")
                {
                    achievements[7].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Overhead Press")
                {
                    achievements[8].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
                else if (lines[i].Split(',').ToArray()[2] == "Bent Over Row")
                {
                    achievements[9].incrementProgress(double.Parse(lines[i].Split(',').ToArray()[6]));
                }
            }

            txtRunningProgress.Text = achievements[0].getProgress().ToString("0.00");
            txtSwimmingProgress.Text = achievements[1].getProgress().ToString("0.00");
            txtCyclingProgress.Text = achievements[2].getProgress().ToString("0.00");
            txtHikingProgress.Text = achievements[3].getProgress().ToString("0.00");

            txtBenchProgress.Text = achievements[4].getProgress().ToString("0.00");
            txtDumbbellProgress.Text = achievements[5].getProgress().ToString("0.00");
            txtSquatsProgress.Text = achievements[6].getProgress().ToString("0.00");
            txtDeadliftProgress.Text = achievements[7].getProgress().ToString("0.00");
            txtOHPProgress.Text = achievements[8].getProgress().ToString("0.00");
            txtBORProgress.Text = achievements[9].getProgress().ToString("0.00");
        }

        public void populateMedals()
        {
            txtRunningMedal.Text = achievements[0].getMedal().ToString();
            txtSwimmingMedal.Text = achievements[1].getMedal().ToString();
            txtCyclingMedal.Text = achievements[2].getMedal().ToString();
            txtHikingMedal.Text = achievements[3].getMedal().ToString();

            txtBenchMedal.Text = achievements[4].getMedal().ToString();
            txtDumbbellMedal.Text = achievements[5].getMedal().ToString();
            txtSquatsMedal.Text = achievements[6].getMedal().ToString();
            txtDeadliftMedal.Text = achievements[7].getMedal().ToString();
            txtOHPMedal.Text = achievements[8].getMedal().ToString();
            txtBORMedal.Text = achievements[9].getMedal().ToString();
        }

        private void AchievementsForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            mainForm.Location = this.Location;
            mainForm.Visible = true;            
        }
    }
}
