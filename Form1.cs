
using System.Runtime.InteropServices;

namespace SpendCalculator
{
    public partial class AppView : Form
    {
        //Инициализация консоли
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        IPresenter presenter;

        Font currentFont = new Font("Arial", 14f);

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
        }

        //Функция вызываемая при смене таба
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                //Редактирование
                case 0:
                    presenter.OpenList();
                    break;
                //Круговая диаграмма
                case 1:
                    presenter.OpenStatistics(pictureDiagram1, currentFont);
                    break;
                //Графики
                case 2:
                    presenter.OpenGraphics(pictureGraphs1, currentFont);
                    break;
                //Настройки
                case 3:
                    
                    break;
                default:
                    break;
            }
        }
    }
}
