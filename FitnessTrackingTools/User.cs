using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FitnessTrackingTools
{
    public class User
    {
        // Properties
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        private string Password { get; set; }

        // Constructor
        public User(string name, double height, double weight, DateTime dateOfBirth, string password)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
            this.DateOfBirth = dateOfBirth;
            this.Password = password;
        }

        // Password setter
        public void SetPassword(string password)
        {
            this.Password = password;
        }

        // Public method to check if a provided password matches the user's password
        private bool CheckPassword(string password)
        {
            return password == Password;
        }

        private string GetPassword()
        {
            return Password;
        }


        public void WriteUserToCsv(User user)
        {
            // Construct the file path using the user's name
            string username = $"{user.Name}";

            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\Users\\" + username + ".csv";

            // Create a new file if it doesn't exist, or overwrite the existing file
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                // Write the user's data to the CSV file
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                    user.Name,
                    user.Height,
                    user.Weight,
                    user.DateOfBirth.ToString("dd-MM-yyyy"),
                    user.GetPassword()));
            }
        }

        public User ReadUserFromCsv(string username, string password)
        {
            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\Users\\" + username + ".csv";
            
            // Create a StreamReader object to read from the CSV file
            using (StreamReader reader = new StreamReader(fileName))
            {


                // Loop through the lines of the CSV file
                while (!reader.EndOfStream)
                {
                    // Read a line from the CSV file and split it into fields
                    string[] fields = reader.ReadLine().Split(',');

                    // Check if the username and password match
                    if (fields[0] == username && fields[4] == password)
                    {
                        // Create a new User object using the data from the CSV file
                        User user = new User(fields[0], double.Parse(fields[1]), double.Parse(fields[2]), DateTime.Parse(fields[3]), fields[4]);
                        return user;
                    }
                }
            }

            // If no user was found, return null
            return null;
        }

        public int updateID()
        {
            int rowCount = 0;
            string username = $"{Name}";

            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\ExerciseLogs\\" + username + ".csv";
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        rowCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }


            return rowCount + 1;
        }


    }

}
