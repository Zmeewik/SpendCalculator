
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpendCalculator
{
    public partial class AppView : Form
    {
        //Инициализация консоли
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        IPresenter presenter;


        public AppView()
        {
            InitializeComponent();
            AllocConsole();
            InitializeElements();
        }

        void InitializeElements()
        {
            Console.WriteLine("Veiw initialized!");
            presenter = Presenter.Instance();
            DataGridView[] views = [dataGridList, dataGridGraph, dataGridDiagram];
            presenter.Setup(views);
            SetSortDefault();
            presenter.UpdateList();
            UpdateTabs();
        }

        //Метод вызываемый при загрузке приложения
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("App started!");
            ChangeBackgroundColor(Color.White);
            ChangeFont(new Font("Arial", 14f));


        }

        private void SetSortDefault()
        {

        }

        //Функция вызываемая при смене таба
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabs();
        }

        void UpdateTabs()
        {
            switch (tabControl1.SelectedIndex)
            {
                //Редактирование
                case 0:
                    presenter.OpenList();
                    break;
                //Круговая диаграмма
                case 1:
                    presenter.OpenStatistics(pictureDiagram1);
                    break;
                //Графики
                case 2:
                    if (graphType) presenter.OpenGraphics(pictureGraphs1, "types");
                    else presenter.OpenGraphics(pictureGraphs1, "all");
                    break;
                //Настройки
                case 3:

                    break;
                default:
                    break;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    // Сохраняем файл по выбранному пути
                    presenter.SaveData(filePath);
                }
            }
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog saveFileDialog = new OpenFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    // Сохраняем файл по выбранному пути
                    presenter.SaveData(filePath);
                }
            }
            presenter.UpdateList();
            UpdateTabs();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(textBoxPrice.Text, out var res))
            {
                presenter.AddElement(textBoxCategory.Text, textBoxName.Text, res, dateTimePicker.Value, checkBoxRepeat.Checked, comboBoxRecurrence.Text);
            }
            else if (String.IsNullOrEmpty(textBoxPrice.Text))
            {
                presenter.AddElement(textBoxCategory.Text, textBoxName.Text, 0, dateTimePicker.Value, checkBoxRepeat.Checked, comboBoxRecurrence.Text);
            }
            else
                MessageBox.Show($"{res} не является числом!");
            presenter.UpdateList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxId.Text, out var res))
                presenter.DeleteElement(res);
            else
                MessageBox.Show($"{res} не является числом!");
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            presenter.ClearAllFind();
            presenter.UpdateList();
            UpdateTabs();
        }

        void GetRange()
        {

            // Если поля пыстые отправлять максимальные и минимальные значения
            decimal res1 = 0;
            decimal res2 = 0;

            if (string.IsNullOrEmpty(textBoxFindSumMin1.Text))
                res1 = -1;
            if (string.IsNullOrEmpty(textBoxFindSumMax1.Text))
                res2 = -1;

            Console.WriteLine($"{res1} res 1, {res2} res 2");

            if (res1 == -1 && res2 == -1)
            {
                res1 = decimal.MinValue;
                res2 = decimal.MaxValue;
                presenter.FindBySum(res1, res2);
                return;
            }
            else if (res1 == -1)
            {
                res1 = decimal.MinValue;
                if (Decimal.TryParse(textBoxFindSumMax1.Text, out res2))
                    presenter.FindBySum(res1, res2);
                else
                    MessageBox.Show($"{res2} не является числом!");
                return;
            }
            else if (res2 == -1)
            {
                res2 = decimal.MaxValue;
                if (Decimal.TryParse(textBoxFindSumMin1.Text, out res1))
                    presenter.FindBySum(res1, res2);
                else
                    MessageBox.Show($"{res1} не является числом!");
                return;
            }

            //Проверять оба поля, если не пустые на double значения
            if (Decimal.TryParse(textBoxFindSumMin1.Text, out res1))
                if (Decimal.TryParse(textBoxFindSumMax1.Text, out res2))
                    presenter.FindBySum(res1, res2);
                else
                    MessageBox.Show($"{res2} не является числом!");
            else
                MessageBox.Show($"{res1} не является числом!");
        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        //Поиск по элементам
        private void buttonFind1_Click(object sender, EventArgs e)
        {
            presenter.FindByName(textBoxFindName1.Text);
            presenter.FindByCategory(textBoxFindCategory1.Text);
            presenter.FindByCreationDate(dateTimeFindMin1.Value, dateTimeFindMax1.Value);
            GetRange();
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            presenter.ClearAllFind();
            presenter.UpdateList();
            UpdateTabs();
        }

        private void textBoxFindName1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBoxFindName1.Text = textBox.Text;
            textBoxFindName2.Text = textBox.Text;
            textBoxFindName3.Text = textBox.Text;
        }

        private void textBoxFindCategory1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBoxFindCategory1.Text = textBox.Text;
            textBoxFindCategory2.Text = textBox.Text;
            textBoxFindCategory3.Text = textBox.Text;
        }

        private void textBoxFindSumMin1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBoxFindSumMin1.Text = textBox.Text;
            textBoxFindSumMin2.Text = textBox.Text;
            textBoxFindSumMin3.Text = textBox.Text;
        }

        private void textBoxFindSumMax1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBoxFindSumMax1.Text = textBox.Text;
            textBoxFindSumMax2.Text = textBox.Text;
            textBoxFindSumMax3.Text = textBox.Text;
        }

        private void dateTimeFindMin1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            dateTimeFindMin1.Value = picker.Value;
            dateTimeFindMin2.Value = picker.Value;
            dateTimeFindMin3.Value = picker.Value;
        }

        private void dateTimeFindMax1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = sender as DateTimePicker;
            dateTimeFindMax1.Value = picker.Value;
            dateTimeFindMax2.Value = picker.Value;
            dateTimeFindMax3.Value = picker.Value;
        }

        private void UpdateOtherButtons()
        {
            List<Button> buttons = [buttonIDSort1,
                buttonIDSort2,
                buttonIDSort3,
                buttonNameSort1,
                buttonNameSort2,
                buttonNameSort3,
                buttonSumSort1,
                buttonSumSort2,
                buttonSumSort3,
                buttonCategorySort1,
                buttonCategorySort2,
                buttonCategorySort3,
                buttonDateSort1,
                buttonDateSort2,
                buttonDateSort3];
            foreach (var button in buttons)
            {
                if (button.Text[0] == '↑' || button.Text[0] == '↓')
                    button.Text = button.Text.Remove(0, 2);
            }
        }

        bool idInversed = false;
        bool nameInversed = false;
        bool categoryInversed = false;
        bool sumInversed = false;
        bool dateInversed = false;

        bool graphType = false;

        private void buttonIDSort1_Click(object sender, EventArgs e)
        {
            UpdateOtherButtons();
            if (idInversed)
            {
                buttonIDSort2.Text = "↑ " + buttonIDSort1.Text;
                buttonIDSort3.Text = "↑ " + buttonIDSort1.Text;
                buttonIDSort1.Text = "↑ " + buttonIDSort1.Text;
            }
            else
            {
                buttonIDSort2.Text = "↓ " + buttonIDSort1.Text;
                buttonIDSort3.Text = "↓ " + buttonIDSort1.Text;
                buttonIDSort1.Text = "↓ " + buttonIDSort1.Text;
            }
            presenter.SortByCreation(idInversed);
            idInversed = !idInversed;
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonNameSort1_Click(object sender, EventArgs e)
        {
            UpdateOtherButtons();
            if (nameInversed)
            {
                buttonNameSort2.Text = "↑ " + buttonNameSort1.Text;
                buttonNameSort3.Text = "↑ " + buttonNameSort1.Text;
                buttonNameSort1.Text = "↑ " + buttonNameSort1.Text;
            }
            else
            {
                buttonNameSort2.Text = "↓ " + buttonNameSort1.Text;
                buttonNameSort3.Text = "↓ " + buttonNameSort1.Text;
                buttonNameSort1.Text = "↓ " + buttonNameSort1.Text;
            }
            presenter.SortByName(nameInversed);
            nameInversed = !nameInversed;
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonSumSort1_Click(object sender, EventArgs e)
        {
            UpdateOtherButtons();
            if (sumInversed)
            {
                buttonSumSort2.Text = "↑ " + buttonSumSort1.Text;
                buttonSumSort3.Text = "↑ " + buttonSumSort1.Text;
                buttonSumSort1.Text = "↑ " + buttonSumSort1.Text;
            }
            else
            {
                buttonSumSort2.Text = "↓ " + buttonSumSort1.Text;
                buttonSumSort3.Text = "↓ " + buttonSumSort1.Text;
                buttonSumSort1.Text = "↓ " + buttonSumSort1.Text;
            }
            presenter.SortBySum(sumInversed);
            sumInversed = !sumInversed;
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonCategorySort1_Click(object sender, EventArgs e)
        {
            UpdateOtherButtons();
            if (categoryInversed)
            {
                buttonCategorySort2.Text = "↑ " + buttonCategorySort1.Text;
                buttonCategorySort3.Text = "↑ " + buttonCategorySort1.Text;
                buttonCategorySort1.Text = "↑ " + buttonCategorySort1.Text;
            }
            else
            {
                buttonCategorySort2.Text = "↓ " + buttonCategorySort1.Text;
                buttonCategorySort3.Text = "↓ " + buttonCategorySort1.Text;
                buttonCategorySort1.Text = "↓ " + buttonCategorySort1.Text;
            }
            presenter.SortByCategory(categoryInversed);
            categoryInversed = !categoryInversed;
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonDateSort1_Click(object sender, EventArgs e)
        {
            UpdateOtherButtons();
            if (dateInversed)
            {
                buttonDateSort2.Text = "↑ " + buttonDateSort1.Text;
                buttonDateSort3.Text = "↑ " + buttonDateSort1.Text;
                buttonDateSort1.Text = "↑ " + buttonDateSort1.Text;
            }
            else
            {
                buttonDateSort2.Text = "↓ " + buttonDateSort1.Text;
                buttonDateSort3.Text = "↓ " + buttonDateSort1.Text;
                buttonDateSort1.Text = "↓ " + buttonDateSort1.Text;
            }
            presenter.SortByDate(dateInversed);
            dateInversed = !dateInversed;
            presenter.UpdateList();
            UpdateTabs();
        }

        private void buttonAll1_Click(object sender, EventArgs e)
        {
            graphType = !graphType;
            if (graphType)
            {
                presenter.OpenGraphics(pictureGraphs1, "types");
                buttonAll3.Text = "По типам";
            }
            else
            {
                presenter.OpenGraphics(pictureGraphs1, "all");
                buttonAll3.Text = "Все траты";
            }
            UpdateTabs();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ChangeBackgroundColor(colorDialog.Color);
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                ChangeFont(fontDialog.Font);
            }
        }

        private void ChangeBackgroundColor(Color color)
        {
            var panels = new List<Panel>() { panel1, tableLayoutPanel1, tableLayoutPanel2, tableLayoutPanel3, tableLayoutPanel4, tableLayoutPanel5, tableLayoutPanel6 };
            foreach (var pan in panels)
            {
                pan.BackColor = color;
            }
            var grids = new List<DataGridView>() { dataGridDiagram, dataGridGraph, dataGridList };
            foreach (var grid in grids)
            {
                grid.BackColor = color;
            }
            var pictures = new List<PictureBox>() { pictureDiagram1, pictureGraphs1 };
            foreach (var pic in pictures)
            {
                pic.BackColor = color;
            }
            presenter.ChangeColor(color);
        }

        private void ChangeFont(Font font)
        {
            foreach (Control control in this.Controls)
                control.Font = font;

            presenter.ChangeFont(font);
        }

        private void AppView_Resize(object sender, EventArgs e)
        {
            UpdateTabs();
        }

        private void buttonColor1_Click(object sender, EventArgs e)
        {
            presenter.ChangeVisualizeColor();
            UpdateTabs();
        }

        private void dataGridList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            DataGridViewRow currentRow = dataGridList.Rows[e.RowIndex];
            List<object> list = new List<object>();
            // Проходимся по всем ячейкам текущей строки
            foreach (DataGridViewCell cell in currentRow.Cells)
            {
                // Получаем значение ячейки и делаем с ним что-то
                object cellValue = cell.Value;
                list.Add(cellValue);
            }

            // Передаем значения в метод ChangeElement презентера
            presenter.ChangeElement(
                Convert.ToInt32(list[0]),
                list[1]?.ToString(),  // Здесь нужно обращаться к строковому представлению значений
                list[2]?.ToString(),
                Convert.ToDecimal(list[3]),  // Преобразуем в decimal, если это число
                Convert.ToDateTime(list[4]), // Преобразуем в DateTime, если это дата
                Convert.ToBoolean(list[5]),  // Преобразуем в bool, если это логическое значение
                list[6]?.ToString()
            );
            presenter.UpdateList();
            UpdateTabs();
        }

        private void dataGridList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridList.SelectedCells.Count > 0)
            {
                var row = dataGridList.SelectedCells[0].RowIndex;
                textBoxId.Text = dataGridList.Rows[row].Cells[0].Value.ToString();
            }
        }

        private void buttonStandart_Click(object sender, EventArgs e)
        {
            presenter.CreateList();
            presenter.UpdateList();
            UpdateTabs();
        }
    }
}
