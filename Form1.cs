
using System.Runtime.InteropServices;
using SpendCalculator.Classes.Architecture;

namespace SpendCalculator
{
    public partial class AppView : Form
    {
        //������������� �������
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        Presenter presenter;

        public AppView()
        {
            InitializeComponent();
            AllocConsole();
            InitializeElements();
        }

        void InitializeElements()
        {
            presenter = Presenter.Instance();
        }

        //����� ���������� ��� �������� ����������
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("App started!");
            Console.WriteLine("Initializing!");
        }
    }
}
