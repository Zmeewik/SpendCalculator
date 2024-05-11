
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
        }

        //Метод вызываемый при загрузке приложения
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("App started!");
            ChangeBackgroundColor(Color.LightCyan);
            ChangeFont(new Font("Arial", 14f));
        }

        //Функция вызываемая при смене таба
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawInfo();
        }

        void RedrawInfo()
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
                    presenter.OpenGraphics(pictureGraphs1);
                    break;
                //Настройки
                case 3:

                    break;
                default:
                    break;
            }
        }

        private void pictureSettings1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

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
            var pictures = new List<PictureBox>() { pictureDiagram1, pictureDiagram2, pictureEdit1, pictureEdit2, pictureGraphs1, pictureGraphs2 };
            presenter.ChangeColor(pictures.ToArray(), panels.ToArray(), color);
        }

        private void ChangeFont(Font font)
        {
            var buttons = new List<Button> { buttonColor, buttonFont };
            presenter.ChangeFont(buttons.ToArray(), font);
        }

        private void AppView_ResizeEnd(object sender, EventArgs e)
        {
            RedrawInfo();
        }
    }
}
