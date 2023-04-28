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
    public partial class UserManagementForm : Form
    {
        User user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");


        Form1 mainForm = new Form1();

        public UserManagementForm(Form1 original, User u)
        {
            InitializeComponent();
            mainForm = original;
            this.user = u;
        }


        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            if (user.Name == "null user") return;
            else
            {
                btnUserNew.Enabled = false;
                btnUserLogin.Enabled = false;
                txtUserLoginUsername.Enabled = false;
                txtUserLoginPassword.Enabled = false;

                txtUserName.Text = user.Name;
                txtUserHeight.Text = user.Height.ToString();
                txtUserWeight.Text = user.Weight.ToString();
                dateTimeDOB.Value = user.DateOfBirth;
            }
        }

        private void btnUserNew_Click(object sender, EventArgs e)
        {
            btnUserNew.Enabled = false;

            txtUserName.ReadOnly = false;
            txtUserHeight.ReadOnly = false;
            txtUserWeight.ReadOnly = false;
            dateTimeDOB.Enabled = true;
            txtUserPassword.ReadOnly = false;
            txtUserPasswordConfirm.ReadOnly = false;

            btnUserCreate.Visible = true;
        }

        private void btnUserCreate_Click(object sender, EventArgs e)
        {
            if (txtUserPassword.Text != txtUserPasswordConfirm.Text)
            {
                MessageBox.Show("Password mismatch, try again", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUserPassword.Text == "")
            {
                MessageBox.Show("You must enter a password", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUserName.Text == "")
            {
                MessageBox.Show("You must enter a Name", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUserHeight.Text == "")
            {
                MessageBox.Show("You must enter a height", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUserWeight.Text == "")
            {
                MessageBox.Show("You must enter a Weight", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            user = new User(txtUserName.Text,
            double.Parse(txtUserHeight.Text),
            double.Parse(txtUserWeight.Text),
            dateTimeDOB.Value,
            txtUserPassword.Text);

            String _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            String fileName = _filePath + "\\Users\\" + user.Name + ".csv";

            if (File.Exists(fileName)) 
            {
                MessageBox.Show("User already exists");
                return;
            }

            user.WriteUserToCsv(user);

            MessageBox.Show("User created, please sign in now", "User created",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtUserHeight.Text = user.Height.ToString();
            txtUserPassword.Text = user.Name;
            txtUserWeight.Text = user.Weight.ToString();
            dateTimeDOB.Value = user.DateOfBirth;

            btnUserCreate.Enabled = false;
            txtUserHeight.Enabled = false;
            txtUserName.Enabled = false;
            txtUserWeight.Enabled = false;
            dateTimeDOB.Enabled = false;
            txtUserPassword.Enabled = false;
            txtUserPasswordConfirm.Enabled = false;

        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            Encryption encryption = new Encryption("mySecretKey123456789012345678901", "myIV456789012345");
            string username = txtUserLoginUsername.Text;
            string password = txtUserLoginPassword.Text;


            User temp = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");

            try
            {
                temp = temp.ReadUserFromCsv(encryption.Encrypt(username), encryption.Encrypt(password));
            }
            catch (FileNotFoundException ex)
            {
                // Handle the exception by displaying an error message
                temp = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");
                MessageBox.Show("Username incorrect", "File Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            
            if (temp != null && temp.Name != "null user")
            {
                user = temp;
                mainForm.updateUser(user);                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Hint: Username is your name as entered", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnUserNew.Enabled = false;
            btnUserLogin.Enabled = false;
            txtUserLoginUsername.Enabled = false;
            txtUserLoginPassword.Enabled = false;            

            txtUserName.Text = user.Name;
            txtUserHeight.Text = user.Height.ToString();
            txtUserWeight.Text = user.Weight.ToString();
            dateTimeDOB.Value = user.DateOfBirth;
        }

        private void UserManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Location = this.Location;
            mainForm.Visible = true;
        }
    }
}
