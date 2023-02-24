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
    public partial class StatsForm : Form
    {
        User user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");
        Form1 mainForm = new Form1();

        public StatsForm(Form1 original, User u)
        {
            InitializeComponent();
            mainForm = original;
            this.user = u;
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblStatsUsernameDisplay.Text = user.Name;
            updateDataGrids();
        }

        private void updateDataGrids()
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

            // Add Strength exercises
            for (int i = 0; i < data.Length; i++)
            {
                if (lines[i].Split(',').ToArray()[0] == "Strength")
                {
                    gridStrength.Rows.Add(data[i]);
                }
            }

            // Add Cardio exercises
            for (int i = 0; i < data.Length; i++)
            {
                if (lines[i].Split(',').ToArray()[0] == "Cardio")
                {
                    gridCardio.Rows.Add(data[i]);
                }
            }
        }

    }
}
