
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
    }
}
