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
    public partial class DisclaimerForm : Form
    {

        Form1 mainForm = new Form1();

        public DisclaimerForm(Form1 original)
        {
            InitializeComponent();
            mainForm = original;
            original.Visible = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            mainForm.setDisclaimerBool();
            mainForm.Location = this.Location;
            mainForm.Visible = true;
            mainForm.btnUsers_Click(null, EventArgs.Empty);
            this.Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            mainForm.Close();
            this.Close();
        }
    }
}
