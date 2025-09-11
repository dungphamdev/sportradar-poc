namespace sportradar.Forms
{
    public partial class MainForm : Form
    {
        private LiveMatchesForm? _liveMatchesForm;
        private HistoricalDataForm? _historicalDataForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenForm<T>(ref T? formInstance) where T : Form, new()
        {
            if (formInstance == null || formInstance.IsDisposed)
            {
                formInstance = new T();
                formInstance.Show();
            }
            else
            {
                formInstance.BringToFront();
                formInstance.Focus();
            }
        }

        private void btnLiveMatchesForm_Click(object sender, EventArgs e)
        {
            OpenForm(ref _liveMatchesForm);
        }

        private void btnOpenHistoricalDataForm_Click(object sender, EventArgs e)
        {
            OpenForm(ref _historicalDataForm);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
