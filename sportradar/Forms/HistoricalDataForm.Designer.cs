namespace sportradar.Forms
{
    partial class HistoricalDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label4 = new Label();
            label1 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            cbbAwayCompetitions = new ComboBox();
            label5 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbbHomeCompetitions = new ComboBox();
            label3 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnSearchAway = new Button();
            txtAway = new TextBox();
            dtgvAway = new DataGridView();
            dtgvHome = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnSearchHome = new Button();
            txtHome = new TextBox();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvAway).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHome).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(930, 568);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label4, 2, 0);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 2, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 2, 2);
            tableLayoutPanel3.Controls.Add(dtgvAway, 2, 3);
            tableLayoutPanel3.Controls.Add(dtgvHome, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(4, 35);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(922, 529);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(668, 5);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 0;
            label4.Text = "Away";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(201, 5);
            label1.Name = "label1";
            label1.Size = new Size(55, 21);
            label1.TabIndex = 0;
            label1.Text = "Home";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(cbbAwayCompetitions, 1, 0);
            tableLayoutPanel6.Controls.Add(label5, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(467, 35);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(451, 34);
            tableLayoutPanel6.TabIndex = 4;
            // 
            // cbbAwayCompetitions
            // 
            cbbAwayCompetitions.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbAwayCompetitions.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbAwayCompetitions.FormattingEnabled = true;
            cbbAwayCompetitions.Location = new Point(103, 5);
            cbbAwayCompetitions.Name = "cbbAwayCompetitions";
            cbbAwayCompetitions.Size = new Size(345, 23);
            cbbAwayCompetitions.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 9);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 0;
            label5.Text = "Select League:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(cbbHomeCompetitions, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 35);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(450, 34);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // cbbHomeCompetitions
            // 
            cbbHomeCompetitions.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbHomeCompetitions.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHomeCompetitions.FormattingEnabled = true;
            cbbHomeCompetitions.Location = new Point(103, 5);
            cbbHomeCompetitions.Name = "cbbHomeCompetitions";
            cbbHomeCompetitions.Size = new Size(344, 23);
            cbbHomeCompetitions.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 0;
            label3.Text = "Select League:";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(btnSearchAway, 1, 0);
            tableLayoutPanel5.Controls.Add(txtAway, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(464, 73);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(457, 40);
            tableLayoutPanel5.TabIndex = 3;
            // 
            // btnSearchAway
            // 
            btnSearchAway.Dock = DockStyle.Fill;
            btnSearchAway.Location = new Point(390, 3);
            btnSearchAway.Name = "btnSearchAway";
            btnSearchAway.Size = new Size(64, 34);
            btnSearchAway.TabIndex = 4;
            btnSearchAway.Text = "Search";
            btnSearchAway.UseVisualStyleBackColor = true;
            btnSearchAway.Click += btnSearchAway_Click;
            // 
            // txtAway
            // 
            txtAway.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAway.Location = new Point(3, 8);
            txtAway.Name = "txtAway";
            txtAway.Size = new Size(381, 23);
            txtAway.TabIndex = 2;
            // 
            // dtgvAway
            // 
            dtgvAway.AllowUserToAddRows = false;
            dtgvAway.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dtgvAway.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgvAway.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvAway.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvAway.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvAway.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvAway.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvAway.Dock = DockStyle.Fill;
            dtgvAway.GridColor = SystemColors.Control;
            dtgvAway.Location = new Point(467, 117);
            dtgvAway.Name = "dtgvAway";
            dtgvAway.ReadOnly = true;
            dtgvAway.Size = new Size(451, 408);
            dtgvAway.TabIndex = 1;
            // 
            // dtgvHome
            // 
            dtgvHome.AllowUserToAddRows = false;
            dtgvHome.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dtgvHome.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgvHome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvHome.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgvHome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgvHome.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgvHome.DefaultCellStyle = dataGridViewCellStyle6;
            dtgvHome.Dock = DockStyle.Fill;
            dtgvHome.GridColor = SystemColors.Control;
            dtgvHome.Location = new Point(4, 117);
            dtgvHome.Name = "dtgvHome";
            dtgvHome.ReadOnly = true;
            dtgvHome.Size = new Size(450, 408);
            dtgvHome.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(btnSearchHome, 1, 0);
            tableLayoutPanel4.Controls.Add(txtHome, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(1, 73);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(456, 40);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // btnSearchHome
            // 
            btnSearchHome.Dock = DockStyle.Fill;
            btnSearchHome.Location = new Point(389, 3);
            btnSearchHome.Name = "btnSearchHome";
            btnSearchHome.Size = new Size(64, 34);
            btnSearchHome.TabIndex = 4;
            btnSearchHome.Text = "Search";
            btnSearchHome.UseVisualStyleBackColor = true;
            btnSearchHome.Click += btnSearchHome_Click;
            // 
            // txtHome
            // 
            txtHome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtHome.Location = new Point(3, 8);
            txtHome.Name = "txtHome";
            txtHome.Size = new Size(380, 23);
            txtHome.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(394, 3);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 2;
            label2.Text = "Historical Data";
            // 
            // HistoricalDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 568);
            Controls.Add(tableLayoutPanel1);
            Name = "HistoricalDataForm";
            Text = "HistoricalDataForm";
            WindowState = FormWindowState.Maximized;
            Load += HistoricalDataForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvAway).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHome).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox cbbHomeCompetitions;
        private Label label3;
        private Button btnSearchHome;
        private TextBox txtHome;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dtgvHome;
        private DataGridView dtgvAway;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label4;
        private Button btnSearchAway;
        private TextBox txtAway;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel6;
        private ComboBox cbbAwayCompetitions;
        private Label label5;
    }
}