using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackingTools
{
    public class Exercise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Intensity { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        public Exercise()
        {
            // Default constructor
        }

        public Exercise(int id, string name, string intensity, User user, DateTime date)
        {
            ID = id;
            Name = name;
            Intensity = intensity;
            User = user;
            Date = date;
        }

        public virtual void AppendToCSV() { }

    }

    public class Strength : Exercise
    {
        public int Reps { get; set; }
        public int Sets { get; set; }
        public double Weight { get; set; }

        public Strength()
        {
            // Default constructor
        }

        public Strength(int id, string name, string intensity, User user, DateTime date, int reps, int sets, double weight)
            : base(id, name, intensity, user, date) // Base keyword initialises base class parameters
        {
            Reps = reps;
            Sets = sets;
            Weight = weight;
        }

        public override void AppendToCSV()
        {

            string username = $"{User.Name}";
            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\ExerciseLogs\\" + username + ".csv";

            bool fileExists = File.Exists(fileName);

            // Create a new file if it doesn't exist, or overwrite the existing file
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                // Write the exercise data to the CSV file
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                    "Strength", ID, Name, Date.ToString(), Intensity, Reps, Sets, Weight));
            }
        }
    }

  

    public class Cardio : Exercise
    {
        public int DurationInMinutes { get; set; }

        public Cardio()
        {
            // Default constructor
        }

        public Cardio(int id, string name, string intensity, User user, DateTime date, int durationInMinutes)
            : base(id, name, intensity, user, date) // Base keyword initialises base class parameters
        {
            DurationInMinutes = durationInMinutes;
        }

        public override void AppendToCSV()
        {

            string username = $"{User.Name}";
            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\ExerciseLogs\\" + username + ".csv";

            bool fileExists = File.Exists(fileName);

            // Create a new file if it doesn't exist, or overwrite the existing file
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                // Write the exercise data to the CSV file
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}",
                    "Cardio", ID, Name, Date.ToString(), Intensity, DurationInMinutes));
            }

        }
        
    }




}
