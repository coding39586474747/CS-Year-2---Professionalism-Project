using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            if (user.updateID() > 1)
            {
                updateDataGrids();

                if (gridStrength.RowCount > 0)
                {
                    txtHeaviestLift.Text = getHeaviestLift().ToString() + " Kg";
                    txtMostCommonLift.Text = getCommonLift();
                    txtMostCommonCardio.Text = getCommonCardio();
                    txtLongestCardio.Text = getLongestCardio().ToString() + " mins";
                }

            }

        }

        private int getHeaviestLift()
        {
            int heaviest = 0;

            foreach (DataGridViewRow row in gridStrength.Rows)
            {

                int cellValue = 0;
                if (row.Cells[6].Value != null && int.TryParse(row.Cells[6].Value.ToString(), out cellValue))
                {
                    if (cellValue > heaviest)
                    {
                        heaviest = cellValue;
                    }
                }
            }
            return heaviest;
        }

        private int getLongestCardio()
        {
            int longest = 0;

            foreach (DataGridViewRow row in gridCardio.Rows)
            {

                int cellValue = 0;
                if (row.Cells[4].Value != null && int.TryParse(row.Cells[4].Value.ToString(), out cellValue))
                {
                    if (cellValue > longest)
                    {
                        longest = cellValue;
                    }
                }
            }
            return longest;
        }

        private string getCommonLift()
        {
            string[] strengthArr = { "Bench Press", "Dumbbell Press", "Squats", "Deadlift", "Overhead Press", "Bent Over Rows" };
            int[] countArr = { 0, 0, 0, 0, 0, 0 };
            int biggestIndex = 0;
            int count = 0;

            for (int i = 0; i < strengthArr.Length; i++)
            {
                foreach (DataGridViewRow row in gridStrength.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == strengthArr[i])
                    {
                        count++;
                    }
                }

                countArr[i] = count;
                count = 0;                
            }
            int temp = -1;

            for (int i = 0; i < countArr.Length; i++)
            {
                if (countArr[i] > temp)
                {
                    temp = countArr[i];
                    biggestIndex = i;
                }
            }


            return strengthArr[biggestIndex];
        }

        private string getCommonCardio()
        {
            string[] cardioArr = { "Running", "Swimming", "Cycling", "Hiking" };
            int[] countArr = { 0, 0, 0, 0 };
            int biggestIndex = 0;
            int count = 0;

            for (int i = 0; i < cardioArr.Length; i++)
            {
                foreach (DataGridViewRow row in gridCardio.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == cardioArr[i])
                    {
                        count++;
                    }
                }

                countArr[i] = count;
                count = 0;
            }
            int temp = -1;

            for (int i = 0; i < countArr.Length; i++)
            {
                if (countArr[i] > temp)
                {
                    temp = countArr[i];
                    biggestIndex = i;
                }
            }


            return cardioArr[biggestIndex];
        }

        private void updateDataGrids()
        {
            string username = $"{user.Name}";
            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\ExerciseLogs\\" + username + ".csv";

            // Read all lines from the CSV file.
            string[] lines = File.ReadAllLines(fileName);

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

        private void StatsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Location = this.Location;
            mainForm.Visible = true;
        }
    }
}
