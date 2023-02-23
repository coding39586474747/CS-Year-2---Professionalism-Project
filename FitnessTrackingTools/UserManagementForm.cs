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
    public partial class UserManagementForm : Form
    {
        User user = new User("John Smith", 180, 75, new DateTime(1980, 1, 1), "Default");



        public UserManagementForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

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

            user.WriteUserToCsv(user);

        }
    }
}
