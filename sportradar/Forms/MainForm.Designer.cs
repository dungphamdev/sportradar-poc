namespace sportradar.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnOpenHistoricalDataForm = new Button();
            btnLiveMatchesForm = new Button();
            btnQuit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnOpenHistoricalDataForm, 0, 1);
            tableLayoutPanel1.Controls.Add(btnLiveMatchesForm, 0, 0);
            tableLayoutPanel1.Controls.Add(btnQuit, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(337, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOpenHistoricalDataForm
            // 
            btnOpenHistoricalDataForm.Anchor = AnchorStyles.None;
            btnOpenHistoricalDataForm.Location = new Point(83, 82);
            btnOpenHistoricalDataForm.Name = "btnOpenHistoricalDataForm";
            btnOpenHistoricalDataForm.Size = new Size(170, 49);
            btnOpenHistoricalDataForm.TabIndex = 1;
            btnOpenHistoricalDataForm.Text = "Open Historical Data Form";
            btnOpenHistoricalDataForm.UseVisualStyleBackColor = true;
            btnOpenHistoricalDataForm.Click += btnOpenHistoricalDataForm_Click;
            // 
            // btnLiveMatchesForm
            // 
            btnLiveMatchesForm.Anchor = AnchorStyles.None;
            btnLiveMatchesForm.Location = new Point(83, 11);
            btnLiveMatchesForm.Name = "btnLiveMatchesForm";
            btnLiveMatchesForm.Size = new Size(170, 49);
            btnLiveMatchesForm.TabIndex = 0;
            btnLiveMatchesForm.Text = "Open Live Matches Form";
            btnLiveMatchesForm.UseVisualStyleBackColor = true;
            btnLiveMatchesForm.Click += btnLiveMatchesForm_Click;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.None;
            btnQuit.Location = new Point(83, 389);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(170, 49);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Main Form";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnLiveMatchesForm;
        private Button btnOpenHistoricalDataForm;
        private Button btnQuit;
    }
}
