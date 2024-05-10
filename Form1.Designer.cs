namespace SpendCalculator
{
    partial class AppView
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
            tabControl1 = new TabControl();
            editTab = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            diagramTab = new TabPage();
            graphTab = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            settingsPage = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tabControl1.SuspendLayout();
            editTab.SuspendLayout();
            diagramTab.SuspendLayout();
            graphTab.SuspendLayout();
            settingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(editTab);
            tabControl1.Controls.Add(diagramTab);
            tabControl1.Controls.Add(graphTab);
            tabControl1.Controls.Add(settingsPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 1;
            // 
            // editTab
            // 
            editTab.Controls.Add(tableLayoutPanel1);
            editTab.Location = new Point(4, 24);
            editTab.Name = "editTab";
            editTab.Padding = new Padding(3);
            editTab.Size = new Size(792, 422);
            editTab.TabIndex = 0;
            editTab.Text = "Редактирование";
            editTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel1.Size = new Size(786, 416);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // diagramTab
            // 
            diagramTab.Controls.Add(tableLayoutPanel2);
            diagramTab.Location = new Point(4, 24);
            diagramTab.Name = "diagramTab";
            diagramTab.Padding = new Padding(3);
            diagramTab.Size = new Size(792, 422);
            diagramTab.TabIndex = 1;
            diagramTab.Text = "Диаграмма";
            diagramTab.UseVisualStyleBackColor = true;
            // 
            // graphTab
            // 
            graphTab.Controls.Add(tableLayoutPanel3);
            graphTab.Location = new Point(4, 24);
            graphTab.Name = "graphTab";
            graphTab.Size = new Size(792, 422);
            graphTab.TabIndex = 2;
            graphTab.Text = "Графики";
            graphTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel2.Size = new Size(786, 416);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.63131F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.3686867F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel3.Size = new Size(792, 422);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // settingsPage
            // 
            settingsPage.BackColor = Color.Transparent;
            settingsPage.Controls.Add(tableLayoutPanel5);
            settingsPage.Location = new Point(4, 24);
            settingsPage.Name = "settingsPage";
            settingsPage.Size = new Size(792, 422);
            settingsPage.TabIndex = 3;
            settingsPage.Text = "Настройки";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.63131F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.63131F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(200, 100);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.38889F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.61111F));
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel5.Size = new Size(792, 422);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // AppView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "AppView";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            editTab.ResumeLayout(false);
            diagramTab.ResumeLayout(false);
            graphTab.ResumeLayout(false);
            settingsPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage editTab;
        private TabPage diagramTab;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage graphTab;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TabPage settingsPage;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
    }
}
