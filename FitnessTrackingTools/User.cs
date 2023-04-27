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
            
            Encryption encryption = new Encryption("mySecretKey123456789012345678901", "myIV456789012345");

            // Construct the file path using the user's name
            string username = $"{user.Name}";

            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\Users\\" + username + ".csv";

            // Create a new file if it doesn't exist, or overwrite the existing file
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                // Write the user's data to the CSV file
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                    encryption.Encrypt(user.Name),
                    encryption.Encrypt(user.Height.ToString()),
                    encryption.Encrypt(user.Weight.ToString()),
                    encryption.Encrypt(user.DateOfBirth.ToString("dd-MM-yyyy")),
                    encryption.Encrypt(user.GetPassword())));
            }
        }

        public User ReadUserFromCsv(string username, string password)
        {
            Encryption encryption = new Encryption("mySecretKey123456789012345678901", "myIV456789012345");
            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\Users\\" + encryption.Decrypt(username) + ".csv";
            
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
                        User user = new User(
                            encryption.Decrypt(fields[0]), 
                            double.Parse(encryption.Decrypt(fields[1])), 
                            double.Parse(encryption.Decrypt(fields[2])), 
                            DateTime.Parse(encryption.Decrypt(fields[3])), 
                            encryption.Decrypt(fields[4]));

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
