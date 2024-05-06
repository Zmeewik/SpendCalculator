
using System.Runtime.InteropServices;

namespace SpendCalculator
{
    public partial class Form1 : Form
    {
        //������������� �������
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        //����� ���������� ��� �������� ����������
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hello world!");
        }
    }
}
