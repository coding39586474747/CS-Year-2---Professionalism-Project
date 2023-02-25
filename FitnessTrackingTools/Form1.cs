using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FitnessTrackingTools
{
    public partial class Form1 : Form
    {
        User user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");

        Thread? timerThread = null;
        public delegate void timerCountdownDelegate();

        Thread? stopwatchThread = null;
        public delegate void stopwatchDelegate();

        Thread? intervalThread = null;
        public delegate void intervalDelegate();

        public Form1()
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
                btnChallenge.Enabled = false;
                picToolCover.Location = new Point(1,101);

                if (p.Name == picTimer.Name) timerShow();
                else if (p.Name == picStopwatch.Name) stopwatchShow();
                else if (p.Name == picIntervalTimer.Name) intervalShow();
                else if (p.Name == picUnitConverter.Name) unitConverterShow();
            }
            else
            {
                p.Location = new Point(x - 290, y);
                p.Tag = "closed";
                btnChallenge.Enabled = true;
                picToolCover.Location = new Point(593,58);

                if (p.Name == picTimer.Name) timerHide();
                else if (p.Name == picStopwatch.Name) stopwatchHide();
                else if (p.Name == picIntervalTimer.Name) intervalHide();
                else if (p.Name == picUnitConverter.Name) unitConverterHide();
            }

            sender = p;
        }

        // Generates a Challenge from randomly selected values
        private void btnChallenge_Click(object sender, EventArgs e)
        {         
            if (user.Name == "null user")
            {
                MessageBox.Show("You must log in to generate a challenge");
                return;
            }
            string[] cardioArr = { "Running", "Swimming", "Cycling", "Hiking" };
            string[] strengthArr = { "Bench Press", "Dumbbell Press", "Squats", "Deadlift", "Overhead Press", "Bent Over Rows" };
            string[] intensityArr = { "Very Low", "Low", "Average" }; // Does not recommend higher intensity
            int[] repsArr = { 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] setsArr = { 2, 3, 4, 5 };
            int[] weightArr = { 10, 20, 30, 40, 50, 60 };   
            int[] durationArr = { 10, 15, 20, 25, 30 };

            Strength str = new Strength
                (user.updateID(), randomIndex(strengthArr),
                randomIndex(intensityArr), user, DateTime.Now,
                randomIndex(repsArr), randomIndex(setsArr),
                randomIndex(weightArr));

            Cardio car = new Cardio
                (user.updateID()+1, randomIndex(cardioArr),
                randomIndex(intensityArr), user, DateTime.Now,
                randomIndex(durationArr));

            string message = "Strength:\n" + str.Name + "\nSets: " + str.Sets + "\nReps: " + str.Reps
                + "\nWeight: " + str.Weight
                + "\n\nCardio: \n" + car.Name + "\nDuration: " + car.DurationInMinutes + "\n\nCompleted the challenge?";

            DialogResult result = MessageBox.Show(message, "New Challenge", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            str.AppendToCSV();
            car.AppendToCSV();


        }

        // takes an int array and returns a random index for it
        private int randomIndex(int[] arr)
        {
            Random random = new Random();
            int index = random.Next(0, arr.Length);
            return arr[index];
        }

        // takes a string array and returns a random index for it
        private string randomIndex(string[] arr)
        {
            Random random = new Random();
            int index = random.Next(0, arr.Length);
            return arr[index];
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (user.Name == "null user")
            {
                MessageBox.Show("You must be logged in to begin logging exercises");
                return;
            }

            bool isFormOpen = false;

            // Check if there's an instance of ExerciseLogger open
            foreach (Form form in Application.OpenForms)
            {
                if (form is ExerciseLogger)
                {
                    isFormOpen = true;
                    form.Focus();
                    break;
                }

            }

            // If no instance of UserManagementForm is open, create a new one
            if (!isFormOpen)
            {
                ExerciseLogger ExerciseLoggerForm = new ExerciseLogger(this, user);
                ExerciseLoggerForm.Show();
                ExerciseLoggerForm.Location = this.Location;
                this.Visible = false;
            }
        }

        private void btnAchievement_Click(object sender, EventArgs e)
        {

        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            if (user.Name == "null user")
            {
                MessageBox.Show("You must be logged in to see stats");
                return;
            }

            bool isFormOpen = false;

            // Check if there's an instance of UserManagementForm open
            foreach (Form form in Application.OpenForms)
            {
                if (form is StatsForm)
                {
                    isFormOpen = true;
                    form.Focus();
                    break;
                }

            }

            // If no instance of UserManagementForm is open, create a new one
            if (!isFormOpen)
            {
                StatsForm statsForm = new StatsForm(this, user);
                statsForm.Show();
                statsForm.Location = this.Location;
                this.Visible = false;
            }
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
                UserManagementForm userManagementForm = new UserManagementForm(this, user);
                userManagementForm.Show();
                userManagementForm.Location = this.Location;
                this.Visible = false;
            }        
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (user.Name == "null user") return;
            MessageBox.Show("Logging out");
            user = new User("null user", 180, 75, new DateTime(1980, 1, 1), "Default");
            txtWeeklyMessage.Text = "Sign in by clicking the User icon above!";
        }

        public void updateUser(User u)
        {
            user = u;
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
            lblTimerName.Location = new Point(517, 13);

            lblTimerHoursDisplay.Location = new Point(485, 204);
            lblTimerMinutesDisplay.Location = new Point(538, 204);
            lblTimerSecondsDisplay.Location = new Point(591, 204);

            txtTimerHours.Location = new Point(487, 63);
            txtTimerMinutes.Location = new Point(540, 63);
            txtTimerSeconds.Location = new Point(593, 63);

            btnTimerStart.Location = new Point(453, 126);
            btnTimerStop.Location = new Point(532, 126);
            btnTimerReset.Location = new Point(606, 126);
        }

        private void timerShow()
        {
            lblTimerName.Location = new Point(99,162);

            lblTimerHoursDisplay.Location = new Point(67,353);
            lblTimerMinutesDisplay.Location = new Point(120,353);
            lblTimerSecondsDisplay.Location = new Point(173,353);

            txtTimerHours.Location = new Point(69,212);
            txtTimerMinutes.Location = new Point(122,212);
            txtTimerSeconds.Location = new Point(175,212);

            btnTimerStart.Location = new Point(35,275);
            btnTimerStop.Location = new Point(114,275);
            btnTimerReset.Location = new Point(188,275);
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
            lblStopwatchName.Location = new Point(54,126);

            lblStopwatchHours.Location = new Point(54,175);
            lblStopwatchMinutes.Location = new Point(107,175);
            lblStopwatchSeconds.Location = new Point(160,175);

            btnStopwatchStart.Location = new Point(62,355);
            btnStopwatchStop.Location = new Point(141,355);
            btnStopwatchReset.Location = new Point(62,439);
            btnStopwatchLap.Location = new Point(141,439);

            lstStopwatchLaps.Location = new Point(60,223);
        }

        public void stopwatchHide()
        {
            lblStopwatchName.Location = new Point(1002,77);

            lblStopwatchHours.Location = new Point(1002,77);
            lblStopwatchMinutes.Location = new Point(1002,77);
            lblStopwatchSeconds.Location = new Point(1002,77);

            btnStopwatchStart.Location = new Point(1002,77);
            btnStopwatchStop.Location = new Point(1002,77);
            btnStopwatchReset.Location = new Point(1002,77);
            btnStopwatchLap.Location = new Point(1002,77);

            lstStopwatchLaps.Location = new Point(1002,77);
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
            lblIntervalName.Location = new Point(68,167);

            lblIntervalWork.Location = new Point(7,217);
            lblIntervalBreak.Location = new Point(123,217);
            lblIntervalLaps.Location = new Point(238,217);

            lblIntervalMinW.Location = new Point(3,300);
            lblIntervalSecW.Location = new Point(56,300);

            lblIntervalMinB.Location = new Point(123,300);
            lblIntervalSecB.Location = new Point(176,300);

            txtIntervalMinW.Location = new Point(3,245);
            txtIntervalSecW.Location = new Point(56,245);

            txtIntervalMinB.Location = new Point(123,245);
            txtIntervalSecB.Location = new Point(176,245);

            txtIntervalLapCount.Location = new Point(238,245);
            lblIntervalLapCount.Location = new Point(238,300);

            btnIntervalStart.Location = new Point(34,348);
            btnIntervalStop.Location = new Point(113,348);
            btnIntervalReset.Location = new Point(187,348);
        }

        public void intervalHide()
        {
            lblIntervalName.Location = new Point(498, 270);

            lblIntervalWork.Location = new Point(498, 270);
            lblIntervalBreak.Location = new Point(498, 270);
            lblIntervalLaps.Location = new Point(498, 270);

            lblIntervalMinW.Location = new Point(498, 270);
            lblIntervalSecW.Location = new Point(498, 270);

            lblIntervalMinB.Location = new Point(498, 270);
            lblIntervalSecB.Location = new Point(498, 270);

            txtIntervalMinW.Location = new Point(498, 270);
            txtIntervalSecW.Location = new Point(498, 270);

            txtIntervalMinB.Location = new Point(498, 270);
            txtIntervalSecB.Location = new Point(498, 270);

            txtIntervalLapCount.Location = new Point(498, 270);
            lblIntervalLapCount.Location = new Point(498, 270);

            btnIntervalStart.Location = new Point(498, 270);
            btnIntervalStop.Location = new Point(498, 270);
            btnIntervalReset.Location = new Point(498, 270);
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
            lblUnitConverterName.Location = new Point(45,150);
            lblUnitConverterDistanceName.Location = new Point(39,295);
            lblUnitConverterWeightName.Location = new Point(36,200);

            txtUnitConverterDistanceInput.Location = new Point(34,318);
            txtUnitConverterDistanceOutput.Location = new Point(34,354);

            txtUnitConverterWeightInput.Location = new Point(34,226);
            txtUnitConverterWeightOutput.Location = new Point(34,265);

            dropUnitConverterDistanceInput.Location = new Point(139,317);
            dropUnitConverterDistanceOutput.Location = new Point(139,354);

            dropUnitConverterWeightInput.Location = new Point(139,225);
            dropUnitConverterWeightOutput.Location = new Point(139,265);

            btnUnitConverterDistance.Location = new Point(202,318);
            btnUnitConverterWeight.Location = new Point(202,225);
        }

        private void unitConverterHide()
        {
            lblUnitConverterName.Location = new Point(885,296);
            lblUnitConverterDistanceName.Location = new Point(885,296);
            lblUnitConverterWeightName.Location = new Point(885,296);

            txtUnitConverterDistanceInput.Location = new Point(885,296);
            txtUnitConverterDistanceOutput.Location = new Point(885,296);

            txtUnitConverterWeightInput.Location = new Point(885,296);
            txtUnitConverterWeightOutput.Location = new Point(885,296);

            dropUnitConverterDistanceInput.Location = new Point(885,296);
            dropUnitConverterDistanceOutput.Location = new Point(885,296);

            dropUnitConverterWeightInput.Location = new Point(885,296);
            dropUnitConverterWeightOutput.Location = new Point(885,296);

            btnUnitConverterDistance.Location = new Point(885,296);
            btnUnitConverterWeight.Location = new Point(885,296);
        }

        #endregion ConverterControl

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dropUnitConverterDistanceInput.SelectedIndex = 0;
            dropUnitConverterDistanceOutput.SelectedIndex = 1;
            dropUnitConverterWeightInput.SelectedIndex = 0;
            dropUnitConverterWeightOutput.SelectedIndex = 1;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (user.Name == "null user") return;

            else
            {
                txtWeeklyMessage.Text = "Hello " + user.Name + "!";
                txtWeeklyMessage.AppendText(Environment.NewLine);
                txtWeeklyMessage.AppendText("Did you know that exercise is, like, good for you?");
            }
        }
    }
}