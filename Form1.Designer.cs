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
            pictureEdit1 = new PictureBox();
            pictureEdit2 = new PictureBox();
            diagramTab = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureDiagram1 = new PictureBox();
            pictureDiagram2 = new PictureBox();
            graphTab = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureGraphs1 = new PictureBox();
            pictureGraphs2 = new PictureBox();
            settingsPage = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel1 = new Panel();
            buttonFont = new Button();
            buttonColor = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tabControl1.SuspendLayout();
            editTab.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit2).BeginInit();
            diagramTab.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureDiagram2).BeginInit();
            graphTab.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureGraphs1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureGraphs2).BeginInit();
            settingsPage.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
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
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
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
            tableLayoutPanel1.Controls.Add(pictureEdit1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureEdit2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel1.Size = new Size(786, 416);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Dock = DockStyle.Fill;
            pictureEdit1.Location = new Point(3, 3);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Size = new Size(387, 410);
            pictureEdit1.TabIndex = 0;
            pictureEdit1.TabStop = false;
            // 
            // pictureEdit2
            // 
            pictureEdit2.Dock = DockStyle.Fill;
            pictureEdit2.Location = new Point(396, 3);
            pictureEdit2.Name = "pictureEdit2";
            pictureEdit2.Size = new Size(387, 410);
            pictureEdit2.TabIndex = 1;
            pictureEdit2.TabStop = false;
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(pictureDiagram1, 0, 0);
            tableLayoutPanel2.Controls.Add(pictureDiagram2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel2.Size = new Size(786, 416);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // pictureDiagram1
            // 
            pictureDiagram1.Dock = DockStyle.Fill;
            pictureDiagram1.Location = new Point(3, 3);
            pictureDiagram1.Name = "pictureDiagram1";
            pictureDiagram1.Size = new Size(387, 410);
            pictureDiagram1.TabIndex = 0;
            pictureDiagram1.TabStop = false;
            // 
            // pictureDiagram2
            // 
            pictureDiagram2.Dock = DockStyle.Fill;
            pictureDiagram2.Location = new Point(396, 3);
            pictureDiagram2.Name = "pictureDiagram2";
            pictureDiagram2.Size = new Size(387, 410);
            pictureDiagram2.TabIndex = 1;
            pictureDiagram2.TabStop = false;
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
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.63131F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.3686867F));
            tableLayoutPanel3.Controls.Add(pictureGraphs1, 0, 0);
            tableLayoutPanel3.Controls.Add(pictureGraphs2, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 89.3364944F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10.6635075F));
            tableLayoutPanel3.Size = new Size(792, 422);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // pictureGraphs1
            // 
            pictureGraphs1.Dock = DockStyle.Fill;
            pictureGraphs1.Location = new Point(3, 3);
            pictureGraphs1.Name = "pictureGraphs1";
            pictureGraphs1.Size = new Size(592, 416);
            pictureGraphs1.TabIndex = 0;
            pictureGraphs1.TabStop = false;
            // 
            // pictureGraphs2
            // 
            pictureGraphs2.Dock = DockStyle.Fill;
            pictureGraphs2.Location = new Point(601, 3);
            pictureGraphs2.Name = "pictureGraphs2";
            pictureGraphs2.Size = new Size(188, 416);
            pictureGraphs2.TabIndex = 1;
            pictureGraphs2.TabStop = false;
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
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.38889F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.61111F));
            tableLayoutPanel5.Controls.Add(panel1, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 17.45636F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 82.54364F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(792, 422);
            tableLayoutPanel5.TabIndex = 4;
            tableLayoutPanel5.Paint += tableLayoutPanel5_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonFont);
            panel1.Controls.Add(buttonColor);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 416);
            panel1.TabIndex = 0;
            // 
            // buttonFont
            // 
            buttonFont.Location = new Point(0, 53);
            buttonFont.Name = "buttonFont";
            buttonFont.Size = new Size(186, 50);
            buttonFont.TabIndex = 1;
            buttonFont.Text = "Изменить шрифт";
            buttonFont.UseVisualStyleBackColor = true;
            buttonFont.Click += buttonFont_Click;
            // 
            // buttonColor
            // 
            buttonColor.Location = new Point(0, 3);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(186, 44);
            buttonColor.TabIndex = 0;
            buttonColor.Text = "Изменить цвет";
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += buttonColor_Click;
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
            // AppView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "AppView";
            Text = "Expenditure calculator";
            Load += Form1_Load;
            ResizeEnd += AppView_ResizeEnd;
            tabControl1.ResumeLayout(false);
            editTab.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit2).EndInit();
            diagramTab.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureDiagram2).EndInit();
            graphTab.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureGraphs1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureGraphs2).EndInit();
            settingsPage.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private PictureBox pictureEdit1;
        private PictureBox pictureEdit2;
        private PictureBox pictureDiagram1;
        private PictureBox pictureDiagram2;
        private PictureBox pictureGraphs1;
        private PictureBox pictureGraphs2;
        private Panel panel1;
        private Button buttonColor;
        private Button buttonFont;
    }
}
