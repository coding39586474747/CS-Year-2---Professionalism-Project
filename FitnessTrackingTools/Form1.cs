namespace FitnessTrackingTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Windows.Forms.Timer toolTimer = new System.Windows.Forms.Timer();

        private void tool_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            PictureBox p = (PictureBox)sender;
            x = p.Location.X; y = p.Location.Y;

            if (p.Tag.ToString() == "closed")
            {
                p.Location = new Point(x + 290, y);
                p.Tag = "open";
                picToolCover.Visible = true;
                picToolCover.Enabled = true;
            }
            else
            {
                p.Location = new Point(x - 290, y);
                p.Tag = "closed";
                picToolCover.Visible = false;
                picToolCover.Enabled = false;
            }

            sender = p;
        }


        private void btnChallenge_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

        }

        private void btnAchievement_Click(object sender, EventArgs e)
        {

        }

        private void btnStats_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }
    }
}