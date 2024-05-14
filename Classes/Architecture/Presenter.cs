
namespace SpendCalculator
{
    internal class Presenter : IPresenter
    {

        static Presenter instance;
        IModel model;

        List<Expenditure> expenditures = new List<Expenditure>();

        //Settings
        Font currentFont = new Font("Arial", 14f);
        Color backColor = Color.LightCyan;

        Presenter()
        {
            model = Model.Instance();
            CreateList();
        }

        static public Presenter Instance()
        {
            if (instance != null)
                return instance;
            instance = new Presenter();
            Console.WriteLine("Presenter created!");
            return instance;
        }

        private void CreateList()
        {
            expenditures.Add(new Expenditure() { Id = 1, Amount = 10, Name = "fish", Category = "Еда", Date = new DateTime(2024, 5, 9) });
            expenditures.Add(new Expenditure() { Id = 2, Amount = 11, Name = "shorts", Category = "Одежда", Date = new DateTime(2024, 5, 9) });
            expenditures.Add(new Expenditure() { Id = 3, Amount = 8, Name = "glasses", Category = "Одежда", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 4, Amount = 5, Name = "gum", Category = "Еда", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 5, Amount = 4, Name = "бумага", Category = "Канцелярия", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 6, Amount = 13, Name = "Pencil", Category = "Канцелярия", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 7, Amount = 21, Name = "Phone", Category = "Техника", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 8, Amount = 2, Name = "Mayo", Category = "Еда", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 9, Amount = 13, Name = "pineapple", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 10, Amount = 4, Name = "apple", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 11, Amount = 55, Name = "banana", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 12, Amount = 0, Name = "banana", Category = "Еда", Date = new DateTime(2024, 5, 13) });
        }

        //Работа со списками
        public void AddElement(string name, double sum, DateTime date)
        {
            model.AddElement(name, sum, date);
        }

        public void DeleteElement(int ID)
        {
            model.DeleteElement(ID);
        }

        //Поиск по списку
        public void FindByCreationDate(DateTime minDate, DateTime maxDate)
        {
            model.FindByCreationDate(minDate, maxDate);
        }

        public void FindByName(string name)
        {
            model.FindByName(name);
        }

        public void FindBySum(double min, double max)
        {
            model.FindBySum(min, max);
        }


        //Работа с визуалом
        //Открыть изуализацию списка в киде графиков
        public void OpenGraphics(PictureBox pictureBox)
        {
            Visualizer.DrawDiagrams(expenditures, pictureBox, currentFont, "all");
        }

        //Открыть редактирование списка
        public void OpenList()
        {
            
        }

        //Открыть изуализацию списка в киде круга
        public void OpenStatistics(PictureBox pictureBox)
        {
            Visualizer.DrawPieDiagram(expenditures, pictureBox, currentFont);
        }

        //Работа с данными
        public void LoadData(string path)
        {
            model.LoadData(path);
        }
        public void SaveData()
        {
            model.SaveData();
        }


        //Сортировки списка
        public void SortByCreation(bool inverse)
        {
            model.SortByCreation(inverse);
        }

        public void SortByDate(bool inverse)
        {
            model.SortByDate(inverse);
        }

        public void SortByName(bool inverse)
        {
            model.SortByName(inverse);
        }

        public void SortBySum(bool inverse)
        {
            model.SortBySum(inverse);
        }


        //Констроль внешнего вида
        //Изменение фона всех панелей
        public void ChangeColor(PictureBox[] pictures, Panel[] panels, Color col)
        {
            backColor = col;
            foreach (var pic in pictures)
            {
                pic.BackColor = backColor;
            }
            foreach (var pan in panels)
            { 
                pan.BackColor = backColor;
            }
        }

        //Изменение всех шрифтов
        public void ChangeFont(Button[] buttons, Font newFont)
        { 
            currentFont = newFont;
            foreach (var button in buttons)
            { 
                button.Font = currentFont;
            }
        }
    }
}
