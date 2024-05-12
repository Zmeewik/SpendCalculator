
using System.Runtime.InteropServices;

namespace SpendCalculator
{
    public partial class AppView : Form
    {
        //������������� �������
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        IPresenter presenter;

        Font currentFont = new Font("Arial", 14f);
        string defaultSavePath = "";

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
        }

        //����� ���������� ��� �������� ����������
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("App started!");
        }

        //������� ���������� ��� ����� ����
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                //��������������
                case 0:
                    presenter.OpenList();
                    break;
                //�������� ���������
                case 1:
                    presenter.OpenStatistics(pictureDiagram1, currentFont);
                    break;
                //�������
                case 2:
                    presenter.OpenGraphics(pictureGraphs1, currentFont);
                    break;
                //���������
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
                    // ��������� ���� �� ���������� ����
                    presenter.SaveData(filePath);
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog saveFileDialog = new OpenFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    // ��������� ���� �� ���������� ����
                    presenter.SaveData(filePath);
                }
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxPrice.Text, out var res))
            {
                presenter.AddElement(textBoxName.Text, res, dateTimePicker.Value);
            }
            else
                MessageBox.Show($"{res} �� �������� ������!");



        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxId.Text, out var res))
                presenter.DeleteElement(res);
            else
                MessageBox.Show($"{res} �� �������� ������!");

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            presenter.ClearAllFind();
        }

        private void textBoxFindName_TextChanged(object sender, EventArgs e)
        {
            presenter.FindByName(textBoxName.Text);
        }

        private void textBoMinSum_TextChanged(object sender, EventArgs e)
        {
            GetRange();
        }

        private void textBoxMaxSum_TextChanged(object sender, EventArgs e)
        {
            GetRange();
        }

        void GetRange()
        {
            if (Double.TryParse(textBoxMinSum.Text, out var res1))
                if (Double.TryParse(textBoxMaxSum.Text, out var res2))
                    presenter.FindBySum(res1, res2);
                else
                    MessageBox.Show($"{res2} �� �������� ������!");
            else
                MessageBox.Show($"{res1} �� �������� ������!");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            presenter.FindByCreationDate(dateTimeMax2.Value, dateTimeMin2.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            presenter.FindByCreationDate(dateTimeMax2.Value, dateTimeMin2.Value);
        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
