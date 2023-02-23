﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Name = name;
            Height = height;
            Weight = weight;
            DateOfBirth = dateOfBirth;
            Password = password;
        }

        // Public method to check if a provided password matches the user's password
        private bool CheckPassword(string password)
        {
            return password == Password;
        }


        public void WriteUserToCsv(User user)
        {
            // Construct the file path using the user's name
            string fileName = $"{user.Name}.csv";
            string filePath = Path.Combine("path/to/directory", fileName);

            // Create a new file if it doesn't exist, or overwrite the existing file
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                // Write the user's data to the CSV file
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                    user.Name,
                    user.Height,
                    user.Weight,
                    user.DateOfBirth.ToString("dd-MM-yyyy"),
                    user.CheckPassword("password") ? "1" : "0"));
            }
        }

        public User ReadUserFromCsv(string filePath)
        {
            // Read the contents of the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Split the contents into fields
            string[] fields = lines[0].Split(',');

            // Create a new User object using the data from the CSV file
            User user = new User(
                fields[0],      // Name
                double.Parse(fields[1]),    // Height
                double.Parse(fields[2]),    // Weight
                DateTime.ParseExact(fields[3], "dd-MM-yyyy", null),    // Date of birth
                fields[4] == "1" ? "password" : "");    // Password (if available)

            return user;
        }


    }

}
