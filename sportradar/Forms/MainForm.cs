namespace sportradar.Forms
{
    public partial class MainForm : Form
    {
        private RealTimeForm? realTimeForm;
        private HistoricalDataForm? historicalDataForm;

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

        private void btnRealTimeForm_Click(object sender, EventArgs e)
        {
            OpenForm(ref realTimeForm);
        }

        private void btnOpenHistoricalDataForm_Click(object sender, EventArgs e)
        {
            OpenForm(ref historicalDataForm);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
