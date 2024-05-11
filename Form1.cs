
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
    }
}
