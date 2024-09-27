using System.Timers;

namespace UraniumUIDemoApp
{
    public partial class MainPage : ContentPage
    {
        TimeSpan _timeRemaining;
        private System.Timers.Timer _timer;
        public MainPage()
        {
            InitializeComponent();
            setCurrentDateTime();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            setDateTimeInLabel();
        }

        private void btnGetCurrentDate_Clicked(object sender, EventArgs e)
        {
            setCurrentDateTime(); 
            setDateTimeInLabel();
        }
        void setCurrentDateTime()
        {
            var currentDate = DateTime.Now;
            txtDate.Date = currentDate;
            txtTime.Time = new TimeSpan(currentDate.Hour, currentDate.Minute, currentDate.Second);
        }
        DateTime setTime;
        void setDateTimeInLabel()
        {
            string currentDateString = string.Empty;
            string curDate = txtDate.Date?.ToString("MM/dd/yyyy") ?? string.Empty;
            string curTime = txtTime.Time?.ToString(@"hh\:mm\:ss") ?? string.Empty;
            currentDateString = curDate + ' ' + curTime;
            //lblCounter.Text = currentDateString;
            DateTime.TryParse(currentDateString, out setTime);
            if(!_timer.Enabled)
                _timer.Start();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timeRemaining = setTime - DateTime.Now;
            if (_timeRemaining.TotalSeconds > 0)
            {
                UpdateCountdownLabel();
            }
            else
            {
                _timer.Stop();
                MainThread.BeginInvokeOnMainThread(() => lblCounter.Text = "Time's up!");
            }
        }
        private void UpdateCountdownLabel()
        {
            MainThread.BeginInvokeOnMainThread(() => lblCounter.Text = _timeRemaining.ToString(@"hh\:mm\:ss"));
        }
    }

}
