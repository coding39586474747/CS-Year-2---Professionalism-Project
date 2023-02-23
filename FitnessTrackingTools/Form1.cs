using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FitnessTrackingTools
{
    public partial class lblUnitConverterName : Form
    {
        User? user;

        Thread? timerThread = null;
        public delegate void timerCountdownDelegate();

        Thread? stopwatchThread = null;
        public delegate void stopwatchDelegate();

        Thread? intervalThread = null;
        public delegate void intervalDelegate();

        public lblUnitConverterName()
        {
            InitializeComponent();
        }

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

                if (p.Name == picTimer.Name) timerShow();
                else if (p.Name == picStopwatch.Name) stopwatchShow();
                else if (p.Name == picIntervalTimer.Name) intervalShow();
                else if (p.Name == picUnitConverter.Name) unitConverterShow();
            }
            else
            {
                p.Location = new Point(x - 290, y);
                p.Tag = "closed";
                picToolCover.Visible = false;
                picToolCover.Enabled = false;

                if (p.Name == picTimer.Name) timerHide();
                else if (p.Name == picStopwatch.Name) stopwatchHide();
                else if (p.Name == picIntervalTimer.Name) intervalHide();
                else if (p.Name == picUnitConverter.Name) unitConverterHide();
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
            bool isFormOpen = false;

            // Check if there's an instance of UserManagementForm open
            foreach (Form form in Application.OpenForms)
            {
                if (form is UserManagementForm)
                {
                    isFormOpen = true;
                    form.Focus();
                    break;
                }
            }

            // If no instance of UserManagementForm is open, create a new one
            if (!isFormOpen)
            {
                UserManagementForm userManagementForm = new UserManagementForm(user);
                userManagementForm.Show();
            }        
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        #region TimerControl
        private void timerCountdown()
        {
            var hours = int.Parse(lblTimerHoursDisplay.Text);
            var minutes = int.Parse(lblTimerMinutesDisplay.Text);
            var seconds = int.Parse(lblTimerSecondsDisplay.Text);

            while (btnTimerStart.Enabled == false)
            {
                Thread.Sleep(100);

                // If timer has ended, return
                if (seconds == 0 && minutes == 0 && hours == 0) return;

                // If hours remain and minutes & seconds are 0
                if (hours > 0 && minutes == 0 && seconds <= 0)
                {
                    minutes = 59;
                    seconds = 59;
                    hours--;
                }

                // If hours & minutes remain & seconds are 0
                else if (hours > 0 && minutes > 0 && seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }

                // If minutes remain with no hours & seconds are 0
                else if (hours == 0 && minutes > 0 && seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }

                else
                {
                    // Extra check prevents mismatch on timer stop
                    if (btnTimerStart.Enabled == false) seconds--;
                }

                updateTimerLabels(hours, minutes, seconds);
            }
        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            // Invalid entry check
            if (int.Parse(txtTimerMinutes.Text) > 59 || int.Parse(txtTimerSeconds.Text) > 59
                || int.Parse(txtTimerMinutes.Text) < 0 || int.Parse(txtTimerSeconds.Text) < 0
                || int.Parse(txtTimerHours.Text) < 0)
            {
                MessageBox.Show("Invalid time entry, try again");
                return;
            }

            // no entry check
            if (int.Parse(txtTimerHours.Text) == 0
                && int.Parse(txtTimerMinutes.Text) == 0
                && int.Parse(txtTimerSeconds.Text) == 0)
            {
                MessageBox.Show("Enter a time value");
                return;
            }

            btnTimerStart.Enabled = false;
            btnTimerStop.Enabled = true;
            btnTimerReset.Enabled = false;

            txtTimerHours.Enabled = false;
            txtTimerMinutes.Enabled = false;
            txtTimerSeconds.Enabled = false;

            lblTimerHoursDisplay.Text = txtTimerHours.Text;
            lblTimerMinutesDisplay.Text = txtTimerMinutes.Text;
            lblTimerSecondsDisplay.Text = txtTimerSeconds.Text;
            timerThread = new Thread(new ThreadStart(timerCountdown));
            timerThread.IsBackground = true;
            timerThread.Start();
        }

        public delegate void updateTimerLabelsDelegate(int h, int m, int s);
        private void updateTimerLabels(int h, int m, int s)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new updateTimerLabelsDelegate(updateTimerLabels),
                    new object[] { h, m, s });
            }
            lblTimerHoursDisplay.Text = h.ToString("00");
            lblTimerMinutesDisplay.Text = m.ToString("00");
            lblTimerSecondsDisplay.Text = s.ToString("00");
        }

        private void btnTimerStop_Click(object sender, EventArgs e)
        {
            btnTimerStart.Enabled = true;
            btnTimerStop.Enabled = false;
            btnTimerReset.Enabled = true;

            txtTimerHours.Enabled = true;
            txtTimerMinutes.Enabled = true;
            txtTimerSeconds.Enabled = true;

            txtTimerHours.Text = lblTimerHoursDisplay.Text;
            txtTimerMinutes.Text = lblTimerMinutesDisplay.Text;
            txtTimerSeconds.Text = lblTimerSecondsDisplay.Text;
        }

        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            btnTimerStart.Enabled = true;
            btnTimerStop.Enabled = false;

            txtTimerHours.Text = "00";
            txtTimerMinutes.Text = "00";
            txtTimerSeconds.Text = "00";

            lblTimerHoursDisplay.Text = "00";
            lblTimerMinutesDisplay.Text = "00";
            lblTimerSecondsDisplay.Text = "00";
        }

        private void timerHide()
        {
            lblTimerName.Visible = false;

            lblTimerHoursDisplay.Visible = false;
            lblTimerMinutesDisplay.Visible = false;
            lblTimerSecondsDisplay.Visible = false;

            txtTimerHours.Visible = false;
            txtTimerMinutes.Visible = false;
            txtTimerSeconds.Visible = false;

            btnTimerStart.Visible = false;
            btnTimerStop.Visible = false;
            btnTimerReset.Visible = false;
        }

        private void timerShow()
        {
            lblTimerName.Visible = true;

            lblTimerHoursDisplay.Visible = true;
            lblTimerMinutesDisplay.Visible = true;
            lblTimerSecondsDisplay.Visible = true;

            txtTimerHours.Visible = true;
            txtTimerMinutes.Visible = true;
            txtTimerSeconds.Visible = true;

            btnTimerStart.Visible = true;
            btnTimerStop.Visible = true;
            btnTimerReset.Visible = true;
        }

        #endregion TimerControl

        #region StopwatchControl

        public void stopwatch()
        {
            var hours = int.Parse(lblStopwatchHours.Text);
            var minutes = int.Parse(lblStopwatchMinutes.Text);
            var seconds = int.Parse(lblStopwatchSeconds.Text);

            while (btnStopwatchStart.Enabled == false)
            {
                Thread.Sleep(10);

                if (seconds == 59)
                {
                    minutes++;
                    seconds = 0;
                }
                if (minutes == 60)
                {
                    hours++;
                    minutes = 0;
                }

                seconds++;

                updateStopwatchLabels(hours, minutes, seconds);
            }

        }

        public delegate void updateStopwatchLabelsDelegate(int h, int m, int s);
        private void updateStopwatchLabels(int h, int m, int s)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new updateStopwatchLabelsDelegate(updateStopwatchLabels),
                    new object[] { h, m, s });
            }
            lblStopwatchHours.Text = h.ToString("00");
            lblStopwatchMinutes.Text = m.ToString("00");
            lblStopwatchSeconds.Text = s.ToString("00");
        }

        private void btnStopwatchStart_Click(object sender, EventArgs e)
        {
            btnStopwatchStart.Enabled = false;
            btnStopwatchStop.Enabled = true;
            btnStopwatchReset.Enabled = false;
            btnStopwatchLap.Enabled = true;

            stopwatchThread = new Thread(new ThreadStart(stopwatch));
            stopwatchThread.IsBackground = true;
            stopwatchThread.Start();
        }

        private void btnStopwatchStop_Click(object sender, EventArgs e)
        {
            btnStopwatchStart.Enabled = true;
            btnStopwatchStop.Enabled = false;
            btnStopwatchReset.Enabled = true;
            btnStopwatchLap.Enabled = false;
        }

        public void stopwatchShow()
        {
            lblStopwatchName.Visible = true;

            lblStopwatchHours.Visible = true;
            lblStopwatchMinutes.Visible = true;
            lblStopwatchSeconds.Visible = true;

            btnStopwatchStart.Visible = true;
            btnStopwatchStop.Visible = true;
            btnStopwatchReset.Visible = true;
            btnStopwatchLap.Visible = true;

            lstStopwatchLaps.Visible = true;
        }

        public void stopwatchHide()
        {
            lblStopwatchName.Visible = false;

            lblStopwatchHours.Visible = false;
            lblStopwatchMinutes.Visible = false;
            lblStopwatchSeconds.Visible = false;

            btnStopwatchStart.Visible = false;
            btnStopwatchStop.Visible = false;
            btnStopwatchReset.Visible = false;
            btnStopwatchLap.Visible = false;

            lstStopwatchLaps.Visible = false;
        }

        private void btnStopwatchReset_Click(object sender, EventArgs e)
        {
            lblStopwatchHours.Text = "00";
            lblStopwatchMinutes.Text = "00";
            lblStopwatchSeconds.Text = "00";

            btnStopwatchReset.Enabled = false;
            btnStopwatchStart.Enabled = true;
            btnStopwatchStop.Enabled = false;
            btnStopwatchLap.Enabled = false;

            lstStopwatchLaps.Items.Clear();
        }

        private void btnStopwatchLap_Click(object sender, EventArgs e)
        {
            lstStopwatchLaps.Items.Add(lblStopwatchHours.Text + " : "
                + lblStopwatchMinutes.Text + " : " + lblStopwatchSeconds.Text);
        }


        #endregion StopwatchControl

        #region IntervalControl

        public void interval()
        {
            var laps = int.Parse(lblIntervalLapCount.Text);

            while (btnIntervalStart.Enabled == false)
            {
                if (laps == 0)
                {
                    updateIntervalLabels(true, 0, 0, laps);
                    updateIntervalLabels(false, 0, 0, laps);
                    btnIntervalStop_Click(null, EventArgs.Empty);
                    return;
                }

                var minutes = int.Parse(lblIntervalMinW.Text);
                var seconds = int.Parse(lblIntervalSecW.Text);

                // Loops to count down working clock
                while ((minutes != 0 || seconds != 0) && btnIntervalStart.Enabled == false)
                {
                    Thread.Sleep(100);

                    if (minutes > 0 && seconds == 0)
                    {
                        minutes--;
                        seconds = 59;
                    }
                    else seconds--;

                    updateIntervalLabels(true, minutes, seconds, laps);
                }

                minutes = int.Parse(lblIntervalMinB.Text);
                seconds = int.Parse(lblIntervalSecB.Text);

                // Loops to count down break clock
                while ((minutes != 0 || seconds != 0) && btnIntervalStart.Enabled == false)
                {
                    Thread.Sleep(100);

                    if (minutes > 0 && seconds == 0)
                    {
                        minutes--;
                        seconds = 59;
                        updateIntervalLabels(false, minutes, seconds, laps);
                    }
                    else
                    {
                        seconds--;
                        updateIntervalLabels(false, minutes, seconds, laps);
                    }

                    if (minutes == 0 && seconds == 0 && laps >= 1)
                    {
                        laps--;
                        updateIntervalLabels(true, int.Parse(txtIntervalMinW.Text), 
                            int.Parse(txtIntervalSecW.Text), laps);
                        updateIntervalLabels(false, int.Parse(txtIntervalMinB.Text),
                            int.Parse(txtIntervalSecB.Text), laps);
                    }

                    else if (minutes == 0 && seconds == 0 && laps == 0)
                    {
                        laps--;
                        updateIntervalLabels(false, minutes, seconds, laps);

                    }

                }
            }
        }
        private void btnIntervalStart_Click(object sender, EventArgs e)
        {
            // Check something has been entered
            if (int.Parse(txtIntervalMinW.Text) == 0 && int.Parse(txtIntervalSecW.Text) == 0
                && int.Parse(txtIntervalMinB.Text) == 0 && int.Parse(txtIntervalSecB.Text) == 0
                || int.Parse(txtIntervalLapCount.Text) <= 0)
            {
                MessageBox.Show("Enter some data");
                return;
            }

            // Check entries are not too large
            if (int.Parse(txtIntervalMinW.Text) > 59 || int.Parse(txtIntervalSecW.Text) > 59
                || int.Parse(txtIntervalMinB.Text) > 59 || int.Parse(txtIntervalSecB.Text) > 59)
            {
                MessageBox.Show("Invalid Entry, try again");
                return;
            }

            // Check entries are not too small
            if (int.Parse(txtIntervalMinW.Text) < 0 || int.Parse(txtIntervalSecW.Text) < 0
                || int.Parse(txtIntervalMinB.Text) < 0 || int.Parse(txtIntervalSecB.Text) < 0)
            {
                MessageBox.Show("Invalid Entry, try again");
                return;
            }

            btnIntervalStart.Enabled = false;
            btnIntervalStop.Enabled = true;
            btnIntervalReset.Enabled = false;

            txtIntervalMinW.Enabled = false;
            txtIntervalSecW.Enabled = false;
            txtIntervalMinB.Enabled = false;
            txtIntervalSecB.Enabled = false;
            txtIntervalLapCount.Enabled = false;

            lblIntervalMinW.Text = txtIntervalMinW.Text;
            lblIntervalSecW.Text = txtIntervalSecW.Text;
            lblIntervalMinB.Text = txtIntervalMinB.Text;
            lblIntervalSecB.Text = txtIntervalSecB.Text;
            lblIntervalLapCount.Text = txtIntervalLapCount.Text;

            intervalThread = new Thread(new ThreadStart(interval));
            intervalThread.IsBackground = true;
            intervalThread.Start();
        }


        public delegate void updateIntervalLabelsDelegate(bool isWork, int m, int s, int laps);
        private void updateIntervalLabels(bool isWork, int m, int s, int laps)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new updateIntervalLabelsDelegate(updateIntervalLabels),
                    new object[] { isWork, m, s, laps });
            }

            lblIntervalLapCount.Text = laps.ToString("00");

            if (isWork)
            {
                lblIntervalMinW.Text = m.ToString("00");
                lblIntervalSecW.Text = s.ToString("00");
            }

            else if (!isWork)
            {
                lblIntervalMinB.Text = m.ToString("00");
                lblIntervalSecB.Text = s.ToString("00");
            }
        }

        public void intervalShow()
        {
            lblIntervalName.Visible = true;

            lblIntervalWork.Visible = true;
            lblIntervalBreak.Visible = true;
            lblIntervalLaps.Visible = true;

            lblIntervalMinW.Visible = true;
            lblIntervalSecW.Visible = true;

            lblIntervalMinB.Visible = true;
            lblIntervalSecB.Visible = true;

            txtIntervalMinW.Visible = true;
            txtIntervalSecW.Visible = true;

            txtIntervalMinB.Visible = true;
            txtIntervalSecB.Visible = true;

            txtIntervalLapCount.Visible = true;
            lblIntervalLapCount.Visible = true;

            btnIntervalStart.Visible = true;
            btnIntervalStop.Visible = true;
            btnIntervalReset.Visible = true;
        }

        public void intervalHide()
        {
            lblIntervalName.Visible = false;

            lblIntervalWork.Visible = false;
            lblIntervalBreak.Visible = false;
            lblIntervalLaps.Visible = false;

            lblIntervalMinW.Visible = false;
            lblIntervalSecW.Visible = false;

            lblIntervalMinB.Visible = false;
            lblIntervalSecB.Visible = false;

            txtIntervalMinW.Visible = false;
            txtIntervalSecW.Visible = false;

            txtIntervalMinB.Visible = false;
            txtIntervalSecB.Visible = false;

            txtIntervalLapCount.Visible = false;
            lblIntervalLapCount.Visible = false;

            btnIntervalStart.Visible = false;
            btnIntervalStop.Visible = false;
            btnIntervalReset.Visible = false;
        }

        public delegate void btnIntervalStop_ClickDelegate(object sender, EventArgs e);
        private void btnIntervalStop_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new btnIntervalStop_ClickDelegate(btnIntervalStop_Click),
                    new object[] { sender, e });
            }

            btnIntervalStart.Enabled = true;
            btnIntervalStop.Enabled = false;
            btnIntervalReset.Enabled = true;

            txtIntervalMinW.Enabled = true;
            txtIntervalSecW.Enabled = true;
            txtIntervalMinB.Enabled = true;
            txtIntervalSecB.Enabled = true;
            txtIntervalLapCount.Enabled = true;
        }
        private void btnIntervalReset_Click(object sender, EventArgs e)
        {
            txtIntervalMinW.Text = "00";
            txtIntervalSecW.Text = "00";
            txtIntervalMinB.Text = "00";
            txtIntervalSecB.Text = "00";
            txtIntervalLapCount.Text = "00";

            lblIntervalMinW.Text = "00";
            lblIntervalSecW.Text = "00";
            lblIntervalMinB.Text = "00";
            lblIntervalSecB.Text = "00";
            lblIntervalLapCount.Text = "00";

            btnIntervalStart.Enabled = true;
            btnIntervalStop.Enabled = false;
            btnIntervalReset.Enabled = false;
        }

        #endregion IntervalControl

        #region ConverterControl
        private void btnUnitConverterWeight_Click(object sender, EventArgs e)
        {
            if (dropUnitConverterWeightInput.SelectedIndex == -1
                || dropUnitConverterWeightOutput.SelectedIndex == -1
                || txtUnitConverterWeightInput.Text == "") return;

            string input = txtUnitConverterWeightInput.Text;
            string output = "";
            string from = dropUnitConverterWeightInput.SelectedItem.ToString();
            string to = dropUnitConverterWeightOutput.SelectedItem.ToString();

            if (from == to) output = input;
            else if (from == "kg" && to == "lbs") output = (double.Parse(input) * 2.204623).ToString("0.00");
            else if (from == "lbs" && to == "kg") output = (double.Parse(input) / 2.204623).ToString("0.00");
            else MessageBox.Show("Something went wrong!");

            txtUnitConverterWeightOutput.Text = output;
        }

        private void btnUnitConverterDistance_Click(object sender, EventArgs e)
        {
            if (dropUnitConverterDistanceInput.SelectedIndex == -1
                || dropUnitConverterDistanceOutput.SelectedIndex == -1
                || txtUnitConverterDistanceInput.Text == "") return;

            string input = txtUnitConverterDistanceInput.Text;
            string output = "";
            string from = dropUnitConverterDistanceInput.SelectedItem.ToString();
            string to = dropUnitConverterDistanceOutput.SelectedItem.ToString();

            if (from == to) output = input;
            else if (from == "Km" && to == "Miles") output = (double.Parse(input) / 1.609344).ToString("0.00");
            else if (from == "Miles" && to == "Km") output = (double.Parse(input) * 1.609344).ToString("0.00");
            else MessageBox.Show("Something went wrong!");

            txtUnitConverterDistanceOutput.Text = output;
        }

        private void unitConverterShow()
        {
            lblUCName.Visible = true;
            lblUnitConverterDistanceName.Visible = true;
            lblUnitConverterWeightName.Visible = true;

            txtUnitConverterDistanceInput.Visible = true;
            txtUnitConverterDistanceOutput.Visible = true;

            txtUnitConverterWeightInput.Visible = true;
            txtUnitConverterWeightOutput.Visible = true;

            dropUnitConverterDistanceInput.Visible = true;
            dropUnitConverterDistanceOutput.Visible = true;

            dropUnitConverterWeightInput.Visible = true;
            dropUnitConverterWeightOutput.Visible = true;

            btnUnitConverterDistance.Visible = true;
            btnUnitConverterWeight.Visible = true;
        }

        private void unitConverterHide()
        {
            lblUCName.Visible = false;
            lblUnitConverterDistanceName.Visible = false;
            lblUnitConverterWeightName.Visible = false;

            txtUnitConverterDistanceInput.Visible = false;
            txtUnitConverterDistanceOutput.Visible = false;

            txtUnitConverterWeightInput.Visible = false;
            txtUnitConverterWeightOutput.Visible = false;

            dropUnitConverterDistanceInput.Visible = false;
            dropUnitConverterDistanceOutput.Visible = false;

            dropUnitConverterWeightInput.Visible = false;
            dropUnitConverterWeightOutput.Visible = false;

            btnUnitConverterDistance.Visible = false;
            btnUnitConverterWeight.Visible = false;
        }
        private void lblUnitConverterName_Load(object sender, EventArgs e)
        {
            dropUnitConverterDistanceInput.SelectedIndex = 0;
            dropUnitConverterDistanceOutput.SelectedIndex = 1;
            dropUnitConverterWeightInput.SelectedIndex = 0;
            dropUnitConverterWeightOutput.SelectedIndex = 1;
        }

        #endregion ConverterControl

    }
}