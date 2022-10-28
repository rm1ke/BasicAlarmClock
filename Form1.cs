namespace BasicAlarmClock
{
    public partial class Form1 : Form
    {

        System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                UpdateLable upd = updateDateLabel;
                if (lblStatus.InvokeRequired)
                    Invoke(upd, lblStatus, "Done");
                MessageBox.Show("Ring Ring Ring...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        delegate void UpdateLable(Label lbl, string value);
        void updateDateLabel(Label lbl, string value)
        {
            lbl.Text = value;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            lblStatus.Text = "Running...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblStatus.Text = "Done";
        }
    }
}